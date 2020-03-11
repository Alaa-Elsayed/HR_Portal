using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwEmployeeEvaluations]")]
    public partial class vwEmployeeEvaluationEntity
    {
        public bool? Active { get; set; }

        public bool? Archived { get; set; }

        public int? BranchID { get; set; }

        public int? BusinessUnitID { get; set; }

        public int? Competency_Count { get; set; }

        public int? Competency_Score { get; set; }

        public int? Competency_Percentage { get; set; }

        public int? Competency_Total { get; set; }

        public int? Competency_Weight { get; set; }

        public bool? Completed { get; set; }

        public int? DepartmentID { get; set; }

        public int? DivisionID { get; set; }

        public string EmployeeCode { get; set; }

        public int EmployeeEvaluationID { get; set; }

        public Guid EmployeeEvaluationUID { get; set; }

        public string EvaluatedBy { get; set; }

        public string EvaluationEndDate { get; set; }

        public DateTime? EvaluationStartDate { get; set; }

        public string FullName { get; set; }

        public int? JobID { get; set; }

        public string JobName { get; set; }

        public int? KPI_Count { get; set; }

        public int? KPI_Score { get; set; }

        public int? KPI_Total { get; set; }

        public int? KPI_Weight { get; set; }

        public int? KPI_Percentage { get; set; }

        public int? Level_ID { get; set; }

        public string Level_Name { get; set; }

        public string Notes { get; set; }

        public int? PerformanceSessionID { get; set; }

        public string PerformanceSessionName { get; set; }

        public int? SupdivisionID { get; set; }

        public string SupervisorCode { get; set; }

        public string BranchName { get; set; }

        public string BusinessUnitName { get; set; }

        public DateTime? HireDate { get; set; }

        public int? FinalScore { get; set; }

        [PetaPoco.Ignore]
        public string KPIPercent 
        { 
           get
            {
                return string.Format("{0} %", KPI_Percentage ?? 0);
            }
        }

        [PetaPoco.Ignore]
        public string CompetencyPercent
        {
            get
            {
                return string.Format("{0} %", Competency_Percentage ?? 0);
            }
        }

        [PetaPoco.Ignore]
        public string FinalScorePercent
        {
            get
            {
                return string.Format("{0} %", FinalScore ?? 0);
            }
        }



    }
}
