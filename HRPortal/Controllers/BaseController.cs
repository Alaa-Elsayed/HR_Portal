using HRPortal.Core;
using HRPortal.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.Controllers
{
    [Authorize]
    public partial class BaseController : Controller
    {
        public void ShowMessage(string message)
        {
            TempData["ShowMessage"] = true;
            TempData["MessageType"] = (int)MessagType.Info;
            TempData["Message"] = message;
        }

        public void ShowMessage(string message, MessagType type)
        {
            TempData["ShowMessage"] = true;
            TempData["MessageType"] = (int)type;
            TempData["Message"] = message;
        }

        public void ShowToast(string message)
        {
            TempData["ShowToast"] = true;
            TempData["ToastType"] = MessagType.Info.ToString().ToLower();
            TempData["ToastMessage"] = message;
        }

        public void ShowToast(string message, MessagType type)
        {
            TempData["ShowToast"] = true;
            TempData["ToastType"] = type.ToString().ToLower();
            TempData["ToastMessage"] = message;
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            return base.BeginExecuteCore(callback, state);
        }
    }
}