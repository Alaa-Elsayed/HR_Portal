using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwPerformanceSessions]")]
    [PrimaryKey("PerformanceSessionID")]
    public partial class vwPerformanceSessionEntity
    {
        public bool? Active { get; set; }

        public bool? Archived { get; set; }

        public string Notes { get; set; }

        public int PerformanceSessionID { get; set; }

        public string PerformanceSessionName { get; set; }

        public int? SessionClosedBy { get; set; }

        public string SessionClosedByCode { get; set; }

        public string SessionClosedByEmail { get; set; }

        public string SessionClosedByName { get; set; }

        public DateTime? SessionEndDate { get; set; }

        public DateTime? SessionStartDate { get; set; }

        public int? SessionStartedBy { get; set; }

        public string SessionStartedByCode { get; set; }

        public string SessionStartedByEmail { get; set; }

        public string SessionStartedByName { get; set; }

        public string PublishedStatus { get; set; }
        public string Status { get; set; }

    }
   
}
