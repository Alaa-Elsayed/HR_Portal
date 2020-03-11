using HRPortal.Core;
using HRPortal.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Business.HR
{
    public static class EmployeesLogic
    {
        public static  List<vwEmployeeEntity> GetAllEmployees(bool ActiveOnly)
        {
            if(ActiveOnly)
            {
                return HRPortalDB.Fetch<vwEmployeeEntity>("WHERE Active = 1");
            }
            else
            {
                return HRPortalDB.Fetch<vwEmployeeEntity>();

            }
        }

        public static List<VMEmp> GetMyEmployees()
        {
            return HRPortalDB.Fetch<VMEmp>("WHERE SupervisorCode=@0", Account.UsersLogic.GetOracleCode());
        }
    }
}
