namespace İhaleTakip.Model
{
    using System;

    public class ElectricityBill : Core.ModelBase
    {
        public string InstallationNumber { get; set; }
        public DateTime Period { get; set; }
        public double Amount { get; set; }
        public double Debt { get; set; }
    }
}