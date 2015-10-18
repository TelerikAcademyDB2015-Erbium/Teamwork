namespace AutopartsSystem.Models
{
    using System;

    public class AutoPart
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PartType Type { get; set; }

        public Compatibility Compatibility { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? BuiltOn { get; set; }

        public DateTime? SoldOn { get; set; }
    }
}
