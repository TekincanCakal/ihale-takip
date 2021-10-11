namespace İhaleTakip.WebUI.Site.Managers
{
    using İhaleTakip.WebUI.Site.Hubs;
    using İhaleTakip.WebUI.Site.Models;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum Service
    {
        Electricity, Water, Gas, Internet, Employee
    }

    public class ServiceManager
    {
        private IHubContext<OnlineAdminHub> _hubContext;

        public ServiceManager(IHubContext<OnlineAdminHub> hubContext)
        {
            _hubContext = hubContext;
            foreach (Service x in Enum.GetValues(typeof(Service)))
            {
                if (!ServiceStatus.ContainsKey(x))
                {
                    ServiceStatus.Add(x, false);
                }
            }
        }

        public static Dictionary<Service, bool> ServiceStatus = new Dictionary<Service, bool>();

        public static List<ServiceModel> Services = new List<ServiceModel>
        {
            new ServiceModel{ Name = Service.Employee, TrName="Personel", Enabled = true, InitController="Employee", InitAction="Index", MenuPartialViewName=null },
            new ServiceModel{ Name = Service.Electricity, TrName="Elektrik", Enabled = true, InitController = "ElectricitySubscriber", InitAction = "Index", MenuPartialViewName = "_ElectricityMenu" },
            new ServiceModel{ Name = Service.Internet, TrName="İnternet", Enabled = false },
            new ServiceModel{ Name = Service.Water, TrName="Su", Enabled = false },
            new ServiceModel{ Name = Service.Gas, TrName="Doğalgaz", Enabled = false }
        };

        public ServiceModel getServiceByName(string serviceName)
        {
            foreach (ServiceModel service in Services)
            {
                if (service.Name.ToString().ToLower() == serviceName.ToLower())
                {
                    return service;
                }
            }
            return null;
        }

        public ServiceModel getService(Service service)
        {
            foreach (ServiceModel x in Services)
            {
                if (x.Name == service)
                {
                    return x;
                }
            }
            return null;
        }

        public void SetServiceStatus(Service service, bool newValue)
        {
            ServiceStatus[service] = newValue;
            UpdateServiceStatus();
        }

        public bool GetServiceStatus(Service service)
        {
            return ServiceStatus[service];
        }

        public void UpdateServiceStatus()
        {
            foreach (var x in UserManager.ServiceLoginedUsers)
            {
                bool status = ServiceStatus[x.Value.Service];

                var connections = OnlineAdminHub.ActiveUsers.GetConnections(x.Key);
                if (!status)
                {
                    foreach (var cid in connections)
                    {
                        _hubContext.Clients.Client(cid).SendAsync("updateService", $"<a class='text-decoration-none text-white' href='/ServisBaglan/{x.Value.Service}'>Yönetici Moduna Geçmek İçin Tıkla</a>");
                    }
                }
                else
                {
                    foreach (var cid in connections)
                    {
                        _hubContext.Clients.Client(cid).SendAsync("updateService", "");
                    }
                }
            }
        }
    }
}
