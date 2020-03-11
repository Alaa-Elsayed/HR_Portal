using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwEmployees]")]
    public  class vwEmployeeEntity
    {
        public bool? Active { get; set; }

        public int? BranchID { get; set; }

        public string BranchName { get; set; }

        public int? BusinessUnitID { get; set; }

        public string BusinessUnitName { get; set; }

        public int? CityID { get; set; }

        public string CityName { get; set; }

        public decimal? Competency_Weight { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public int? DivisionID { get; set; }

        public string DivisionName { get; set; }

        public string Email { get; set; }

        public string EmployeeCode { get; set; }

        public int EmployeeID { get; set; }

        public Guid? EmployeeUID { get; set; }

        public int? EmploymentStatusID { get; set; }

        public string EmploymentStatusName { get; set; }

        public string FullName { get; set; }

        public bool? Gender { get; set; }

        public int? GovernorateID { get; set; }

        public string GovernorateName { get; set; }

        public DateTime? HireDate { get; set; }

        public int? JobID { get; set; }

        public string JobName { get; set; }

        public int? JobTypeID { get; set; }

        public string JobTypeName { get; set; }

        public decimal? KPI_Weight { get; set; }

        public int? Level_ID { get; set; }

        public string Level_Name { get; set; }

        public int? NationalityID { get; set; }

        public string NationalityName { get; set; }

        public string Notes { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string StreetAddress { get; set; }

        public string SubdivisionName { get; set; }

        public int? SupdivisionID { get; set; }

        public string SupervisorCode { get; set; }

        public DateTime? TerminationDate { get; set; }

    }
}
