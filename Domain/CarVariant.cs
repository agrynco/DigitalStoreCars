namespace Domain
{
    public class CarVariant : Entity
    {
        public string Engine { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public virtual CarTrim CarTrim { get; set; }
        public long CarTrimId { get; set; }
    }
}