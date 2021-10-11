namespace İhaleTakip.WebUI.Site.Hubs
{
    using İhaleTakip.WebUI.Site.Managers;
    using İhaleTakip.WebUI.Site.Models;
    using İhaleTakip.WebUI.Site.Utils;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class OnlineAdminHub : Hub
    {
        private ServiceManager _serviceManager;

        public readonly static ConnectionMapping<string> ActiveUsers =new ConnectionMapping<string>();

        public OnlineAdminHub(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string username = Context.GetHttpContext().Session.GetString("Username");
            if(username != null)
            {
                ActiveUsers.Remove(username, Context.ConnectionId);
                var Session = Context.GetHttpContext().Session;
                var client = Clients;
                Task.Delay(5000).ContinueWith(t =>
                {
                    var connections = ActiveUsers.GetConnections(username);
                    if (!connections.Any() && UserManager.LoginedUsers.Contains(username))
                    {
                        bool IsCurrentUserLoginService = (Session.GetString("Service") != null && Session.GetString("Perm") != null);
                        if (IsCurrentUserLoginService)
                        {
                            ServiceLoginModel oldStatus = new ServiceLoginModel
                            {
                                Service = (Service)Enum.Parse(typeof(Service), Session.GetString("Service")),
                                Perm = (Perm)Enum.Parse(typeof(Perm), Session.GetString("Perm"))
                            };
                            if (oldStatus.Perm == Perm.Admin)
                            {
                                _serviceManager.SetServiceStatus(oldStatus.Service, false);
                            }
                            UserManager.ServiceLoginedUsers.Remove(username);
                        }
                        UserManager.LoginedUsers.Remove(username);
                        foreach (var x in UserManager.LoginedUsers)
                        {
                            var tempConnections = ActiveUsers.GetConnections(x);

                            foreach (var cid in tempConnections)
                            {
                                client.Client(cid).SendAsync("userLoginLogout", username, false);
                            }
                        }
                    }
                });
            }
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Session.GetString("Username");
            if(username != null)
            {
                ActiveUsers.Add(username, Context.ConnectionId);
            }
            return base.OnConnectedAsync();
        }
    }
}
