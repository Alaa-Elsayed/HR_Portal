using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwJobTitle]")]
    public class vwJobTitleEntity
    {
        public int JobID { get; set; }
        public string JobName { get; set; } 
        public int DepartmentID { get; set; } 
    }
}
