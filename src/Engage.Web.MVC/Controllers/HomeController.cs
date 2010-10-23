using System.Web.Mvc;

namespace Engage.Web.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "EngageLib Demo";
            ViewData["Message"] = "EngageLib Demo";

            return View();
        }
    }
}