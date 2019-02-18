using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreWidgets.ViewComponents
{
    public static class ViewComponentExtensions
    {
        public static IViewComponentResult ErrorView(this ViewComponent vc, Func<IViewComponentResult> view)
        {
            SetViewBagParam(vc);
            try
            {
                return view();
            }
            catch
            {
                return ReturnErrorView(vc);
            }

        }


        public static async Task<IViewComponentResult> ErrorViewAsync(this ViewComponent vc, Func<Task<IViewComponentResult>> view)
        {
            SetViewBagParam(vc);
            try
            {
                return await view();
            }
            catch
            {
                return ReturnErrorView(vc);
            }

        }

        private static void SetViewBagParam(ViewComponent vc)
        {
            vc.ViewData["VC"] = vc.ViewComponentContext.ViewComponentDescriptor.ShortName;
        }
        private static IViewComponentResult ReturnErrorView(ViewComponent vc)
        {
            return vc.View("../_WidgetError");
        }
    }
}