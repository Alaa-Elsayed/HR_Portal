using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwPerformanceView]")]
   public class VMPerformanceIndecators
    {


        public int PerformanceIndicatorID { get; set; }
        public string PerformanceIndicatorName { get; set; }
        public decimal? WeightOrValue { get; set; }
        public string PerformanceIndicatorTypeName { get; set; }
        public string JobName { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
        public int? JobID { get; set; }
        public int? DepartmentID { get; set; }//new
        public string Level_Name { get; set; }
        public decimal? KPI_Weight { get; set; }
        public decimal? Competency_Weight { get; set; }
        public int? Level_ID { get; set; }
        public int? PerformanceIndicatorTypeID { get; set; }
        public bool AxceededValue { get; set; }// 3/2/2020
        public string KRA { get; set; }//  3/2/2020
    }
}
