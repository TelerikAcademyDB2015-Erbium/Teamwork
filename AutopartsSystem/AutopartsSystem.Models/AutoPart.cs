namespace AutopartsSystem.Models
{
    using System;
    using System.Data.Entity.Migrations.Model;

    public class AutoPart
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual PartType Type { get; set; }

        public virtual Compatibility Compatibility { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public DateTime? BuiltOn { get; set; }

        public DateTime? SoldOn { get; set; }   
    }
}
