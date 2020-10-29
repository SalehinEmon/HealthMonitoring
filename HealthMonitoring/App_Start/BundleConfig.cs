using System.Web;
using System.Web.Optimization;

namespace HealthMonitoring
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            //Jquery UI includes

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-1.12.1/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryui/css").Include(
                "~/Scripts/jquery-ui-1.12.1/jquery-ui.min.css"));

            bundles.Add(new StyleBundle("~/Content/LoginStyle").Include(
                "~/Content/LogInStyle.css"));

            bundles.Add(new StyleBundle("~/Content/ProfileStyle").Include(
                "~/Content/ProfileStyle.css"));

            //chart js includes


            bundles.Add(new ScriptBundle("~/Scripts/chartjs").Include(
                "~/Scripts/ChartJs/Chart.min.js"));
            bundles.Add(new StyleBundle("~/Content/ChartJs").Include(
                "~/Content/ChartJs/Chart.min.css"));
        }
    }
}
