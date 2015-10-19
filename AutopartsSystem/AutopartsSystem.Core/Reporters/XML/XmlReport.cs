using System.Linq;
using AutopartsSystem.Core.Common;
using AutopartsSystem.Data;

namespace AutopartsSystem.Core.Reporters.XML
{
    using System.Xml.Linq;
    public class XmlReport
    {
        public void GenerateAutoPartReport()
        {
            var db = new AutopartsDbContext();
            var entries = db.AutoParts.ToList();
            // Create a root node
            XElement autoParts = new XElement("AutoParts");

            foreach (var entry in entries)
            {
                // Add child nodes
                XElement name = new XElement("Name", entry.Name);
                XElement manufacturer = new XElement("Manufacturer", entry.Manufacturer.Name);
                XElement model = new XElement("Model", entry.Compatibility.Model);
                XElement price = new XElement("Price", entry.Price);
                XElement quantity = new XElement("Quantity", entry.Quantity);
                XElement autoPart = new XElement("AutoPart");
                autoPart.Add(name);
                autoPart.Add(manufacturer);
                autoPart.Add(model);
                autoPart.Add(price);
                autoPart.Add(quantity);
                autoParts.Add(autoPart);
            }
            
            autoParts.Save(Constants.PathToFiles + "/" +  "AutoParts.xml");
        }
    }
}
