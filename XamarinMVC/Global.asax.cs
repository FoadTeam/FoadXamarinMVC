using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XamarinMVC.App_Start;

namespace XamarinMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Application_AcquireRequestState(object sender,
EventArgs e)
        {

            string culture;
            HttpCookie cookie = Request.Cookies["UserLanguage"];
            if (cookie != null && cookie.Value != null
               && cookie.Value.Trim() != string.Empty)
                culture = cookie.Value;
            else
                culture = "fa-IR";

            //Default Language/Culture for all number, Date format  
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR");

            //Ui Culture for Localized text in the UI  
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo(culture);
        }
    }
}
