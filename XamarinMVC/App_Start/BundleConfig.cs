using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace XamarinMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.12.1.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're  
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.  
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                  "~/Scripts/jquery.validate.min.js",
                                  "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            /////////////////////////Account//////////////////////////
            bundles.Add(new StyleBundle("~/Content/AccountFA").Include(
                      "~/Content/bootstrap-rtl.min.css",
                      "~/Content/AccountStyle-rtl.css"));

            bundles.Add(new StyleBundle("~/Content/AccountEN").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/AccountStyle.css"));
            /////////////////////////Account//////////////////////////
            ////////////////////Admin/////////////////////////////
            bundles.Add(new StyleBundle("~/Content/AdminFA").Include(
                      "~/Content/bootstrap-rtl.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/AdminStyle-rtl.css"));

            bundles.Add(new StyleBundle("~/Content/AdminEN").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/AdminStyle.css"));
            ////////////////////Admin/////////////////////////////////////\
            ////////////////////Site/////////////////////////////
            bundles.Add(new StyleBundle("~/Content/SiteFA").Include(
                      "~/Content/bootstrap-rtl.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/SiteStyle-rtl.css"));

            bundles.Add(new StyleBundle("~/Content/SiteEN").Include(
                      "~/Content/bootstrap-rtl.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/SiteStyle.css"));
            ////////////////////Site/////////////////////////////////////
            ///////////////////////////////Jquery//////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/BootStrapEN").Include(
                        "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/BootStrapFA").Include(
                       "~/Scripts/bootstrap-rtl.min.js",
                      "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/SiteScript").Include(
                       "~/Scripts/SiteScript.js"));

        }
    }
}