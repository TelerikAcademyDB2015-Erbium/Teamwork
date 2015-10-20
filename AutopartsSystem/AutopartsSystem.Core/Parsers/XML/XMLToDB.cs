using System.Collections.Generic;
using AutopartsSystem.Core.Parsers.Excel;

namespace AutopartsSystem.Core.Parsers.XML
{
    public class XMLToDB
    {
        public void ParseXmlToDb(string pathToFile, IList<string> columnOrder)
        {
            var reader = new XmlReader();
            var content = reader.XMLToStringSet(pathToFile, columnOrder);
            var parser = new StringSetToAutoPart();
            parser.InsertDataIntoDB(content,columnOrder);
        }
    }
}
