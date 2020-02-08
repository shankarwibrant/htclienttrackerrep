using HealthCareObjects.Client;
using PatientLibrary.BusinessFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IssueApprovalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IssueApprovalService.svc or IssueApprovalService.svc.cs at the Solution Explorer and start debugging.
    public class IssueApprovalService : IIssueApprovalService
    {
        public Boolean Updateissueapproval(CompliantApproval objCompliantNO)
        {
            IssueApprovalMgr objCompliantApprovalMgr = new IssueApprovalMgr();
            return objCompliantApprovalMgr.Updateissueapproval(objCompliantNO);

        }
        public bool ListUpdate(List<CompliantApproval> objCompliantApproval)
        {
            IssueApprovalMgr objApproval = new IssueApprovalMgr();
            return objApproval.Listupdate(objCompliantApproval);
        }
        public List<IssueApproval> ListMainPagebyUserID(int PageNO, int RowperPage, Int64 UserID, int ClientID, string SearchText)
        {

            return new IssueApprovalMgr().ListMainPagebyUserID(PageNO, RowperPage, UserID, ClientID, SearchText);

        }
        public List<ClientIssueRaise> clientList(Int64 UserID)
        {
            try
            {
                IssueApprovalMgr objissuemgr = new IssueApprovalMgr();
                return objissuemgr.clientList(UserID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CompliantApproval> ListGrid(Int64 objissueDtlID)
        {
            IssueApprovalMgr objCompliantapprovalMgr = new IssueApprovalMgr();
            return objCompliantapprovalMgr.ListGrid(objissueDtlID);
        }
       
    }
}
