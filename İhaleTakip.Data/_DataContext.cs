namespace İhaleTakip.Data
{
    using İhaleTakip.Data.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(new DbContextOptionsBuilder().UseMySQL(connectionString).Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach(var entityType in builder.Model.GetEntityTypes())
            {
                foreach(var property in entityType.GetProperties())
                {
                    if(property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }
        }

        public DbSet<Model.ElectricityCompany> ElectricityCompanies { get; set; }
        public DbSet<Model.Employee> Employees { get; set; }
        public DbSet<Model.ElectricityBill> ElectricityBills { get; set; }
        public DbSet<Model.ElectricitySubscriber> ElectricitySubscribers { get; set; }
        public DbSet<Model.ElectricitySubscriptionType> ElectricitySubscriptionTypes { get; set; }
        public DbSet<Model.ElectricityUnitPrice> ElectricityUnitPrices { get; set; }
        public DbSet<Model.ElectricityRate> ElectricityRates { get; set; }
    }
}
