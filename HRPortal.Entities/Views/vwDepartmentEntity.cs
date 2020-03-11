using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwDepartment]")]
 public class vwDepartmentEntity
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
