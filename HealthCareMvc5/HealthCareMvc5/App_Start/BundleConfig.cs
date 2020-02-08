using System.Web;
using System.Web.Optimization;

namespace HealthCareMvc5
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
           
            //bundles.Add(new ScriptBundle("~/bundles/jquery-bootstrap").Include(
            //     "~/Contents/js/jQuery/jquery-3.1.1.min.js",
            //         "~/Contents/js/jQueryUI/jquery-ui.min.js",
            //      "~/Contents/js/Bootstrap/js/bootstrap.min.js",
            //     //"~/Contents/Wibrant/DatePicker/js/bootstrap-datepicker.js",
            //     "~/Contents/js/slimScroll/jquery.slimscroll.js",
            //     "~/Contents/js/fastclick/fastclick.js",
            //     "~/Contents/js/Bootstrap-Notify/bootstrap-notify.min.js",
            //     "~/Contents/Mask/jquery.maskedinput.min.js",
            //     "~/Contents/ClockPicker/clockpicker.js",
            //      "~/Contents/js/Multiselect/bootstrap-multiselect.js"
            //  ));

            //bundles.Add(new ScriptBundle("~/bundles/jquery-ChartFile").Include(
            //      "~/Contents/jvectormap/jquery.sparkline.js",
            //  "~/Contents/jvectormap/jquery-jvectormap-1.2.2.min.js",
            //  "~/Contents/jvectormap/jquery-jvectormap-world-mill-en.js",
            //  "~/Contents/js/knob/jquery.knob.js",
            //  "~/Contents/jvectormap/moment.min.js",
            //  "~/Contents/js/daterangepicker/daterangepicker.js",
            //  "~/Contents/jvectormap/bootstrap3-wysihtml5.all.min.js",
            //  "~/Contents/jvectormap/dashboard.js"
            

            //));

            //bundles.Add(new StyleBundle("~/bundles/Styles-ChartFile").Include(
            //  "~/Contents/js/daterangepicker/daterangepicker.css" ,
            //  "~/Contents/jvectormap/jquery-jvectormap-1.2.2.css"

            //));
            //bundles.Add(new StyleBundle("~/bundles/Styles-Bootstrap").Include(
            //    "~/Contents/js/bootstrap/dist/css/bootstrap.min.css",
            //    "~/Contents/DataTables/media/css/jquery.dataTables.min.css",
            //    "~/Contents/DataTables/media/css/dataTables.bootstrap4.min.css",
            //     "~/Contents/css/font-awesome/css/font-awesome.css",
            //      "~/Contents/js/jQuery/jquery-ui.css",
            //    "~/Contents/css/LayOut/AdminLTE.min.css",
            //     "~/Contents/css/LayOut/skins/skin-blue.min.css",
            //    "~/Contents/Wibrant/Wibrant.css",
            //    "~/Contents/Date-Time-Picker/css/bootstrap-datetimepicker.min.css",
            //    "~/Contents/Wibrant/pace-theme-minimal.css"

            //    ));

        }
    }
}
