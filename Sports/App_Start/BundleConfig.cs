using System.Web.Optimization;

namespace Sports
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/table").Include(
                    "~/Content/table.min.css"));

            bundles.Add(new StyleBundle("~/Content/add-player").Include(
                 "~/Content/add-player.min.css",
                 "~/Content/bootstrap-datetimepicker.min.css"));

            ///---------------------------------Script Bundles-----------------------------------------------------------------///
           
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

            bundles.Add(new ScriptBundle("~/bundles/add-player").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/add-player.js"));

            bundles.Add(new ScriptBundle("~/bundles/team").Include(
                     "~/Scripts/team.js"));

            bundles.Add(new ScriptBundle("~/bundles/team-coach-players").Include(
                    "~/Scripts/team-coach-players.js"));

            bundles.Add(new ScriptBundle("~/bundles/add-team").Include(
                   "~/Scripts/jquery.validate.js",
                   "~/Scripts/jquery.validate.unobtrusive.js"));

               bundles.Add(new ScriptBundle("~/bundles/players").Include(
                   "~/Scripts/players.js"));
        }
    }
}
