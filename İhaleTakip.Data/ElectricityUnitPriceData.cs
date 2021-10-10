namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Data.Infrastructure.Entities;
    using Microsoft.Extensions.Options;

    public class ElectricityUnitPriceData : EntityBaseData<Model.ElectricityUnitPrice>
    {
        public ElectricityUnitPriceData(IOptions<DatabaseSettings> dbOptions) : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
