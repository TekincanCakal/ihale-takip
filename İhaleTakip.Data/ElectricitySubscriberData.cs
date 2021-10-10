namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Data.Infrastructure.Entities;
    using Microsoft.Extensions.Options;

    public class ElectricitySubscriberData : EntityBaseData<Model.ElectricitySubscriber>
    {
        public ElectricitySubscriberData(IOptions<DatabaseSettings> dbOptions) : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
