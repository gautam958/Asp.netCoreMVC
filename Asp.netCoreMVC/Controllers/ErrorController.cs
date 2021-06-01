using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        { 
            var exception = HttpContext.Features.Get <IExceptionHandlerFeature>();
            if (exception != null)
            {
                ViewBag.Errors = exception.Error.ToString();
            }
            return View();
        }
    }
}
