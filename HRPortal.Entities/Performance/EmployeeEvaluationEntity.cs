using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Performance
{
    [TableName("[Appraisal].[EmployeeEvaluation]")]
    [PrimaryKey("EmployeeEvaluationID")]
    public class EmployeeEvaluationEntity
    {
        public int EmployeeEvaluationID { get; set; }

        public Guid EmployeeEvaluationUID { get; set; }

        public int PerformanceSessionID { get; set; }

        public string EmployeeCode { get; set; }

        public int JobID { get; set; }

        public DateTime? EvaluationStartDate { get; set; }

        public DateTime? EvaluationEndDate { get; set; }

        public string EvaluatedBy { get; set; }

        public bool? Active { get; set; }

        public bool? Archived { get; set; }

        public bool? Completed { get; set; }

        public string Notes { get; set; }

    }
}
