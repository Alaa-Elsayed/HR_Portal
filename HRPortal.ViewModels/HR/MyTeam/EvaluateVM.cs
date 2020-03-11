using HRPortal.Entities.Performance;
using HRPortal.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.ViewModels.HR.MyTeam
{
    public class EvaluateVM
    {
        public int EmployeeEvaluationID { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public string PerformanceSessionName { get; set; }

        public List<vwEmployeePerformanceIndicatorEntity> EmployeeIndicators { get; set; }

    }
}
