using System.Web.Mvc;

namespace BornToCode.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult AllArticles()
        {
            return View("Index");
        }
    }
}