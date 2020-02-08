using HealthCareObjects.Client;
using PatientLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientLibrary.BusinessFlow
{
    [Serializable]
    public class IssueApprovalMgr
    {
        public Boolean Updateissueapproval(CompliantApproval objompliantNo)
        {
            IssueApprovalDBOps objCompliantApproval = new IssueApprovalDBOps();
            return objCompliantApproval.Updateissueapproval(objompliantNo);
        }
        public Boolean Listupdate(List<CompliantApproval> objCompliantNo)
        {
            IssueApprovalDBOps objCompliantApproval = new IssueApprovalDBOps();
            foreach (CompliantApproval objApproval in objCompliantNo)
            {
                objCompliantApproval.Updateissueapproval(objApproval);
            }
            return true;
        }
        public List<IssueApproval> ListMainPagebyUserID(int PageNO, int RowperPage, Int64 UserID, int ClientID, string SearchText)

        {

            return new IssueApprovalDBOps().ListMainPagebyUserID(PageNO, RowperPage, UserID, ClientID, SearchText);

        }
        public List<ClientIssueRaise> clientList(Int64 UserID)
        {
            IssueApprovalDBOps objissueDB = new IssueApprovalDBOps();
            return objissueDB.clientList(UserID);
        }
        public List<CompliantApproval> ListGrid(Int64 objissueDtlID)
        {
            IssueApprovalDBOps objCompliantApproval = new IssueApprovalDBOps();
            return objCompliantApproval.ListGrid(objissueDtlID);
        }

        public bool ListClientIssueEntry(string IssueDetailID, Int64 UserID, int ClientID)
        {
            IssueApprovalDBOps sendMail = new IssueApprovalDBOps();
            List<ClientIssueEntryDtl> listmail = sendMail.ListClientIssueEntry(IssueDetailID,UserID,ClientID);
            foreach (ClientIssueEntryDtl objMeetings in listmail)
            {
               ClientIssueEntryDtl mail = new ClientIssueEntryDtl();
                mail.To = objMeetings.To;
                mail.Subject = objMeetings.Subject;
                mail.CC = objMeetings.CC;

                if (listmail != null)
                {

                    mail.Body = sendMail.DesignMailListClientIssueEntry(listmail);
                    sendMail.MailsendingMeeting(mail);
                }
            }

            return true;
        }

    }
}
