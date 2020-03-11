using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vmEmployees]")]
     public class VMEmployees
     {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public int JobID { get; set; }
        public int BranchID { get; set; }
        public string SupervisorCode { get; set; } 
        public int DepartmentID { get; set; }
        public bool? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string StreetAddress { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int NationalityID { get; set; }
        public int EmploymentStatusID { get; set; }
        public int GovernorateID { get; set; }
        public int CityID { get; set; }
        public bool? Active { get; set; }
        public int Notes { get; set; } 
     }


    [TableName("[dbo].[vmEMPData]")]
    public class VMEmp
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string BranchName { get; set; }
        public string SupervisorCode { get; set; }
        public string BusinessUnitName { get; set; }
        public string DepartmentName { get; set; }
        public bool? Gender { get; set; }
        public string GenderStat { get; set; }
        public DateTime HireDate { get; set; }
        public bool? Active { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; } 
    }
}
