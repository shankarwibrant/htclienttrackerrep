using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HealthCareObjects.Client;
using PatientLibrary.BusinessFlow;
namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompliantApprovalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompliantApprovalService.svc or CompliantApprovalService.svc.cs at the Solution Explorer and start debugging.
    public class CompliantApprovalService : ICompliantApprovalService
    {
        public Boolean UpdateCompliantApproval(CompliantApproval objCompliantNO)
        {
            CompliantApprovalMgr objCompliantApprovalMgr = new CompliantApprovalMgr();
            return objCompliantApprovalMgr.UpdateCompliantApproval(objCompliantNO);

        }
        public bool ListUpdate(List<CompliantApproval> objCompliantApproval)
        {
            CompliantApprovalMgr objApproval = new CompliantApprovalMgr();
            return objApproval.Listupdate(objCompliantApproval);
        }
        public Int64 CreateComments(IssueClearance objissue)
        {
            CompliantApprovalMgr objissuemgr = new CompliantApprovalMgr();
            return objissuemgr.CreateComments(objissue);
        }

        public List<CompliantApproval> ListMainPage(int PageNo, int RowsPerPage, string SearchText, DateTime FromDate, DateTime ToDate, Int64 UserID)
        {
            CompliantApprovalMgr objCompliantApprovalMgr = new CompliantApprovalMgr();
            return objCompliantApprovalMgr.SearchList(PageNo, RowsPerPage, SearchText, FromDate, ToDate, UserID);
        }
        public List<CompliantApproval> ListGrid(Int64 objissueDtlID)
        {
            CompliantApprovalMgr objCompliantapprovalMgr = new CompliantApprovalMgr();
            return objCompliantapprovalMgr.ListGrid(objissueDtlID);
        }
        public bool ListClientIssueEntry(string IssueDetailID, Int64 UserID, int ClientID)
        {
            return new IssueApprovalMgr().ListClientIssueEntry(IssueDetailID,UserID,ClientID);
        }

    }
}
