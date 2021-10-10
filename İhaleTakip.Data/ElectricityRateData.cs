namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Data.Infrastructure.Entities;
    using Microsoft.Extensions.Options;

    public class ElectricityRateData : EntityBaseData<Model.ElectricityRate>
    {
        public ElectricityRateData(IOptions<DatabaseSettings> dbOptions) : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
