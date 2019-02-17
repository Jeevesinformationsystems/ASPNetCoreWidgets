using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace AspNetCoreWidgets.Filters
{
    public class CustomExceptionAttribute : TypeFilterAttribute
    {
        public CustomExceptionAttribute() : base(typeof(CustomExceptionFilter))
        {
        }
        private class CustomExceptionFilter : IAsyncExceptionFilter, IAlwaysRunResultFilter
        {
            public Task OnExceptionAsync(ExceptionContext context)
            {   
                context.Result = new ViewResult { ViewName = "_WidgetErrorPage" }; ;
                return Task.CompletedTask;
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {

            }

            public void OnResultExecuting(ResultExecutingContext context)
            {

            }
        }
    }
}
