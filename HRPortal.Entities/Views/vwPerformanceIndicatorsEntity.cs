using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwPerformanceIndicators]")]
    public class vwPerformanceIndicatorEntity
    {
        public bool Active { get; set; }

        public decimal? Competency_Weight { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? JobID { get; set; }

        public string JobName { get; set; }

        public decimal? KPI_Weight { get; set; }

        public int? Level_ID { get; set; }

        public string Level_Name { get; set; }

        public DateTime? ModifcationDate { get; set; }

        public string ModifiedBy { get; set; }

        public int PerformanceIndicatorID { get; set; }

        public string PerformanceIndicatorName { get; set; }

        public int? PerformanceIndicatorTypeID { get; set; }

        public string PerformanceIndicatorTypeName { get; set; }

        public Guid PerformanceIndicatorUID { get; set; }

        public decimal? WeightOrValue { get; set; }

    }
}
