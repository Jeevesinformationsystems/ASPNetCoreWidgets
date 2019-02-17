using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace AspNetCoreWidgets
{

    /// <summary>
    /// Middleware to get new token from Jeeves Server if it is expired but has valid authentication 
    /// </summary>
    public class TokenMiddleware
    {

        #region PrivateFields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next is beginning with a Request and ending with a Response.</param>
        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Method InvokeAsync 
        /// <summary>
        /// Invoke method which takes an HttpContext and returns a Task asynchronously.
        /// </summary>
        /// <param name="context">The context  is an object that wraps all http related information into one place.</param>
        /// <returns>returns the task.</returns>
        public async Task InvokeAsync(HttpContext context)
        {

            // calls the next middlware to execute.
            //try
            {
                await _next(context);
            }
           // catch (Exception e) when (e.GetType()==typeof(NotImplementedException))
            {
                //Server Exceptions
                //Difficult string manipulations of request path then call next once again

            }
            //catch(Exception e)
            {
                //eApproval exceptons
            }
        }

        #endregion

        #region Private Methods

        private static bool IsUnauthorized(HttpStatusCode statusCode) =>
            statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.Forbidden;
        private static void RedirectToLogin(HttpContext context)
        {

            var returnUrl = $"{context.Request.PathBase.Value}{HttpUtility.HtmlEncode(context.Request.Path.Value)}";
            if (returnUrl.Contains("Logout", StringComparison.InvariantCultureIgnoreCase))
                returnUrl = $"{context.Request.PathBase.Value}/";

            // Redirect to the Login view, supplying the returnURL specified in the original request.
            context.Response.Redirect($"{context.Request.PathBase.Value}/Account/Login?returnUrl={returnUrl}");

        }

        private static void RedirectToHome(HttpContext context)
        {
            context.Response.Redirect($"{context.Request.PathBase.Value}/");
        }

        #endregion

    }
}
