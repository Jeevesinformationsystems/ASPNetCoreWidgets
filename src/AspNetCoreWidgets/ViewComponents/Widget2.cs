using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreWidgets.ViewComponents
{
    [ViewComponent]
    public class Widget2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //throw new System.Exception();
            return this.ErrorView(() =>
              {
                  throw new System.NotImplementedException();
                  //return View();
              });
        }
    }
}