using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HealthCareObjects.Client;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompliantApprovalService" in both code and config file together.
    [ServiceContract]
    public interface ICompliantApprovalService
    {
        [OperationContract]
        Int64 CreateComments(IssueClearance objissue);
        [OperationContract]
        Boolean UpdateCompliantApproval(CompliantApproval objCompliantNO);
        [OperationContract]
        bool ListUpdate(List<CompliantApproval> objCompliantApproval);
        [OperationContract]
        List<CompliantApproval> ListMainPage(int PageNo, int RowsPerPage, string SearchText, DateTime FromDate, DateTime ToDate, Int64 UserID);

        [OperationContract]
        List<CompliantApproval> ListGrid(Int64 objissueDtlID);
        [WebGet]
        [OperationContract]       
        bool ListClientIssueEntry(string IssueDetailID, Int64 UserID, int ClientID);
    }
}
