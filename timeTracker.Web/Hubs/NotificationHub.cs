using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace timeTracker.Web.Hubs
{
   
    public class NotificationHub : Hub
    {
        public void Send()
        {
            Clients.All.notifyUsers();
        }
    }
}