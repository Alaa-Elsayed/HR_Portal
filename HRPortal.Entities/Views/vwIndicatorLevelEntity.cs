using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Entities.Views
{
    [TableName("[dbo].[vwIndicatorLevel]")]
    public class vwIndicatorLevelEntity
    {

        public int Level_ID { get; set; }
        public string Level_Name { get; set; }
    }
}
