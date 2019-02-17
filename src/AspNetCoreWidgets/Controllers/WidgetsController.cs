using AspNetCoreWidgets.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreWidgets.Controllers
{
    //[CustomException]
    public class WidgetsController : Controller
    {
        public IActionResult Index(string id)
        {
            return ViewComponent(id);
        }
    }
}