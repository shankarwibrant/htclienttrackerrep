using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using HealthCareObjects.UserRights;
using PatientLibrary.BusinessFlow;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogInService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogInService.svc or LogInService.svc.cs at the Solution Explorer and start debugging.
    public class LogInService : ILogInService
    {
        public List<Login1> ListOrganizationName()
        {
            LogInMgr objLogInMgr = new LogInMgr();
            return objLogInMgr.ListOrganizationName();
        }
        public Login1 MyUserName(string UserName, string Password)
        {
            LogInMgr objLoginName = new LogInMgr();
            return objLoginName.MyUserName(UserName, Password);
        }
        public String Orgname(string OrganizationCode)
        {
            LogInMgr objOrgName = new LogInMgr();
            return objOrgName.Orgname(OrganizationCode);
        }
        public Login1 UserDetails(string UserName, string Password)
        {
            LogInMgr objLoginName = new LogInMgr();
            return objLoginName.UserDetails(UserName, Password);
        }

    }
}
