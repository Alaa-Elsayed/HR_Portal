using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Performance
{
    [TableName("[Appraisal].[EmployeePerformanceIndicators]")]
    [PrimaryKey("EmployeeIndicatorID")]
    public partial class EmployeePerformanceIndicatorEntity
    {
        public int? EmployeeEvaluationID { get; set; }

        public int EmployeeIndicatorID { get; set; }

        public DateTime? ModificationDate { get; set; }

        public int? ModifiedBy { get; set; }

        public string Notes { get; set; }

        public decimal? OldWeightOrValue { get; set; }

        public int? PerformanceIndicatorID { get; set; }

        public decimal? WeightOrValue { get; set; }

    }
}
