using HRPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Business.Account
{
    public static class UsersLogic
    {
        public static ExecResult IsAuthorized(string username,string password)
        {
            ExecResult result = new ExecResult();

            try
            {
                if(true)
                {
                    result.ExecutionCompleted = true;
                    result.ReturnObject = true;
                    LogLoginAttempt(username,true);
                    return result;
                }
                else
                {
                    result.ExecutionCompleted = false;
                    result.ReturnObject = false;
                    result.Message ="Invalid username or password.";
                    LogLoginAttempt(username, false);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ExecutionCompleted = false;
                result.Exceptions.Add(ex);
                result.Message = ex.Message;

                if (AppSettings.ThrowExceptions)
                    throw;

                return result;
            }

            
        }

        public static bool IsInRole(AppRoles role)
        {
            switch (role)
            {
                case AppRoles.Admin:
                    return true;
                case AppRoles.Employee:
                    return true;
                case AppRoles.Supervisor:
                    if(HRPortalDB.ExecuteScalar<int>("SELECT COUNT(*) FROM Company.Employees WHERE SupervisorCode=@0", GetOracleCode()) > 0)
                        return true;
                    return false;
                case AppRoles.HR:
                    return true;
                case AppRoles.LeadTeam:
                    return true;
                default:
                    return false;
            }
        }

        public static string GetOracleCode()
        {
            return HRPortalDB.ExecuteScalar<string>("SELECT EmployeeCode FROM Company.Employees WHERE Email = @0", ConnectionInfo.UserName);
        }

        public static bool HasPermission(AppPermissions permission)
        {
            return true;
        }

        public static void LogLoginAttempt(string username,bool valid)
        {
            // Log login in db
        }
    }
}
