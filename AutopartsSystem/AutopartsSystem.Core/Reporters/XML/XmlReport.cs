namespace AutopartsSystem.Core.Reporters.XML
{
    using System.Linq;
    using System.Xml.Linq;
    using AutopartsSystem.Core.Common;
    using AutopartsSystem.Data;

    public class XmlReport
    {
        public void GenerateAutoPartReport()
        {
            var db = new AutopartsDbContext();
            var entries = db.AutoParts.ToList();

            XElement autoParts = new XElement("AutoParts");

            foreach (var entry in entries)
            {
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

            autoParts.Save(Constants.PathToFiles + "/" + "AutoParts.xml");
        }
    }
}
