using System.Web;
using System.Web.Optimization;

namespace QLNhaSachFahasa
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-4.4.1/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Home/css").Include(
                        "~/Content/bootstrap-4.4.1/css/bootstrap.css",
                        "~/Content/bootstrap.css",
                          "~/Content/main.css",
                     "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                     "~/Content/custom/HomePage.css"));
           
            bundles.Add(new StyleBundle("~/Login/css").Include(
                       "~/Content/bootstrap-4.4.1/css/bootstrap.css",
                       "~/Content/bootstrap.css",
                         "~/Content/main.css",
                    "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                    "~/Content/custom/LoginPage.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                        "~/Content/main.css",
                      "~/Content/site.css"));
        }
    }
}
