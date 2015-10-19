namespace AutopartsSystem.Core.Parsers.Excel
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using Common;

    public class XlsReader
    {
        public IEnumerable<string> ProvideContent(string filePath, string sheetName, IEnumerable<string> columnOrder)
        {
            var contentToReturn = new List<string>();
            var currentRow = new StringBuilder();

            Dictionary<string, string> props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            props["Data Source"] = filePath;
            props["Extended Properties"] = "Excel 8.0";

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            string properties = sb.ToString();

            using (OleDbConnection conn = new OleDbConnection(properties))
            {
                conn.Open();
                DataSet ds = new DataSet();
                string columns = string.Join(",", columnOrder.ToArray());
                using (OleDbDataAdapter da = new OleDbDataAdapter(
                    "SELECT " + columns + " FROM [" + sheetName + "$]", conn))
                {
                    DataTable dt = new DataTable("temp");

                    da.Fill(dt);
                    var allRows = dt.Rows;
                    for (int i = 0; i < allRows.Count; i++)
                    {
                        var currentRowElements = allRows[i].ItemArray;
                        if (!string.IsNullOrEmpty(currentRowElements[0].ToString()))
                        {
                            currentRow.Append(currentRowElements[0].ToString());
                            currentRow.Append(Constants.DividerForExcelRead);
                            currentRow.Append(currentRowElements[1].ToString());
                            currentRow.Append(Constants.DividerForExcelRead);
                            currentRow.Append(currentRowElements[2].ToString());
                            currentRow.Append(Constants.DividerForExcelRead);
                            currentRow.Append(currentRowElements[3].ToString());
                            currentRow.Append(Constants.DividerForExcelRead);
                            currentRow.Append(currentRowElements[4].ToString());
                            currentRow.Append(Constants.DividerForExcelRead);
                            currentRow.Append(currentRowElements[5].ToString());

                            contentToReturn.Add(currentRow.ToString());
                            currentRow.Clear();
                        }
                    }

                    ds.Tables.Add(dt);
                }
            }

            return contentToReturn;
        }
    }
}
