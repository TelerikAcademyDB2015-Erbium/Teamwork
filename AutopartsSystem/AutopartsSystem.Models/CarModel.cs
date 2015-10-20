namespace AutopartsSystem.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public virtual CarBrand Brand { get; set; }

        public string Model { get; set; }
    }
}