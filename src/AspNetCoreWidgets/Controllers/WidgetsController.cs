using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWidgets.Controllers
{
    public class WidgetsController : Controller
    {
        public IActionResult Index(string id) => ViewComponent(id);
    }
}