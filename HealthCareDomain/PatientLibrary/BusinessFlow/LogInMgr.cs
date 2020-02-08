using PatientLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthCareObjects.UserRights;

namespace PatientLibrary.BusinessFlow
{
    public class LogInMgr
    {
        
        public List<Login1> ListOrganizationName()
        {
            LogInDA objOrg = new LogInDA();
            return objOrg.ListOrganizationName();
        }

        public Login1 MyUserName(string UserName, string Password)
        {
            string DecPassword = string.Empty;
            LogInDA objLogin = new LogInDA();
            DecPassword = LogInMgr.GetEncryptedData(Password);
            return objLogin.MyHome(UserName, DecPassword);
        }

        private static string GetEncryptedData(string sourceData)
        {
            if (!string.IsNullOrEmpty(sourceData))
            {
                byte[] sourceBytes = ASCIIEncoding.ASCII.GetBytes(sourceData);
                return Convert.ToBase64String(sourceBytes);
            }
            return string.Empty;
        }
        private static string GetDecryptedData(string sourceData)
        {
            if (!string.IsNullOrEmpty(sourceData))
            {
                byte[] targetBytes = Convert.FromBase64String(sourceData);
                return ASCIIEncoding.ASCII.GetString(targetBytes);
            }

            return string.Empty;
        }
        public String Orgname(string OrganizationCode)
        {
            LogInDA objbranchname = new LogInDA();
            return objbranchname.Orgname(OrganizationCode);
        }
        public Login1 UserDetails(string UserName, string Password)
        {
            string DecPassword = string.Empty;
            LogInDA objLogin = new LogInDA();
            DecPassword = LogInMgr.GetEncryptedData(Password);
            return objLogin.MyHome1(UserName, DecPassword);
        }


    }
}
