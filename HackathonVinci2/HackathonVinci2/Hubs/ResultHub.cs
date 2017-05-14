using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HackathonVinci2.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string results)
        {
            Clients.All.addNewMessageToPage(results);
        }
    }
}