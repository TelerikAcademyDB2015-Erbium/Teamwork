namespace AutopartsSystem.Core.Reporters.XML
{
    using System.Linq;
    using System.Xml.Linq;
    using AutopartsSystem.Core.Common;
    using AutopartsSystem.Data;

    public class XmlReport
    {
        public void GenerateAutoPartReport(string path)
        {
            var db = new AutopartsDbContext();
            var entries = db.AutoParts.ToList();

            XElement autoParts = new XElement("AutoParts");

            foreach (var entry in entries)
            {
                XElement autoPart = new XElement("AutoPart");
                XElement name = new XElement("Name", entry.Name);
                XElement description = new XElement("Description", entry.Description);
                XElement type = new XElement("Type", entry.Type.Id);
                XElement manufacturer = new XElement("Manufacturer", entry.Manufacturer.Name);
                XAttribute manId = new XAttribute("ID", entry.Manufacturer.Id);
                manufacturer.Add(manId);
                XElement compatibility = new XElement("Compatibility");
                XAttribute compatibilityId = new XAttribute("ID", entry.Compatibility.Id);
                compatibility.Add(compatibilityId);
                XElement model = new XElement("Model", entry.Compatibility.Model.Model);
                XElement brand = new XElement("Model", entry.Compatibility.Brand.Brand);
                XElement price = new XElement("Price", entry.Price);
                XElement quantity = new XElement("Quantity", entry.Quantity);
                
                autoPart.Add(name);
                autoPart.Add(description);
                autoPart.Add(type);
                autoPart.Add(manufacturer);
                compatibility.Add(brand);
                compatibility.Add(model);
                autoPart.Add(compatibility);
                autoPart.Add(price);
                autoPart.Add(quantity);
                autoParts.Add(autoPart);
            }

            autoParts.Save(path);
        }
    }
}
