namespace AutopartsSystem.Models
{
    public class Compatibility
    {
        public int Id { get; set; }

        public virtual CarBrand Brand { get; set; }

        public virtual CarModel Model { get; set; }
    }
}