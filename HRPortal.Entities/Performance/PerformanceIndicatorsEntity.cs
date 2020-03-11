using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Performance
{
    [TableName("[Appraisal].[PerformanceIndicators]")]
    [PrimaryKey("PerformanceIndicatorID")]
   public class PerformanceIndicatorsEntity
    {

        public int PerformanceIndicatorID { get; set; }
        public string PerformanceIndicatorName { get; set; }
        public int? PerformanceIndicatorTypeID { get; set; }
        public int? JobID { get; set; }
        public decimal? WeightOrValue { get; set; }
        
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifcationDate { get; set; }
        public bool AxceededValue { get; set; }// 3/2/2020
        public string KRA { get; set; }//  3/2/2020
    }
}
