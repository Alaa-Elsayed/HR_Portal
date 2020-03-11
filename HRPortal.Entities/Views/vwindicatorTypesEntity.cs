using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwindicatorTypes]")]
   public class vwindicatorTypesEntity
    {
        public int PerformanceIndicatorTypeID { get; set; }
        public string PerformanceIndicatorTypeName { get; set; }
    }
}
