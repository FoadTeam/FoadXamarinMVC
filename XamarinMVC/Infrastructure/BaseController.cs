using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinMVC.Infrastructure
{
    public class BaseController : System.Web.Mvc.Controller
    {
        static BaseController()
        {
            System.Globalization.CultureInfo oculture = new System.Globalization.CultureInfo("fa-IR");
            //System.Globalization.CultureInfo oculture = new System.Globalization.CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentUICulture = oculture;
            System.Threading.Thread.CurrentThread.CurrentCulture = oculture;
        }

    }
}