using System.Web.Mvc;

namespace TestingSystem.Website.Controllers
{
    [Authorize(Roles = "admin")]
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.Message = "Error 404. Page not found";
            return View("~/Views/Error/Error.cshtml");
        }

        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            ViewBag.Message = "Error 400. BadRequest";
            return View("~/Views/Error/Error.cshtml");
        }
    }
}