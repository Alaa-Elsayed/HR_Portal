using System.Web;
using System.Web.Optimization;

namespace HRPortal
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.bundle.js"));


            bundles.Add(new ScriptBundle("~/bundles/jslibs").Include(
                       "~/Scripts/pace.min.js",
                       "~/Content/Plugins/sweetalert2/sweetalert2.js",
                       "~/Content/Plugins/sweetalert2/sweetalert2.js",
                       "~/Content/Plugins/overlayScrollbars/jquery.overlayScrollbars.js",
                       "~/Content/Plugins/toastr/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Content/Plugins/toastr/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
          "~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                      "~/Scripts/adminlte.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/adminlte.css",
                      "~/Content/Plugins/fontawesome/css/all.css",
                      "~/Content/Plugins/sans-serif/css/sans-serif-pro.css",
                      "~/Content/Plugins/pace-progress/pace-theme.css",
                      "~/Content/Plugins/icheck-bootstrap/icheck-bootstrap.css",
                      "~/Content/Plugins/sweetalert2/sweetalert2.css",
                      "~/Content/Plugins/overlayScrollbars/OverlayScrollbars.css",
                      "~/Content/Plugins/toastr/toastr.css"));


            bundles.Add(new StyleBundle("~/bundles/rtlcss").Include(
                      "~/Content/rtl/adminlte-rtl.css",
                      "~/Content/rtl/bootstrap-rtl.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/bootstraprtl").Include(
                      "~/Content/rtl/bootstrap-rtl.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
          "~/Content/rtl/popper.min.js"));
        }
    }
}
