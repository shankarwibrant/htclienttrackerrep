using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthCareObjects.Client;
using PatientLibrary.DataAccess;

namespace PatientLibrary.BusinessFlow
{
    public class CompliantApprovalMgr
    {
        public Boolean UpdateCompliantApproval(CompliantApproval objompliantNo)
        {
            CompliantApprovalDBOps objCompliantApproval = new CompliantApprovalDBOps();
            return objCompliantApproval.UpdateCompliantApproval(objompliantNo);
        }
        public Boolean Listupdate(List<CompliantApproval> objCompliantNo)
        {
            CompliantApprovalDBOps objCompliantApproval = new CompliantApprovalDBOps();
            foreach (CompliantApproval objApproval in objCompliantNo)
            {
                objCompliantApproval.UpdateCompliantApproval(objApproval);
            }
            return true;
        }
        public Int64 CreateComments(IssueClearance objissue)
        {
            CompliantApprovalDBOps objissueDB = new CompliantApprovalDBOps();
            Int64 CommentsID = objissueDB.CreateComments(objissue);

            return CommentsID;
        }
        public List<CompliantApproval> SearchList(int PageNo, int RowsPerPage, string SearchText, DateTime FromDate, DateTime ToDate, Int64 UserID)
        {
            CompliantApprovalDBOps objCompliantApproval = new CompliantApprovalDBOps();
            return objCompliantApproval.SearchList(PageNo, RowsPerPage, SearchText, FromDate, ToDate, UserID);
        }



        public List<CompliantApproval> ListGrid(Int64 objissueDtlID)
        {
            CompliantApprovalDBOps objCompliantApproval = new CompliantApprovalDBOps();
            return objCompliantApproval.ListGrid(objissueDtlID);
        }
    }
}
