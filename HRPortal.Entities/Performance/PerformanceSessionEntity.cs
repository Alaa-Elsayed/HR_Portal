using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Performance
{
    [TableName("[Appraisal].[PerformanceSessions]")]
    [PrimaryKey("PerformanceSessionID")]
    public  class PerformanceSessionEntity
    {
        public bool? Active { get; set; }

        public bool? Archived { get; set; }

        public string Notes { get; set; }

        public int PerformanceSessionID { get; set; }

        public string PerformanceSessionName { get; set; }

        public string SessionClosedBy { get; set; }

        public DateTime? SessionEndDate { get; set; }

        public DateTime? SessionStartDate { get; set; }

        public string SessionStartedBy { get; set; }

    }
}
