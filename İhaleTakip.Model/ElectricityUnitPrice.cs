
namespace İhaleTakip.Model
{
    using System;

    public class ElectricityUnitPrice : Core.ModelBase
    {
        public int SubscriptionTypeId { get; set; }
        public double DistributionCost { get; set; }
        public double OneTimeEnergyCost { get; set; }
        public DateTime Period { get; set; }
    }
}
