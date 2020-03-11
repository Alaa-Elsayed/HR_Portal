using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace HRPortal.Core
{
    public static class ConnectionInfo
    {
        public static string GetExternalIPv4()
        {
            try
            {
                string externalIP;
                externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(externalIP)[0].ToString();
                return externalIP;
            }
            catch
            {
                return null;
            }
        }

        public static string GetUserMachineName()
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(HttpContext.Current.Request.UserHostName);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            catch
            {
                return null;
            }
        }

        public static string GetBrowserName()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }

        public static string GetBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }

        public static string GetBrowserPlatform()
        {
            return HttpContext.Current.Request.Browser.Platform;
        }

        public static string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    var identity = new GenericIdentity(ticket.Name);
                    var principal = new GenericPrincipal(identity, null);
                    return principal.Identity.Name;
                }
                else
                {
                    return HttpContext.Current.User.Identity.Name;
                }
            }
        }

        

    }
}
