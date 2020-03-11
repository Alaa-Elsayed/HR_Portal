using System.Web.Mvc;

namespace HRPortal.Areas.HumanResources
{
    public class HRAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HR_default",
                "HR/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HRPortal.Areas.HR.Controllers" }
            ).DataTokens["UseNamespaceFallback"] = true;
        }
    }
}