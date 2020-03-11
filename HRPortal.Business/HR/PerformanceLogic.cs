using HRPortal.Business.Account;
using HRPortal.Core;
using HRPortal.Entities.Performance;
using HRPortal.Entities.Views;
using HRPortal.Localization;
using HRPortal.ViewModels.HR.Appraisal;
using HRPortal.ViewModels.HR.MyTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Business.HR
{
    public static class PerformanceLogic
    {
        public static List<vwPerformanceSessionEntity> GetAllPerformanceSessions()
        {
            return HRPortalDB.Fetch<vwPerformanceSessionEntity>("ORDER BY PerformanceSessionID DESC");
        }

        public static int CountActiveSessions()
        {
            return HRPortalDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Appraisal.PerformanceSessions WHERE Active=1");
        }

        public static string GetActiveSessionName()
        {
            return HRPortalDB.ExecuteScalar<string>("SELECT TOP(1) PerformanceSessionName FROM [Appraisal].[PerformanceSessions] WHERE Active =1");
        }

        public static ExecResult SaveSession(SessionVM model)
        {
            ExecResult result = new ExecResult();

            try
            {
                PerformanceSessionEntity entity = new PerformanceSessionEntity();

                entity.PerformanceSessionName = model.SessionName;
                entity.Active = true;
                entity.SessionStartedBy = UsersLogic.GetOracleCode();
                entity.SessionStartDate = DateTime.Now;
                entity.Notes = model.Notes;
                HRPortalDB.Insert(entity);

                result.ExecutionCompleted = true;
                result.Message = AppMessages.PerformanceSessionSaved;
                return result;
            }
            catch (Exception Ex)
            {
                result.ExecutionCompleted = false;
                result.Message = Ex.Message;
                result.Exceptions.Add(Ex);
                return result;
            }
        }

        public static ExecResult GetSession(int sessionID)
        {
            ExecResult result = new ExecResult();

            try
            {
                vwPerformanceSessionEntity entity = HRPortalDB.FirstOrDefault<vwPerformanceSessionEntity>("WHERE PerformanceSessionID=@0", sessionID);

                if(entity != null)
                {
                    result.ExecutionCompleted = true;
                    result.ReturnObject = entity;
                }
                else
                {
                    result.ExecutionCompleted = false;
                    result.Message = "No record Found !";
                }
               
                return result;
            }
            catch (Exception Ex)
            {
                result.ExecutionCompleted = false;
                result.Message = Ex.Message;
                result.Exceptions.Add(Ex);
                return result;
            }
        }

        public static List<vwEmployeeEvaluationEntity> GetActiveAppraisals()
        {
            int ActiveSessionID = HRPortalDB.ExecuteScalar<int>("SELECT TOP(1) PerformanceSessionID FROM [Appraisal].[PerformanceSessions] WHERE Active =1");
            List<vwEmployeeEvaluationEntity> activeAppraisals = new List<vwEmployeeEvaluationEntity>();

            List<VMEmp> myEmployees = EmployeesLogic.GetMyEmployees();

            foreach (VMEmp employee in myEmployees)
            {

                vwEmployeeEvaluationEntity employeeEvaluation = HRPortalDB.FirstOrDefault<vwEmployeeEvaluationEntity>("WHERE EmployeeCode=@0 AND PerformanceSessionID=@1", employee.EmployeeCode,ActiveSessionID);

                if(employeeEvaluation!=null)
                {
                    activeAppraisals.Add(employeeEvaluation);

                }
                else
                {
                    EmployeeEvaluationEntity newEmployeeEvaluation = new EmployeeEvaluationEntity();
                    newEmployeeEvaluation.EmployeeEvaluationUID = Guid.NewGuid();
                    newEmployeeEvaluation.PerformanceSessionID = ActiveSessionID;
                    newEmployeeEvaluation.EmployeeCode = employee.EmployeeCode;
                    newEmployeeEvaluation.EvaluatedBy = employee.SupervisorCode;
                    newEmployeeEvaluation.EvaluationStartDate = DateTime.Now;
                    newEmployeeEvaluation.JobID = employee.JobID;
                    newEmployeeEvaluation.Active = true;
                    HRPortalDB.Insert(newEmployeeEvaluation);
                    employeeEvaluation = HRPortalDB.FirstOrDefault<vwEmployeeEvaluationEntity>("WHERE EmployeeCode=@0 AND PerformanceSessionID=@1", employee.EmployeeCode, ActiveSessionID);
                    activeAppraisals.Add(employeeEvaluation);
                }
                
            }

            return activeAppraisals;
        }

        public static List<vwEmployeeEvaluationEntity> GetAllActiveAppraisals()
        {
            int ActiveSessionID = HRPortalDB.ExecuteScalar<int>("SELECT TOP(1) PerformanceSessionID FROM [Appraisal].[PerformanceSessions] WHERE Active =1");
            List<vwEmployeeEvaluationEntity> activeAppraisals = new List<vwEmployeeEvaluationEntity>();

            List<vwEmployeeEntity> employees = EmployeesLogic.GetAllEmployees(true);

            foreach (vwEmployeeEntity employee in employees)
            {

                vwEmployeeEvaluationEntity employeeEvaluation = HRPortalDB.FirstOrDefault<vwEmployeeEvaluationEntity>("WHERE EmployeeCode=@0 AND PerformanceSessionID=@1", employee.EmployeeCode, ActiveSessionID);

                if (employeeEvaluation != null)
                {
                    activeAppraisals.Add(employeeEvaluation);

                }
                else
                {
                    EmployeeEvaluationEntity newEmployeeEvaluation = new EmployeeEvaluationEntity();
                    newEmployeeEvaluation.EmployeeEvaluationUID = Guid.NewGuid();
                    newEmployeeEvaluation.PerformanceSessionID = ActiveSessionID;
                    newEmployeeEvaluation.EmployeeCode = employee.EmployeeCode;
                    newEmployeeEvaluation.EvaluatedBy = employee.SupervisorCode;
                    newEmployeeEvaluation.EvaluationStartDate = null;
                    newEmployeeEvaluation.JobID = employee.JobID.Value;
                    newEmployeeEvaluation.Active = true;
                    HRPortalDB.Insert(newEmployeeEvaluation);
                    employeeEvaluation = HRPortalDB.FirstOrDefault<vwEmployeeEvaluationEntity>("WHERE EmployeeCode=@0 AND PerformanceSessionID=@1", employee.EmployeeCode, ActiveSessionID);
                    activeAppraisals.Add(employeeEvaluation);
                }

            }

            return activeAppraisals;
        }

        public static EvaluateVM GetEmployeeEvaluation(int EmployeeEvaluationID)
        {
            EvaluateVM evaluateVM = new EvaluateVM();

            vwEmployeeEvaluationEntity employeeEvaluation = HRPortalDB.FirstOrDefault<vwEmployeeEvaluationEntity>("WHERE EmployeeEvaluationID=@0",EmployeeEvaluationID);
            vwEmployeeEntity employee = HRPortalDB.FirstOrDefault<vwEmployeeEntity>("WHERE EmployeeCode=@0", employeeEvaluation.EmployeeCode);

            List<vwPerformanceIndicatorEntity> indicators = HRPortalDB.Fetch<vwPerformanceIndicatorEntity>("WHERE Active=1 AND JobID=@0 ORDER BY PerformanceIndicatorTypeID ASC", employeeEvaluation.JobID);

            evaluateVM.EmployeeEvaluationID = EmployeeEvaluationID;
            evaluateVM.EmployeeCode = employee.EmployeeCode;
            evaluateVM.FullName = employee.FullName;
            evaluateVM.PerformanceSessionName = employeeEvaluation.PerformanceSessionName;

            evaluateVM.EmployeeIndicators = new List<vwEmployeePerformanceIndicatorEntity>();

            foreach (vwPerformanceIndicatorEntity item in indicators)
            {
                vwEmployeePerformanceIndicatorEntity empIndicator = HRPortalDB.FirstOrDefault<vwEmployeePerformanceIndicatorEntity>("WHERE EmployeeEvaluationID=@0 AND PerformanceIndicatorID=@1", EmployeeEvaluationID,item.PerformanceIndicatorID);
                if(empIndicator!=null)
                {
                    evaluateVM.EmployeeIndicators.Add(empIndicator);
                }
                else
                {
                    EmployeePerformanceIndicatorEntity newEntity = new EmployeePerformanceIndicatorEntity();
                    newEntity.EmployeeEvaluationID = EmployeeEvaluationID;
                    newEntity.PerformanceIndicatorID = item.PerformanceIndicatorID;
                    HRPortalDB.Insert(newEntity);
                    evaluateVM.EmployeeIndicators.Add(HRPortalDB.FirstOrDefault<vwEmployeePerformanceIndicatorEntity>("WHERE EmployeeEvaluationID=@0 AND PerformanceIndicatorID=@1", EmployeeEvaluationID, newEntity.PerformanceIndicatorID));
                }
            }

            return evaluateVM;
        }

        private static vwEmployeePerformanceIndicatorEntity getOrCreateEmployeePerformanceIndicator()
        {
            return null;
        }

    }
}
