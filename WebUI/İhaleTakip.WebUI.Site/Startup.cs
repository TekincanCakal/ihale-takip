namespace İhaleTakip.WebUI.Site
{
    using İhaleTakip.Data;
    using İhaleTakip.Data.Infrastructure.Entities;
    using İhaleTakip.WebUI.Site.Hubs;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationRoot ConfigurationRoot { get; set; }
        public IWebHostEnvironment Environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;

            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
            }

            services.AddSignalR();

            //Config
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddOptions();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            services.AddTransient<UserManager>();
            services.AddTransient<ServiceManager>();
            
            services.AddTransient<ElectricityCompanyData>();
            services.AddTransient<ElectricityBillData>();
            services.AddTransient<ElectricitySubscriberData>();
            services.AddTransient<ElectricitySubscriptionTypeData>();
            services.AddTransient<ElectricityUnitPriceData>();
            services.AddTransient<EmployeeData>();
            services.AddTransient<ElectricityRateData>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;
            });

            services.AddDistributedMemoryCache();
            
            services.Configure<RouteOptions>(routeOptions => routeOptions.AppendTrailingSlash = true);
        }

        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseStatusCodePages();

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseStaticFiles();


            app.UseSession();

            app.UseSignalR(routes =>
            {
                routes.MapHub<OnlineAdminHub>("/onlineAdminHub");
            });

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "servicelogin", template: "ServisBaglan/{serviceName}", defaults: new { controller = "Auth", action = "LoginService" });

                routes.MapRoute(name: "authlogin", template: "Giris", defaults: new { controller = "Auth", action = "Login" });
                routes.MapRoute(name: "authlogout", template: "Cikis", defaults: new { controller = "Auth", action = "Logout" });

                routes.MapRoute(name: "employee", template: "Personeller", defaults: new { controller = "Employee", action = "Index" });
                routes.MapRoute(name: "employeeadd", template: "Personeller/Ekle", defaults: new { controller = "Employee", action = "AddEmployee" });
                routes.MapRoute(name: "employeeupdate", template: "Personeller/Güncelle/{id}", defaults: new { controller = "Employee", action = "UpdateEmployee" });
                routes.MapRoute(name: "employeedelete", template: "Personeller/Sil/{id}", defaults: new { controller = "Employee", action = "DeleteEmployee" });

                routes.MapRoute(name: "electricitycompany", template: "Elektrik/Firmalar", defaults: new { controller = "ElectricityCompany", action = "Index" });
                routes.MapRoute(name: "electricitycompanyadd", template: "Elektrik/Firmalar/Ekle", defaults: new { controller = "ElectricityCompany", action = "AddElectricityCompany" });
                routes.MapRoute(name: "electricitycompanyupdate", template: "Elektrik/Firmalar/Güncelle/{id}", defaults: new { controller = "ElectricityCompany", action = "UpdateElectricityCompany" });
                routes.MapRoute(name: "electricitycompanydelete", template: "Elektrik/Firmalar/Sil/{id}", defaults: new { controller = "ElectricityCompany", action = "DeleteElectricityCompany" });

                routes.MapRoute(name: "electricitybilladd", template: "Elektrik/Faturalar/Ekle", defaults: new { controller = "ElectricityBill", action = "AddElectricityBill" });
                routes.MapRoute(name: "electricitybillupdate", template: "Elektrik/Faturalar/Güncelle/{id}", defaults: new { controller = "ElectricityBill", action = "UpdateElectricityBill" });
                routes.MapRoute(name: "electricitybilldelete", template: "Elektrik/Faturalar/Sil/{id}", defaults: new { controller = "ElectricityBill", action = "DeleteElectricityBill" });

                routes.MapRoute(name: "electricitysubscriber", template: "Elektrik/Abonelikler", defaults: new { controller = "ElectricitySubscriber", action = "Index" });
                routes.MapRoute(name: "electricitysubscriberadd", template: "Elektrik/Abonelikler/Ekle", defaults: new { controller = "ElectricitySubscriber", action = "AddElectricitySubscriber" });
                routes.MapRoute(name: "electricitysubscriberupdate", template: "Elektrik/Abonelikler/Güncelle/{id}", defaults: new { controller = "ElectricitySubscriber", action = "UpdateElectricitySubscriber" });
                routes.MapRoute(name: "electricitysubscriberdelete", template: "Elektrik/Abonelikler/Sil/{id}", defaults: new { controller = "ElectricitySubscriber", action = "DeleteElectricitySubscriber" });

                routes.MapRoute(name: "electricitysubscribertype", template: "Elektrik/AbonelikTürleri", defaults: new { controller = "ElectricitySubscriptionType", action = "Index" });
                routes.MapRoute(name: "electricitysubscribertypeadd", template: "Elektrik/AbonelikTürleri/Ekle", defaults: new { controller = "ElectricitySubscriptionType", action = "AddElectricitySubscriptionType" });
                routes.MapRoute(name: "electricitysubscribertypeupdate", template: "Elektrik/AbonelikTürleri/Güncelle/{id}", defaults: new { controller = "ElectricitySubscriptionType", action = "UpdateElectricitySubscriptionType" });
                routes.MapRoute(name: "electricitysubscribertypedelete", template: "Elektrik/AbonelikTürleri/Sil/{id}", defaults: new { controller = "ElectricitySubscriptionType", action = "DeleteElectricitySubscriptionType" });

                routes.MapRoute(name: "electricityunitprice", template: "Elektrik/BirimFiyatlar", defaults: new { controller = "ElectricityUnitPrice", action = "Index" });
                routes.MapRoute(name: "electricityunitpriceadd", template: "Elektrik/BirimFiyatlar/Ekle", defaults: new { controller = "ElectricityUnitPrice", action = "AddElectricityUnitPrice" });
                routes.MapRoute(name: "electricityunitpriceupdate", template: "Elektrik/BirimFiyatlar/Güncelle/{id}", defaults: new { controller = "ElectricityUnitPrice", action = "UpdateElectricityUnitPrice" });
                routes.MapRoute(name: "electricityunitpricedelete", template: "Elektrik/BirimFiyatlar/Sil/{id}", defaults: new { controller = "ElectricityUnitPrice", action = "DeleteElectricityUnitPrice" });

                routes.MapRoute(name: "electricitytenderreport", template: "Elektrik/Rapor", defaults: new { controller = "ElectricityTenderReport", action = "Index" });
                routes.MapRoute(name: "electricitytenderreportadd", template: "Elektrik/Rapor/Oluştur", defaults: new { controller = "ElectricityTenderReport", action = "CreateTenderReport" });
              
                routes.MapRoute(name: "default", template: "{controller=Auth}/{action=Index}");
            });
        }
    }
}
