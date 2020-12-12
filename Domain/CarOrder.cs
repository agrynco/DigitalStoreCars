using System;

namespace Domain
{
    public class CarOrder : Entity
    {
        public DateTime Created { get; set; }
        public string ModelName { get; set; }
        public string TrimName { get; set; }
        public string Engine { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public int Price { get; set; }
        public int BankLoanDuration { get; set; }
        public decimal BankLoanDownPayment { get; set; }
        public decimal BankLoanMonthlyPayment { get; set; }
        
        public virtual Customer Customer { get; set; }
        public long CustomerId { get; set; }
    }
}