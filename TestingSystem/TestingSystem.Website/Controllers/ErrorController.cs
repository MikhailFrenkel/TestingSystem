using System.Web.Mvc;

namespace TestingSystem.Website.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            return View();
        }
    }
}