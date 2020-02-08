using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HealthCareObjects.Client;

namespace PatientLibrary.DataAccess
{

    internal class ClientIssueRaiseDtlDA
    {

          public Int64 CreateDtl(ClientIssueRaiseDtl objissueDtl)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateIssueRaiseDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", 1));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", objissueDtl.IssueID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDescription", objissueDtl.IssueDescription));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", objissueDtl.IssueClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Approvalflag", objissueDtl.Aaprovalflag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objissueDtl.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleID", objissueDtl.ModuleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FormID", objissueDtl.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FeatureName", objissueDtl.FeatureName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ProductID", objissueDtl.ProductId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CompltIssueNo", objissueDtl.CompltIssueNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SelfAssign", objissueDtl.SelfAssign));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@AssignedTO", objissueDtl.AssignedTo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PastIssueDetailID", objissueDtl.PastIssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueType", objissueDtl.IssueType));


                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueTypeId", objissueDtl.IssueTypeId));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objissueDtl.IssueDetailID = Convert.ToInt64(param.Value);
                }
            }

            return objissueDtl.IssueDetailID;

        }

        public Int64 UpdateDtl(ClientIssueRaiseDtl objissueDtl)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateIssueRaiseDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", 0));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", objissueDtl.IssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", objissueDtl.IssueID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDescription", objissueDtl.IssueDescription));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", objissueDtl.IssueClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Approvalflag", objissueDtl.Aaprovalflag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SNO", objissueDtl.SNO));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objissueDtl.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleID", objissueDtl.ModuleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FormID", objissueDtl.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ProductID", objissueDtl.ProductId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CompltIssueNo", objissueDtl.CompltIssueNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SelfAssign", objissueDtl.SelfAssign));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@AssignedTO", objissueDtl.AssignedTo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PastIssueDetailID", objissueDtl.PastIssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueType", objissueDtl.IssueType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FeatureName", objissueDtl.FeatureName));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objissueDtl.IssueDetailID = Convert.ToInt64(param.Value);
                }
            }

            return objissueDtl.IssueDetailID;

        }

        public Boolean SaveRecord(ClientIssueRaiseDtl objissueDtl)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateIssueEntryDtlConfirm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", objissueDtl.IssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SelfAssign", objissueDtl.SelfAssign));
                    RecordAffected = cmd.ExecuteNonQuery();

                }
            }
            if (RecordAffected > 0)
                return true;
            else
                return false;
        }

        public List<ClientIssueRaiseDtl> ListByDetailID(Int64 IssueID, Int32 sNo)
        {
            List<ClientIssueRaiseDtl> objissueDtlList = new List<ClientIssueRaiseDtl>();
            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListIssueEntryByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", IssueID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@sNo", sNo));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.IssueDetailID = Convert.ToInt64(reader["IssueDetailID"]);
                        objissueDtl.IssueID = Convert.ToInt64(reader["IssueID"]);
                        objissueDtl.IssueType = Convert.ToString(reader["IssueType"]);
                        objissueDtl.IssueDescription = Convert.ToString(reader["IssueDescription"]);
                        objissueDtl.CilentID = Convert.ToInt64(reader["ClientID"]);
                        objissueDtl.SNO = Convert.ToInt64(reader["SNo"]);
                        objissueDtl.CreatedBy = Convert.ToInt64(reader["CreatedBy"]);
                        objissueDtl.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        objissueDtl.ModuleID = Convert.ToString(reader["ModuleID"]);
                        objissueDtl.ModuleName = Convert.ToString(reader["ModuleName"]);
                        objissueDtl.FormID = Convert.ToString(reader["EntityID"]);
                        objissueDtl.FormName = Convert.ToString(reader["EntityName"]);
                        objissueDtl.CompltIssueNo = Convert.ToString(reader["CompltIssueNo"]);
                        objissueDtl.FileUploadFlag = DBNull.Value.Equals(reader["FileUploadFlag"]) ? 0 : Convert.ToInt32(reader["FileUploadFlag"]);

                        objissueDtl.FileName = Convert.ToString(reader["FileName"]);

                        objissueDtl.FeatureName = DBNull.Value.Equals(reader["ParameterName"]) ? "" : Convert.ToString(reader["ParameterName"]);
                        objissueDtl.ProductId = DBNull.Value.Equals(reader["ParameterID"]) ? 0 : Convert.ToInt64(reader["ParameterID"]);
                        objissueDtl.IssueDate2 = DBNull.Value.Equals(reader["issuedate"]) ? string.Empty : Convert.ToString(reader["issuedate"]);

                        objissueDtlList.Add(objissueDtl);
                    }
                    reader.Close();

                }
                return objissueDtlList;
            }
        }

        public List<ClientIssueRaiseDtl> GetAllFileById(Int64 IssueDetailID)
        {
            List<ClientIssueRaiseDtl> objissueDtlList = new List<ClientIssueRaiseDtl>();
            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ClientuploadFilesById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", IssueDetailID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.FileId = Convert.ToInt64(reader["Id"]);
                        objissueDtl.FileName = Convert.ToString(reader["FileName"]);
                        objissueDtl.FileType = Convert.ToString(reader["MimeType"]);

                        objissueDtlList.Add(objissueDtl);
                    }
                    reader.Close();

                }
                return objissueDtlList;
            }
        }


        public int UploadFile(FileUpload files)
        {

            IDbCommand cmd = null;
            IDbConnection con = null;

            int isExists = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_SaveDocuments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FileName", files.FileName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Byte", files.FileContent));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", files.IssueDetailId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@MimeType", files.FileType));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int16;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                    isExists = Convert.ToInt16(param.Value);
                    con.Close();

                }

            }

            return isExists;

        }



    
        public Boolean DeleteFileById(Int64 detailId)
        {

            IDbCommand cmd = null;
            IDbConnection con = null;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();

                using (cmd = DataFactory.CreateCommand("Sp_DeleteDocument", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@fileId", detailId));
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }
        public Boolean DeleteDtl(ClientIssueRaiseDtl objdelete)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_DeleteClientIssueDtl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", objdelete.IssueDetailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", objdelete.IssueID));
                    cmd.ExecuteNonQuery();
                }
            }
            return true;

        }

        public string AutoIDSelf()
        {

            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_AutoIDSelfAssign", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.IssueDetailID = Convert.ToInt64(reader["IssueDetailID"]);

                    }
                    reader.Close();

                }
                return objissueDtl.IssueDetailID.ToString();
            }
        }

        public string ListCompltIssueNo()
        {
            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ClientIssueNoList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.CompltIssueNo = Convert.ToString(reader["CompltIssueNo"]);

                    }
                    reader.Close();

                }
                return objissueDtl.CompltIssueNo;
            }
        }

        public string ListIssueDate()
        {
            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ClientIssueDatelist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);

                    }
                    reader.Close();

                }
                return objissueDtl.CreatedDate.ToShortDateString();
            }
        }

        public string FileuploadDal(Int64 id)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_fileuploadupda", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@issuedeatailid", id));
                    cmd.ExecuteNonQuery();

                }
            }
            return id.ToString();
        }
        public List<ClientIssueRaiseDtl> PastIssueSearch(Int64 clientId, Int64 moduleId, Int64 formId)
        {
            List<ClientIssueRaiseDtl> objissueDtlList = new List<ClientIssueRaiseDtl>();
            ClientIssueRaiseDtl objissueDtl = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_PastIssueSearch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@clientId", clientId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@moduleId", moduleId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@formId", formId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        objissueDtl = new ClientIssueRaiseDtl();
                        objissueDtl.IssueDescription = Convert.ToString(reader["IssueDescription"]);
                        objissueDtl.IssueID = Convert.ToInt64(reader["IssueID"]);
                        objissueDtl.FeatureName = Convert.ToString(reader["FeatureName"]);
                        objissueDtl.ModuleName = DBNull.Value.Equals(reader["ModuleName"]) ? "" : Convert.ToString(reader["ModuleName"]);
                        objissueDtl.FormName = Convert.ToString(reader["EntityName"]);
                        objissueDtl.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        objissueDtl.CreatedName = Convert.ToString(reader["CreatedBy"]);
                        objissueDtl.ClientName = Convert.ToString(reader["CompanyName"]);
                        objissueDtl.IssueType = Convert.ToString(reader["IssueType"]);


                        objissueDtlList.Add(objissueDtl);
                    }
                    reader.Close();

                }
                return objissueDtlList;
            }
        }


    }
}
