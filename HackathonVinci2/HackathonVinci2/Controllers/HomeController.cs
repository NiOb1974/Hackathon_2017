using HackathonVinci2.Utils;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using HackathonVinci2.Models;
using HackathonVinci2.Fassade;

namespace HackathonVinci2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            var dummyInputModel = new InputModel()
            {
                Profile = "Solarfarm"
            };
            EventHubClientFacade.SendObject(dummyInputModel);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}