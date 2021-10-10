namespace İhaleTakip.Model
{
    using System;

    public class ElectricitySubscriber : Core.ModelBase
    {
        public string InstallationNumber { get; set; }
        public string ContractNumber { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public string SubscriberStatus { get; set; }
        public string ExtraInformation { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}