using System;
using System.Collections.Generic;
using System.Data;
using HospitalManagement;
using HealthCareObjects.Client;

namespace PatientLibrary.DataAccess
{
    [Serializable]   
     internal class CompliantApprovalDBOps
    {
        public Boolean UpdateCompliantApproval(CompliantApproval objCompliantNo)
            {
        IDbConnection con = null;
        IDbCommand cmd = null;
        int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateClientIssueApproval", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", objCompliantNo.IssueDetailID));;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Clientissueid", objCompliantNo.ClientIssueNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Approvalflag", objCompliantNo.ApproveFlag));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();

                }
            }
            if (RecordAffected > 0)
                return true;
            else
                return false;
        }

        public List<CompliantApproval> SearchList(int PageNo, int RowsPerPage, string SearchText, DateTime FromDate, DateTime ToDate, Int64 UserID)
{
    int TotalRecords = 0;
    List<CompliantApproval> CompliantList = new List<CompliantApproval>();
    CompliantApproval objCompliant = null;
    IDbConnection conn = null;
    IDbCommand cmd;
    IDataReader reader;
    using (conn = DataFactory.CreateConnection())
    {
        conn.Open();
        cmd = conn.CreateCommand();

        using (cmd = DataFactory.CreateCommand("Sp_ListClientIssueApprovalPageMain", conn))
        {

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(DataFactory.CreateParameter("PageNo", PageNo));
            cmd.Parameters.Add(DataFactory.CreateParameter("RowsPerPage", RowsPerPage));
            cmd.Parameters.Add(DataFactory.CreateParameter("SearchText", SearchText));
            cmd.Parameters.Add(DataFactory.CreateParameter("FromDate", FromDate));
            cmd.Parameters.Add(DataFactory.CreateParameter("ToDate", ToDate));
            cmd.Parameters.Add(DataFactory.CreateParameter("userid", UserID));
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    objCompliant = new CompliantApproval();


                    objCompliant.CompliantNo = Convert.ToString(reader["CompliantNo"]);
                    objCompliant.ClientIssueNo = Convert.ToInt64(reader["cIssueRaiseDetailID"]);
                    objCompliant.CompliantRaisedBy = Convert.ToString(reader["CompliantRaisedBy"]);
                    objCompliant.CompanyName = Convert.ToString(reader["ComPanyName"]);
                    objCompliant.Smcstatus = DBNull.Value.Equals(reader["smcstatus"]) ? 0 : Convert.ToInt64(reader["smcstatus"]);
                    objCompliant.NoOfIssue = Convert.ToInt32(reader["NoofIssue"]);
                    objCompliant.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    objCompliant.FormName = Convert.ToString(reader["FormName"]);
                    objCompliant.ModuleName = Convert.ToString(reader["ModuleName"]);
                    objCompliant.FeatureName = Convert.ToString(reader["FeatureName"]);
                    objCompliant.Priority = Convert.ToString(reader["ApproveFlag"]);
                    objCompliant.IssueDescription = Convert.ToString(reader["IssueDescription"]);


                            objCompliant.TotalRecords = TotalRecords;
                    CompliantList.Add(objCompliant);
                }
            }
        }
        reader.Close();
    }
    return CompliantList;
}



public List<CompliantApproval> ListGrid(Int64 objissueDtlID)
{
    List<CompliantApproval> CompliantApprovalList1 = new List<CompliantApproval>();
    CompliantApproval objCompliantApproval1 = null;
    IDbConnection conn = null;
    IDbCommand cmd = null;
    IDataReader reader;
    using (conn = DataFactory.CreateConnection())
    {
        conn.Open();
        cmd = conn.CreateCommand();
        using (cmd = DataFactory.CreateCommand("Sp_ClientIssuApprovalLevel1", conn))
        {  
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", objissueDtlID));
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                objCompliantApproval1 = new CompliantApproval();
                objCompliantApproval1.CompliantNo = Convert.ToString(reader["CompltIssueNo"]);
                objCompliantApproval1.IssueDetailID = Convert.ToInt64(reader["IssueRaiseDetailID"]);
                objCompliantApproval1.IssueDescription = Convert.ToString(reader["IssueDescription"]);
                objCompliantApproval1.ApproveFlag = DBNull.Value.Equals(reader["Approvalflag"]) ? 0 : Convert.ToInt32(reader["Approvalflag"]);
                objCompliantApproval1.Smcstatus = DBNull.Value.Equals(reader["smcstatus"]) ? 0 : Convert.ToInt64(reader["smcstatus"]);
                objCompliantApproval1.IssueDate = Convert.ToDateTime(reader["CreatedDate"]);
                objCompliantApproval1.CreatedBy = Convert.ToInt64(reader["CreatedBy"]);
                objCompliantApproval1.FormName = Convert.ToString(reader["FormName"]);
                objCompliantApproval1.ModuleName = Convert.ToString(reader["ModuleName"]);
                objCompliantApproval1.FeatureName = Convert.ToString(reader["FeatureName"]);
                CompliantApprovalList1.Add(objCompliantApproval1);
            }
        }
        return CompliantApprovalList1;
    }
}
        public Int64 CreateComments(IssueClearance objissue)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateIssueEntryComments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", objissue.Type));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CommentsID", objissue.CommentsID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", objissue.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", objissue.UserName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", objissue.IssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Comments", objissue.Comments));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", objissue.ClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objissue.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();

                }
            }
            if (RecordAffected > 0)
                return objissue.CommentsID;
            else
                return objissue.CommentsID;
        }

    }
}
