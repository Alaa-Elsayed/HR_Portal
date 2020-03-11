using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HRPortal.Localization
{
    public static class LocalizationHelper
    {
        private static string _Language = LocalizedLanguages.English;

        public static string CurrentLanguage
        {
            get
            {
                return _Language;
            }

            set
            {
                _Language = value;
                SetCultureInfo(value);
            }
        }

       
        public static void SetCultureInfo(string Language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(Language);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(Language);
        }

        public static bool IsRighToLeft()
        {
            if (CultureInfo.DefaultThreadCurrentCulture != null)
            {
                return CultureInfo.DefaultThreadCurrentCulture.TextInfo.IsRightToLeft;
            }
            else
            {
                return false;
            }

        }
    }
}
