using System.Web;
using System.Web.Optimization;

namespace TPWEB1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/vendor/jquery-1.11.0.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
           

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/vendor/modernizr-2.6.1-respond-1.1.0.min.js",
                        "~/Scripts/vendor/jquery-1.11.0.min.js"
                         ));

            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/plugins.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/animate.css",
                      "~/Content/templatemo_misc.css",
                      "~/Content/templatemo_style.css",
                      "~/Content/fonts.googleapis.css"));

            
        }
    }
}
