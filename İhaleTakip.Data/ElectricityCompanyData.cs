namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Data.Infrastructure.Entities;
    using Microsoft.Extensions.Options;

    public class ElectricityCompanyData : EntityBaseData<Model.ElectricityCompany>
    {
        public ElectricityCompanyData(IOptions<DatabaseSettings> dbOptions) : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
