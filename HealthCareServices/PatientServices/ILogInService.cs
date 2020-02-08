using HealthCareObjects.UserRights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogInService" in both code and config file together.
    [ServiceContract]
    public interface ILogInService
    {
        [OperationContract]
        List<Login1> ListOrganizationName();
        [OperationContract]
        Login1 MyUserName(string UserName, string Password);
        [OperationContract]
        String Orgname(string OrganizationCode);
        [OperationContract]
        Login1 UserDetails(string UserName, string Password);
    }
}
