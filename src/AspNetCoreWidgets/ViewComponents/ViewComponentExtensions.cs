using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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
            catch (Exception e) when (!(e.GetType() == typeof(Refit.ApiException) && IsUnauthorized(((Refit.ApiException)e).StatusCode)))
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
            catch (Exception e) when (!(e.GetType() == typeof(Refit.ApiException) && IsUnauthorized(((Refit.ApiException)e).StatusCode)))
            {
                return ReturnErrorView(vc);
            }

        }

        private static void SetViewBagParam(ViewComponent vc)
        {
            vc.ViewData["VC"] = vc.ViewComponentContext.ViewComponentDescriptor.ShortName;
        }

        private static IViewComponentResult ReturnErrorView(ViewComponent vc) => vc.View("../_WidgetError");
        
        private static bool IsUnauthorized(HttpStatusCode statusCode) => 
            statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.Forbidden;

    }
}