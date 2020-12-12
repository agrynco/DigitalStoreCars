using System.Collections.Generic;

namespace Domain
{
    public class CarTrim : Entity
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public virtual CarModel CarModel { get; set; }
        public long CarModelId { get; set; }
        public virtual List<CarVariant> CarVariants { get; set; }
    }
}