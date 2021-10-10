namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Data.Infrastructure.Entities;
    using Microsoft.Extensions.Options;

    public class EmployeeData : EntityBaseData<Model.Employee>
    {
        public EmployeeData(IOptions<DatabaseSettings> dbOptions) : base(new DataContext(dbOptions.Value.ConnectionString))
        {

        }
    }
}
