using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HackathonVinci2.Hubs
{
    public class ResultHub : Hub
    {
        public void Result(string results)
        {
            Clients.All.addNewMessageToPage(results);
        }
    }
}