using System.Web;
using System.Web.Optimization;

namespace Todo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css"));

            bundles.UseCdn = true;   //enable CDN support

            //add link to jquery on the CDN
            var jqueryCdnPath = "https://code.jquery.com/jquery-2.1.4.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include("~/Scripts/vendor/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Scripts/vendor").Include(
                "~/Scripts/vendor/bootstrap.min.js", 
                "~/Scripts/vendor/angular.min.js",
                "~/Scripts/vendor/angular-route.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/app").Include(
                "~/Scripts/app/app.js",
                "~/Scripts/app/factories/*.js",
                "~/Scripts/app/controllers/*.js"
                ));


            #if DEBUG
                    BundleTable.EnableOptimizations = false;
            #else
                    BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}