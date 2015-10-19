namespace AutopartsSystem.Core.Pdf
{
    using System.IO;
    using System.Linq;

    using AutopartsSystem.Data;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfReport
    {
        private const string ManufacturerNameColumnHeader = "Manufacturer: ";

        private const string ProductNameColumnHeader = "AutoPart:";

        private const string PriceColumnHeader = "Price:";

        private const string QuantityColumnHeader = "Quantity:";

        private const string SumColumnHeader = "Sum:";

        private const int PdfTableSize = 5;

        private const string AutopartsReportsName = "Autoparts Reports";
        private const string TotalColumName = "Total: ";

        public void GenerateAutopartsReports(string filePath, string fileName, AutopartsDbContext db)
        {
            fileName = UniqueFileNameGenerator.AddUniqueFilenameSuffix(fileName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var output = new FileStream(filePath + fileName, FileMode.Create, FileAccess.Write);
            var writer = PdfWriter.GetInstance(document, output);

            var table = this.CreateAutopartsReportsTable();
            this.AddAutopartsReportsTableHeader(table);
            this.AddAutopartsReportsTableColumns(table);
            this.FillAutopartsReportsTableData(table, db);

            document.Open();
            document.Add(table);
            document.Close();
        }

        private void FillAutopartsReportsTableData(PdfPTable table, AutopartsDbContext db)
        {
            decimal totalSum = 0;
            var autoPartsReport =
                db.AutoParts.Select(
                    c =>
                    new
                        {
                            ProductName = c.Name,
                            Manufacturer = c.Manufacturer.Name,
                            Price = c.Price,
                            Quantity = c.Quantity,
                            Sum = c.Price * c.Quantity
                        }).ToList();

            foreach (var autopart in autoPartsReport)
            {
                table.AddCell(autopart.ProductName);
                table.AddCell(autopart.Manufacturer);
                table.AddCell(autopart.Price.ToString());
                table.AddCell(autopart.Quantity.ToString());
                table.AddCell(autopart.Sum.ToString());
                totalSum += autopart.Sum;

            }
            var totalCell=new PdfPCell(new Phrase(TotalColumName));
            totalCell.BackgroundColor=BaseColor.LIGHT_GRAY;

            table.AddCell(new PdfPCell { Colspan = 3 });
            table.AddCell(totalCell);
            table.AddCell(totalSum.ToString());



        }

        private void AddAutopartsReportsTableColumns(PdfPTable table)
        {
            table.AddCell(ProductNameColumnHeader);
            table.AddCell(ManufacturerNameColumnHeader);
            table.AddCell(PriceColumnHeader);
            table.AddCell(QuantityColumnHeader);
            table.AddCell(SumColumnHeader);
            
        }

        private void AddAutopartsReportsTableHeader(PdfPTable table)
        {
            var cell = new PdfPCell(new Phrase(AutopartsReportsName));
            cell.Colspan = PdfTableSize;
            cell.HorizontalAlignment = 1;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);
        }

        private PdfPTable CreateAutopartsReportsTable()
        {
            var table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            float[] widths =
                {
                    3f,
                    3f,
                    3f,
                    3f,
                    3f
                };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            return table;
        }
    }
}