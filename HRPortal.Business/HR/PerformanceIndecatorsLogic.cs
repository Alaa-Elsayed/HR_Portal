using HRPortal.Core;
using HRPortal.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Entities.Performance;
using HRPortal.ViewModels.HR.Appraisal;

namespace HRPortal.Business.HR
{
   public class PerformanceIndecatorsLogic
    {
        public static List<VMPerformanceIndecators>GetAllPerformanceIndecators()
        {
            return HRPortalDB.Fetch<VMPerformanceIndecators>();
        }

        //to sheck total count of KPI&&Comptency 
        public static List<VMPerformanceIndecators> GetAllPerformanceIndecatorsByJobTitle(int? id)  
        {
            return HRPortalDB.Fetch<VMPerformanceIndecators>("WHER JobID =@0",id);
        }
        //public static VMPerformanceIndecators GetKPI(object ID)
        //{
        //    return HRPortalDB.FirstOrDefault<VMPerformanceIndecators>("SELECT * FROM  dbo.vwPerformanceView WHERE PerformanceIndicatorID = @0", ID);
        //}

        public static ExecResult GetKPI(object ID)
        {
            ExecResult result = new ExecResult();

            try
            {
                var entity = HRPortalDB.FirstOrDefault<VMPerformanceIndecators>("WHERE PerformanceIndicatorID=@0", ID);

                if (entity != null)
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


        //For DropDownLists
        //Start
        public static List<vwJobTitleEntity> GetJobTitle()
        {
            return HRPortalDB.Fetch<vwJobTitleEntity>(); 
        }
        public static List<vwJobTitleEntity> GetJobTitleByID(int DepID)
        {
            
            return HRPortalDB.Fetch<vwJobTitleEntity>("where DepartmentID=@0", DepID);
        }
        public static List<vwindicatorTypesEntity> GetIdicatorTypes()
        {
            return HRPortalDB.Fetch<vwindicatorTypesEntity>();
        }
        public static List<vwIndicatorLevelEntity> GetIndicatorLevel() 
        {
            return HRPortalDB.Fetch<vwIndicatorLevelEntity>();
        }
        public static List<vwDepartmentEntity> GetDepartment()
        {
            return HRPortalDB.Fetch<vwDepartmentEntity>();
        }

        //EndDropDownLists

        public static ExecResult UpdateKPI(IndecatorsVM entity)
        {
            ExecResult result = new ExecResult();
            try
            {
                var PerformanceIndicatorsEntity = new PerformanceIndicatorsEntity
                {
                    PerformanceIndicatorID = entity.PerformanceIndicatorID,
                    PerformanceIndicatorName = entity.PerformanceIndicatorName,
                    WeightOrValue = entity.WeightOrValue,
                    Active = entity.Active,
                    JobID = entity.JobID,
                    PerformanceIndicatorTypeID = int.Parse(entity.IndicatorTypeName),
                    
                    ModifiedBy = Account.UsersLogic.GetOracleCode(),
                    ModifcationDate = DateTime.Now,
                    AxceededValue=entity.AxceededValue, // 3/2/2020
                    KRA=entity.KRA  // 3/2/2020
                };
                HRPortalDB.Update(PerformanceIndicatorsEntity);
                result.ExecutionCompleted = true;
                result.Message = "Updated Done";
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
        public static ExecResult CreateKPI(IndecatorsVM entity)
        {
            ExecResult result = new ExecResult();
            try
            {
                var PerformanceIndicatorsEntity = new PerformanceIndicatorsEntity
                {

                    PerformanceIndicatorName = entity.PerformanceIndicatorName,
                    WeightOrValue = entity.WeightOrValue,
                    Active = entity.Active,
                    JobID = int.Parse(entity.JobName),

                    PerformanceIndicatorTypeID = int.Parse(entity.IndicatorTypeName),
                     
                    CreatedBy = Account.UsersLogic.GetOracleCode(),
                    CreationDate = DateTime.Now,
                    AxceededValue = entity.AxceededValue, // 3/2/2020
                    KRA = entity.KRA  // 3/2/2020
                };
                HRPortalDB.Insert(PerformanceIndicatorsEntity);
                result.ExecutionCompleted = true;
                result.Message = "Creation Done";
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
    }

}
