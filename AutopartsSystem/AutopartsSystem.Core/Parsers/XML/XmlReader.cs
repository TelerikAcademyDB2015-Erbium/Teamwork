using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AutopartsSystem.Core.Common;

namespace AutopartsSystem.Core.Parsers.XML
{
    public class XmlReader
    {
        public IList<string> XMLToStringSet(string pathToFile, IList<string> columnOrder)
        {
            var output = new List<string>();
            var currentRow = new StringBuilder();

            XElement xelement = XElement.Load(pathToFile);
            IEnumerable<XElement> entries = xelement.Elements();

            foreach (var entry in entries)
            {
                currentRow.Append(entry.Element("Name").Value);
                currentRow.Append(Constants.DividerForExcelRead);
                currentRow.Append(entry.Element("Description").Value);
                currentRow.Append(Constants.DividerForExcelRead);
                currentRow.Append(entry.Element("Price").Value);
                currentRow.Append(Constants.DividerForExcelRead);
                currentRow.Append(entry.Element("Compatibility").FirstAttribute.Value);
                currentRow.Append(Constants.DividerForExcelRead);
                currentRow.Append(entry.Element("Manufacturer").FirstAttribute.Value);
                currentRow.Append(Constants.DividerForExcelRead);
                currentRow.Append(entry.Element("Type").Value);

                output.Add(currentRow.ToString());
                currentRow.Clear();

            }
            return output;
        }
    }
}
