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
            try
            {
                await _next(context);
            }
            catch (Exception e) when (e.GetType() == typeof(NotImplementedException))
            {
                //Server Exceptions
                //Difficult string manipulations of request path then call next once again

            }
            catch (Exception)
            {
                //eApproval exceptons
            }
        }

        #endregion

    }
}
