using HackathonVinci2.Hubs;
using HackathonVinci2.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackathonVinci2.Controllers.API
{
    public class ResultDataController : ApiController
    {
        [HttpGet]
        public void Get(string json)
        {
            var test = JsonConvert.DeserializeObject<resultTestModel>(json);
            var context = GlobalHost.ConnectionManager.GetHubContext<ResultHub>();
            context.Clients.All.addNewMessageToPage(json);
            //SIGNALR to RESULTPAGE
        }
    }
}
