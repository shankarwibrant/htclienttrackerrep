using HealthCareObjects.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIssueApprovalService" in both code and config file together.
    [ServiceContract]
    public interface IIssueApprovalService
    {
        [OperationContract]
        Boolean Updateissueapproval(CompliantApproval objCompliantNO);
        [OperationContract]
        bool ListUpdate(List<CompliantApproval> objCompliantApproval);
        [OperationContract]


        List<IssueApproval> ListMainPagebyUserID(int PageNO, int RowperPage, Int64 UserID, int ClientID, string SearchText);
        [OperationContract]
        List<ClientIssueRaise> clientList(Int64 UserID);
        [OperationContract]
        List<CompliantApproval> ListGrid(Int64 objissueDtlID);

    }
}
