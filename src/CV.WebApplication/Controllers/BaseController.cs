using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CV.WebApplication.Controllers
{
    using CV.WebApplication.Helpers;

    /// <summary>
    /// BaseController class for ASP.Net MVC Internationalization.
    /// The BaseController class inspects cookie contents. If there is no cookie, 
    /// the "Accept-Language" field sent by their browser is used.
    /// For more information, see Nadeem Afana's blog at http://afana.me/post/aspnet-mvc-internationalization.aspx.
    /// </summary>
    public class BaseController : Controller
    {    
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)    
        {
            string cultureName = "de";
            //string cultureName = null;                 
            
            //// Attempt to read the culture cookie from Request                    
            //HttpCookie cultureCookie = Request.Cookies["_culture"];        
            //if (cultureCookie != null)           
            //    cultureName = cultureCookie.Value;        
            //else            
            //    cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?                     
            //        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages                    
            //        null;        
            
            //// Validate culture name        
            //cultureName = CultureHelper.GetImplementedCulture(cultureName);          
            
            // Modify current thread's cultures                    
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);        
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;                 
            return base.BeginExecuteCore(callback, state);    
        }
    }
}