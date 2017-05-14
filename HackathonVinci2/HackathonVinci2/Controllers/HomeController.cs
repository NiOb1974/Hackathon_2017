using System;
using System.Web.Mvc;
using HackathonVinci2.Models;
using HackathonVinci2.Fassade;
using Newtonsoft.Json;

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
        public ActionResult Index(InputModel inputModel)
        {
            // Do something
            var tmp = JsonConvert.SerializeObject(inputModel);
            return RedirectToAction("Result", new { inputModel =tmp});
        }
        
        public ActionResult Result(string inputModel)
        {
            var input = JsonConvert.DeserializeObject<InputModel>(inputModel);
             EventHubClientFacade.SendObject(inputModel);
            ResultModel model = Methods.fillmodel(input);
            return View(model);
        }

    }
}