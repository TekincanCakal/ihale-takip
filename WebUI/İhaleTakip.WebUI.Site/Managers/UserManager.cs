namespace İhaleTakip.WebUI.Site.Managers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Hubs;
    using İhaleTakip.WebUI.Site.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum Perm
    {
        Admin, Observer
    }

    public class UserManager
    {
        private IHubContext<OnlineAdminHub> _hubContext;
        private IHttpContextAccessor _httpContextAccessor;
        private ISession _session;
        private ServiceManager _serviceManager;
        private EmployeeData _employeeData;

        public static List<string> LoginedUsers = new List<string>();
        public static Dictionary<string, ServiceLoginModel> ServiceLoginedUsers = new Dictionary<string, ServiceLoginModel>();

        public UserManager(IHttpContextAccessor httpContextAccessor, ServiceManager serviceManager, EmployeeData employeeData, IHubContext<OnlineAdminHub> hubContext)
        {
            _hubContext = hubContext;
            _employeeData = employeeData;
            _serviceManager = serviceManager;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        
        public bool IsCurrentUserLogined()
        {
            return _session.GetString("Username") != null;
        }

        public bool IsCurrentUserLoginService()
        {
            return (_session.GetString("Service") != null && _session.GetString("Perm") != null);
        }

        public string GetCurrentUserName()
        {
            if (IsCurrentUserLogined())
            {
                return _session.GetString("Username");
            }
            else
            {
                return null;
            }
        }
        
        public Employee GetCurrentUser()
        {
            if (IsCurrentUserLogined())
            {
                string username = GetCurrentUserName();
                var employeeResult = _employeeData.FirstOrDefault(x => x.Username == username);
                if (!employeeResult.IsSucced)
                {
                    throw new Exception(employeeResult.Message);
                }

                Employee employee = employeeResult.Data;

                if(employee == null)
                {
                    throw new Exception("Veritabanındaki Yapılan Elle Değişiklik Sebebiyle Oluşan Sistem Hatası");
                }

                return employee;
            }
            else
            {
                throw new Exception("Bu İşlem İçin Giriş Yapman Gerekli");
            }
        }

        public ServiceLoginModel GetCurrentUserLoginService()
        {
            if (IsCurrentUserLoginService())
            {
                return new ServiceLoginModel
                {
                    Service = (Service)Enum.Parse(typeof(Service), _session.GetString("Service")),
                    Perm = (Perm)Enum.Parse(typeof(Perm), _session.GetString("Perm"))
                };
            }
            else
            {
                return null;
            }
        }

        public void SuccessLoginCurrentUser(string username)
        {
            if (!LoginedUsers.Contains(username))
            {
                _session.SetString("Username", username);
                LoginedUsers.Add(username);
                OnUserLogin(username);
            }
            else
            {
                throw new Exception("Bu Hesaba Şuanda Birisi Bağlı Durumda");
            }
        }
        
        public void LogoutCurrentUser()
        {
            if (IsCurrentUserLogined())
            {
                string username = GetCurrentUserName();
                if (IsCurrentUserLoginService())
                {
                    ServiceLoginModel oldStatus = GetCurrentUserLoginService();
                    if (oldStatus.Perm == Perm.Admin)
                    {
                        _serviceManager.SetServiceStatus(oldStatus.Service, false);
                    }
                    ServiceLoginedUsers.Remove(username);
                }
                LoginedUsers.Remove(username);
                OnUserLogout(username);
            }
            else
            {
                throw new Exception("Bu İşlem İçin Giriş Yapmanız Gerekmektedir");
            }
        }

        public void OnUserLogin(string username)
        {
            foreach (var x in LoginedUsers)
            {
                if(x != username)
                {
                    var connections = OnlineAdminHub.ActiveUsers.GetConnections(x);
                    foreach (var cid in connections)
                    {
                        _hubContext.Clients.Client(cid).SendAsync("userLoginLogout", username, true);
                    }
                }
            }
        }

        public void OnUserLogout(string username)
        {
            foreach (var x in LoginedUsers)
            {
                if (x != username)
                {
                    var connections = OnlineAdminHub.ActiveUsers.GetConnections(x);
                    foreach (var cid in connections)
                    {
                        _hubContext.Clients.Client(cid).SendAsync("userLoginLogout", username, false);
                    }
                }
            }
        }

        public ServiceModel LoginServiceCurrentUser(string serviceName)
        {
            if (IsCurrentUserLogined())
            {
                string username = GetCurrentUserName();
                if (serviceName != null)
                {
                    ServiceModel service = _serviceManager.getServiceByName(serviceName);
                    if (service.Enabled)
                    {
                        bool getNewServiceStatus = _serviceManager.GetServiceStatus(service.Name);

                        if (IsCurrentUserLoginService())
                        {
                            ServiceLoginModel currentService = GetCurrentUserLoginService();
                            if (currentService.Service == service.Name)
                            {
                                if (!_serviceManager.GetServiceStatus(currentService.Service))
                                {
                                    _session.SetString("Service", service.Name.ToString());
                                    ServiceLoginedUsers[username] = new ServiceLoginModel
                                    {
                                        Service = service.Name,
                                        Perm = Perm.Admin
                                    };
                                    _serviceManager.SetServiceStatus(service.Name, true);
                                    _session.SetString("Perm", Perm.Admin.ToString());
                                }
                                else
                                {
                                    throw new Exception("Zaten Bu Servise Bağlısınız");
                                }
                            }
                            else
                            {
                                if (currentService.Perm == Perm.Admin)
                                {
                                    _serviceManager.SetServiceStatus(currentService.Service, false);
                                }

                                _session.SetString("Service", service.Name.ToString());
                                if (getNewServiceStatus)
                                {
                                    ServiceLoginedUsers[username] = new ServiceLoginModel
                                    {
                                        Service = service.Name,
                                        Perm = Perm.Observer
                                    };
                                    _session.SetString("Perm", Perm.Observer.ToString());
                                }
                                else
                                {
                                    ServiceLoginedUsers[username] = new ServiceLoginModel
                                    {
                                        Service = service.Name,
                                        Perm = Perm.Admin
                                    };
                                    _serviceManager.SetServiceStatus(service.Name, true);
                                    _session.SetString("Perm", Perm.Admin.ToString());
                                }
                            }

                            return service;
                        }
                        else
                        {
                            _session.SetString("Service", service.Name.ToString());
                            if (getNewServiceStatus)
                            {
                                ServiceLoginedUsers.Add(username, new ServiceLoginModel
                                {
                                    Service = service.Name,
                                    Perm = Perm.Observer
                                });
                                _session.SetString("Perm", Perm.Observer.ToString());
                            }
                            else
                            {
                                ServiceLoginedUsers.Add(username, new ServiceLoginModel
                                {
                                    Service = service.Name,
                                    Perm = Perm.Admin
                                });
                                _serviceManager.SetServiceStatus(service.Name, true);
                                _session.SetString("Perm", Perm.Admin.ToString());
                            }
                            return service;
                        }
                    }
                    else
                    {
                        throw new Exception("Aktif Olmayan Bir Service Bağlanmaya Çalıştınız");
                    }
                }
                else
                {
                    throw new Exception("Bağlanmak İstediğiniz Service İsmini Girmediniz");
                }
            }
            else
            {
                throw new Exception("Bu İşlem İçin Giriş Yapmanız Gerekmektedir");
            }
        }

        public bool IsUserLogined(string username)
        {
            return LoginedUsers.Contains(username);
        }

        public bool IsUserLoginedService(string username)
        {
            return ServiceLoginedUsers.ContainsKey(username);
        }

        public ServiceLoginModel GetUserLoginService(string username)
        {
            if (IsUserLoginedService(username))
            {
                ServiceLoginModel serviceLoginModel;
                ServiceLoginedUsers.TryGetValue(username, out serviceLoginModel);
                return serviceLoginModel;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetOnlineUsers()
        {
            return LoginedUsers.ToList();
        }

        public List<string> GetServiceLoginedUsers()
        {
            List<string> serviceLoginedUsers = new List<string>();
            foreach(var x in ServiceLoginedUsers)
            {
                serviceLoginedUsers.Add(x.Key);
            }
            return serviceLoginedUsers;
        }

        public Perm GetServicePerm(Service service)
        {
            if (IsCurrentUserLogined())
            {
                if (IsCurrentUserLogined())
                {
                    ServiceLoginModel serviceLoginModel = GetCurrentUserLoginService();
                    if (serviceLoginModel.Service == service)
                    {
                        return serviceLoginModel.Perm;
                    }
                    else
                    {
                        throw new Exception("Bu İşlem İçin " + service.ToString() + " Servisine Bağlanman Gerekli");
                    }
                }
                throw new Exception("Bu İşlem İçin " + service.ToString() + " Servisine Bağlanman Gerekli");
            }
            else
            {
                throw new Exception("Bu İşlem İçin Giriş Yapman Gerekli");
            }
        }
    }
}
