using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreWidgets.ViewComponents
{
    [ViewComponent]
    public class Widget1 : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return this.ErrorViewAsync(async () =>
            {
                await Task.Delay(0); // Simulating async
                return View();
            });
        }
    }
}