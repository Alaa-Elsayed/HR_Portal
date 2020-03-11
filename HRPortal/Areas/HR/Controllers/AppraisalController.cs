using HRPortal.Business.Account;
using HRPortal.Business.HR;
using HRPortal.Controllers;
using HRPortal.Core;
using HRPortal.ViewModels.HR.Appraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HRPortal.Entities.Views;
using System.Configuration;

namespace HRPortal.Areas.HumanResources.Controllers
{
    [Authorize]
    public class AppraisalController : BaseController
    {
    
        public ActionResult Sessions()
        {
            if(UsersLogic.IsInRole(Core.AppRoles.HR))
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied","Account", new { area = "HR" });
            }
            
        }

        public ActionResult EditSession(int? id)
        {
            if (UsersLogic.IsInRole(Core.AppRoles.HR))
            {
                if(id!=null)
                {
                    SessionVM model = new SessionVM();
                    ExecResult result = PerformanceLogic.GetSession(id.Value);
                    if(result.ExecutionCompleted)
                    {
                        vwPerformanceSessionEntity entity = (vwPerformanceSessionEntity)result.ReturnObject;
                        model.SessionID = entity.PerformanceSessionID;
                        model.SessionName = entity.PerformanceSessionName;
                        model.StartDate = entity.SessionStartDate;
                        model.StartedBy = entity.SessionStartedByName;
                        model.Active = entity.Active;
                        model.EndDate = entity.SessionEndDate;
                        model.ClosedBy = entity.SessionClosedByName;
                        model.Notes = entity.Notes;
                        return View(model);
                    }
                    else
                    {
                        ShowMessage(result.Message, MessagType.Warning);
                        return RedirectToAction("Sessions", "Appraisal", new { area = "HR" });
                    }
                    
                }
                else
                {
                    if (PerformanceLogic.CountActiveSessions() > 0)
                    {
                        ShowMessage("Only 1 active session allowed.", MessagType.Warning);
                        return RedirectToAction("Sessions", "Appraisal", new { area = "HR" });
                    }
                    else
                    {
                        return View();
                    }

                }

            }
            else
            {
                return RedirectToAction("AccessDenied", "Account", new { area = "HR" });
            }
        }

        [HttpPost]
        public ActionResult EditSession(SessionVM model)
        {
            if (ModelState.IsValid)
            {
                if(model.SessionID is null)
                {
                    ExecResult result = PerformanceLogic.SaveSession(model);
                    if(result.ExecutionCompleted)
                    {
                        ShowMessage(result.Message, MessagType.Success);
                        return RedirectToAction("Sessions", "Appraisal", new { area = "HR" });
                    }
                    else
                    {
                        ShowMessage(result.Message, MessagType.Error);
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
               
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

        public ActionResult KPIs()
        {
            return View();
        }

        public ActionResult EditeOrCreateKPIs(int? Id)
        {

            if (Id == null)
            {

                ViewBag.JobTitle = new SelectList(PerformanceIndecatorsLogic.GetJobTitle(), "JobID", "JobName");
                ViewBag.Department = new SelectList(PerformanceIndecatorsLogic.GetDepartment(), "DepartmentID", "DepartmentName");
                ViewBag.IndicatorType = new SelectList(PerformanceIndecatorsLogic.GetIdicatorTypes(), "PerformanceIndicatorTypeID", "PerformanceIndicatorTypeName");
                //ViewBag.IndicatorLevel = new SelectList(PerformanceIndecatorsLogic.GetIndicatorLevel(), "Level_ID", "Level_Name");
                return View();
            }
            else
            {
                ViewBag.IndicatorType = new SelectList(PerformanceIndecatorsLogic.GetIdicatorTypes(), "PerformanceIndicatorTypeID", "PerformanceIndicatorTypeName");

                ExecResult entity = PerformanceIndecatorsLogic.GetKPI(Id);
                if (entity.ExecutionCompleted)
                {

                    var model =(VMPerformanceIndecators)entity.ReturnObject;
                    var Indecatorsmodel = new IndecatorsVM
                    {
                        PerformanceIndicatorID = model.PerformanceIndicatorID,
                        PerformanceIndicatorName = model.PerformanceIndicatorName,
                        WeightOrValue = model.WeightOrValue,
                        JobName = model.JobName,
                        DepartmentName = model.DepartmentName,
                        IndicatorTypeName = model.PerformanceIndicatorTypeID.ToString(),
                        Active = model.Active,
                        JobID = model.JobID, 
                        PerformanceIndicatorTypeID = model.PerformanceIndicatorTypeID,
                        DepartmentID=model.DepartmentID,
                        AxceededValue=model.AxceededValue,//  3/2/2020
                        KRA=model.KRA //  3/2/2020
                    };
                    return View(Indecatorsmodel);
                }
                else
                {
                    ShowMessage(entity.Message, MessagType.Warning);
                    return RedirectToAction("KPIs", "Appraisal", new { area = "HR" });
                }

            }
        }
        [HttpPost]
        public ActionResult EditeOrCreateKPIs(IndecatorsVM Entity)
        {
            if (ModelState.IsValid)
            {
                ExecResult result;
                if (Entity.PerformanceIndicatorID != 0)
                {
                    result = PerformanceIndecatorsLogic.UpdateKPI(Entity);
                }
                else
                {
                    result = PerformanceIndecatorsLogic.CreateKPI(Entity);
                }

                if (result.ExecutionCompleted)
                {
                    ShowMessage(result.Message, MessagType.Success);
                    return RedirectToAction("KPIs", "Appraisal", new { area = "HR" });
                }
                else
                {
                    ShowMessage(result.Message, MessagType.Error);
                    return View(Entity);
                }

            }

            return View(Entity);
        }

        [HttpGet]
        public JsonResult GetJobTitle(int DepartmentID)
        {
          
            List<vwJobTitleEntity> JobList = PerformanceIndecatorsLogic.GetJobTitleByID(DepartmentID);
            return Json(JobList, JsonRequestBehavior.AllowGet);
        }

    }
}