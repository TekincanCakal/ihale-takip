using İhaleTakip.WebUI.Site.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace İhaleTakip.WebUI.Site.Hubs
{
    public class OnlineAdminUser
    {
        public string Username { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    public class OnlineAdminHub : Hub
    {
        private ServiceManager _serviceManager;

        public static ConcurrentDictionary<string, OnlineAdminUser> ActiveUsers = new ConcurrentDictionary<string, OnlineAdminUser>();

        public OnlineAdminHub(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string username = Context.GetHttpContext().Session.GetString("Username");
            if(username != null)
            {
                string connectionId = Context.ConnectionId;

                OnlineAdminUser user;
                ActiveUsers.TryGetValue(username, out user);

                if (user != null)
                {
                    lock (user.ConnectionIds)
                    {
                        user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                        if (!user.ConnectionIds.Any())
                        {
                            OnlineAdminUser removedUser;
                            ActiveUsers.TryRemove(username, out removedUser);
                        }
                    }
                    ActiveUsers[username] = user;
                }
                _serviceManager.UpdateServiceStatus();
            }
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Session.GetString("Username");
            if (username != null)
            {
                string connectionId = Context.ConnectionId;

                var user = ActiveUsers.GetOrAdd(username, _ => new OnlineAdminUser
                {
                    Username = username,
                    ConnectionIds = new HashSet<string>()
                });

                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.Add(connectionId);
                }
                _serviceManager.UpdateServiceStatus();
            }
            return base.OnConnectedAsync();
        }
    }
}
