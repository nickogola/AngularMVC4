﻿using System.Web;
using System.Web.Optimization;

namespace Soccer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            //          "~/Scripts/angular.js",
            //          "~/Scripts/angular/app.js",
            //          "~/Scripts/angular/Controllers/FootballCtrl.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                  "~/Scripts/angular.js",
                "~/Scripts/angular/app.js",
                "~/Scripts/angular/Controllers/FootballCtrl.js",
                 "~/Scripts/jquery.min.js",
		         "~/Scripts/skel.min.js",
		         "~/Scripts/skel-panels.min.js",
                 "~/Scripts/bootstrap-lightbox.js",
                 "~/Scripts/bootstrap-lightbox.min.js",
                 "~/Scripts/init.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/skel-noscript.css",
                     "~/Content/style.css",
                     "~/Content/style-wide.css",
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap-lightbox.css",
                     "~/Content/bootstrap-lightbox.min.css",
                      "~/Content/site.css"));
        }
    }
}
