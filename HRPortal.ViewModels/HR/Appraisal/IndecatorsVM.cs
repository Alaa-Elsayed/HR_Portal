using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.ViewModels.HR.Appraisal
{
   public class IndecatorsVM 
    {
        public int PerformanceIndicatorID { get; set; }
        [Required]
        [Display(Name = "Indicator Name")]
        public string PerformanceIndicatorName { get; set; }
        [Required]
        [Display(Name = "Value")]
        public decimal? WeightOrValue { get; set; }
        [Required]
        [Display(Name = "Indicator Type")]
        public string IndicatorTypeName { get; set; }
        [Required]
        [Display(Name = "Jop Title")]
        public string JobName { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        public bool Active { get; set; }

        public int? PerformanceIndicatorTypeID { get; set; }
        public int? JobID { get; set; }
        public int? DepartmentID { get; set; } //new
        public bool AxceededValue { get; set; }// 3/2/2020
        public string KRA { get; set; }//  3/2/2020
    }
}
