using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmitWebApp.Controllers
{
    
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)

        {
            var statuscoderesult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMsg = "Sorry, the resource you requested could not be found";
                    ViewBag.ErrorCode=statusCode;
                    logger.LogWarning($"404 Error Occured. Path={statuscoderesult.OriginalPath}" + 
                        $"and QueryString={statuscoderesult.OriginalQueryString}");
                    break;
                    default:
                    break;
            }
            return View("NotFound");
        }

        //[Route("Error")]
        public IActionResult Error()
        {
           var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
           // logger.LogError($"The path {exceptionDetails.Path} threw an Exception"+$"{exceptionDetails.Error}");
            return View("N_Error");
        }
    }
}
