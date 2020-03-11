using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.ViewModels.HR.MyTeam
{
    public class EmployeeAppraisalRow
    {
        public int EmployeeID { get; set; }

        public int EmployeeEvaluationID { get; set; }

        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string JobName { get; set; }
        public string BranchName { get; set; }
        public string BusinessUnitName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime HireDate { get; set; }

        public string EvaluationStarted { get; set; }

        public DateTime? EvaluationStartDate { get; set; }

        public string EvaluationCompleted { get; set; }

        public DateTime? EvaluationEndDate { get; set; }



    }
}
