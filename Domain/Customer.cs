using System.Collections.Generic;

namespace Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual List<CarOrder> CarOrder { get; set; }
    }
}