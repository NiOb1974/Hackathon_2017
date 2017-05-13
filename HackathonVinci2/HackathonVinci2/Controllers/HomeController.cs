using System;
using System.Web.Mvc;
using HackathonVinci2.Models;
using HackathonVinci2.Fassade;

namespace HackathonVinci2.Controllers
{
    public class HomeController : Controller
    {
        Guid LastId = Guid.Empty;

        public ActionResult Index()
        {
            return View(new InputModel());
        }

        [HttpPost]
        public RedirectResult Index(InputModel inputModel)
        {
            // Do something
            EventHubClientFacade.SendObject(inputModel);
            return Redirect("/Result/");
        }

        public ActionResult About()
        {
            var dummyInputModel = new InputModel();
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