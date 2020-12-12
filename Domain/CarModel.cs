using System.Collections.Generic;

namespace Domain
{
    public class CarModel : Entity
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public bool IsAvailable { get; set; }
        public virtual List<CarTrim> CarTrims { get; set; }
    }
}