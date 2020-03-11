using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwEmployeePerformanceIndicators]")]
    public partial class vwEmployeePerformanceIndicatorEntity
    {
        public bool? Completed { get; set; }

        public string EmployeeCode { get; set; }

        public int? EmployeeEvaluationID { get; set; }

        public int EmployeeIndicatorID { get; set; }

        public string EvaluatedBy { get; set; }

        public string EvaluationEndDate { get; set; }

        public DateTime? EvaluationStartDate { get; set; }

        public int? JobID { get; set; }

        public DateTime? ModificationDate { get; set; }

        public int? ModifiedBy { get; set; }

        public decimal? OldWeightOrValue { get; set; }

        public int? PerformanceIndicatorID { get; set; }

        public string PerformanceIndicatorName { get; set; }

        public int? PerformanceIndicatorTypeID { get; set; }

        public string PerformanceIndicatorTypeName { get; set; }

        public int? PerformanceSessionID { get; set; }

        public string PerformanceSessionName { get; set; }

        public string SessionClosedBy { get; set; }

        public DateTime? SessionEndDate { get; set; }

        public DateTime? SessionStartDate { get; set; }

        public string SessionStartedBy { get; set; }

        public decimal? WeightOrValue { get; set; }

        public int IndicatorWeightOrValue { get; set; }

    }
}
