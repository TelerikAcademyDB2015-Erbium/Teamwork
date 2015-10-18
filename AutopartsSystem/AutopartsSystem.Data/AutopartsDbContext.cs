using AutopartsSystem.Models;

namespace AutopartsSystem.Data
{
    using System.Data.Entity;

    public class AutopartsDbContext : DbContext
    {
        public AutopartsDbContext() : base("CarPartsSystem")
        {   
        }

        public virtual IDbSet<AutoPart> AutoParts { get; set; }

        public virtual IDbSet<CarBrand> CarBrands { get; set; }
        
        public virtual IDbSet<CarModel> CarModels { get; set; }
        
        public virtual IDbSet<Compatibility> Compatibilities { get; set; }
        
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        
        public virtual IDbSet<PartType> PartTypes { get; set; } 
    }
}
