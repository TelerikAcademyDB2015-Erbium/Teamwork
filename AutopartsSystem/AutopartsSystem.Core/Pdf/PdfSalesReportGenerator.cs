namespace AutopartsSystem.Core.Pdf
{
    using System;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;


    using AutopartsSystem.Data;

    public class PdfFileExporter
    {
        private const string ManufacturerNameColumnHeader = "Manufacturer";
        private const string ModelColumnHeader = "Model";
        private const string PriceColumnHeader = "Price";
        private const int PdfTableSize = 3;

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

            PdfPTable table = this.CreateAutopartsReportsTable();
            this.AddAutopartsReportsTableHeader(table);
            this.AddAutopartsReportsTableColumns(table);
            this.FillAutopartsReportsTableData(table, db);

            document.Open();
            document.Add(table);
            document.Close();
        }

        private void FillAutopartsReportsTableData(PdfPTable table, AutopartsDbContext db)
        {
            var computersReports = db.AutoParts
                .Select(c =>
                    new
                    {
                        ModelColumnHeader = c.Name,
                        ManufacturerNameColumnHeader = c.Manufacturer.Name,

                        PriceColumnHeader = c.Price,
                        


                    })
                .ToList();

            foreach (var computer in computersReports)
            {
                table.AddCell(computer.ManufacturerNameColumnHeader.ToString());
                table.AddCell(computer.ModelColumnHeader.ToString());
                table.AddCell(computer.PriceColumnHeader.ToString() + " $");
            }
        }

        private void AddAutopartsReportsTableColumns(PdfPTable table)
        {
            table.AddCell(ManufacturerNameColumnHeader);
            table.AddCell(ModelColumnHeader);
            table.AddCell(PriceColumnHeader);
        }

        private void AddAutopartsReportsTableHeader(PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase("Autoparts Reports"));
            cell.Colspan = PdfTableSize;
            cell.HorizontalAlignment = 1;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);
        }

        private PdfPTable CreateAutopartsReportsTable()
        {
            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            float[] widths = new float[] { 3f, 3f, 3f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            return table;
        }

      
    }
}