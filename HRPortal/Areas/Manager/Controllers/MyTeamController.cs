using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Business.HR;
using HRPortal.Controllers;
using HRPortal.Core;
using HRPortal.Entities.Performance;
using HRPortal.ViewModels.HR.MyTeam;

namespace HRPortal.Areas.Manager.Controllers
{
    [Authorize]
    public class MyTeamController : BaseController
    {
        
        public ActionResult Evaluate(int ID)
        {
            EvaluateVM model = PerformanceLogic.GetEmployeeEvaluation(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Evaluate(EvaluateVM model)
        {
            if(ModelState.IsValid)
            {
                
                foreach (var item in model.EmployeeIndicators)
                {
                    EmployeePerformanceIndicatorEntity indicator = HRPortalDB.FirstOrDefault<EmployeePerformanceIndicatorEntity>("WHERE EmployeeIndicatorID=@0",item.EmployeeIndicatorID);
                    indicator.WeightOrValue = item.WeightOrValue;
                    indicator.ModificationDate = DateTime.Now;
                    HRPortalDB.Update(indicator);
                }


                return RedirectToAction("Appraisals", "MyTeam", new { area = "Manager" });
            }
            else
            {
                return View(model);

            }
        }
        public ActionResult Appraisals()
        {
            return View();
        }

        public ActionResult Employees()
        {
           
            return View();
        }
    }
}