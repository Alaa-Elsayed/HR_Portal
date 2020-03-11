using System;
using Syncfusion.Licensing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HRPortal.Localization;
using HRPortal.Core;

namespace HRPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzcyZTM0MmUzMEo3d0xZRU5aMXErU0NOL2h3TkhKd0dXUlRhQkZTSllHczJ2WFJpZjdKMlE9");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            //HttpCookie cultureCookie = HttpContext.Current.Request.Cookies["_hrportalCulture"];

            //if (AppSettings.CurrentLanguage == null)
            //{
            //    LocalizationHelper.SetResourcesCultureInfo(LocalizedLanguages.English);
            //}
            //else
            //{
            //    LocalizationHelper.SetResourcesCultureInfo(AppSettings.CurrentLanguage);
            //}

            //LocalizationHelper.SetResourcesCultureInfo(AppSettings.CurrentLanguage);
        }
    }
}
