namespace İhaleTakip.Model
{
    public class ElectricityRate : Core.ModelBase
    {
        public double EnergyFund { get; set; }
        public double TRTShare { get; set; }
        public double ElectricityConsumptionTax { get; set; }
        public double KDV { get; set; }
    }
}
