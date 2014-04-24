using CV.WebApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //:STC: Begin
        public ActionResult SetCulture(string culture)    
        {        
            // Validate input        
            culture = CultureHelper.GetImplementedCulture(culture);        
            
            // Save culture in a cookie        
            HttpCookie cookie = Request.Cookies["_culture"];        
            if (cookie != null)            
                cookie.Value = culture;  // update cookie value        
            else        
            {            
                cookie = new HttpCookie("_culture");                            
                cookie.Value = culture;            
                cookie.Expires = DateTime.Now.AddYears(1);        
            }        
            Response.Cookies.Add(cookie);        
            return RedirectToAction("Index");    
        }    
        //:STC: End
    }
}