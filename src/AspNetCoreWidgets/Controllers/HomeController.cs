﻿using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWidgets.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
