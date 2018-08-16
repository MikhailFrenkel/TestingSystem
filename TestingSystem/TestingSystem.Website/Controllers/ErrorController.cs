using System.Web.Mvc;
using NLog;

namespace TestingSystem.Website.Controllers
{
    [Authorize(Roles = "admin")]
    public class ErrorController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public ActionResult NotFound()
        {
            _logger.Error(Request.Url + " - not found.");
            Response.StatusCode = 404;
            ViewBag.Message = "Error 404. Page not found";
            return View("~/Views/Error/Error.cshtml");
        }

        public ActionResult BadRequest()
        {
            _logger.Error(Request.Url + " - bad request.");
            Response.StatusCode = 400;
            ViewBag.Message = "Error 400. BadRequest";
            return View("~/Views/Error/Error.cshtml");
        }

        public ActionResult InternalServerError()
        {
            _logger.Error(Request.Url + " - Internal server error.");
            Response.StatusCode = 500;
            ViewBag.Message = "Error 500. Internal server error";
            return View("~/Views/Error/Error.cshtml");
        }
    }
}