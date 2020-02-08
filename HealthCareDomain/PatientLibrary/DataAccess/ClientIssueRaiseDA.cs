using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using System.Data.ProviderBase;
using System.Data.SqlClient;
using HealthCareObjects.Client;
using HospitalManagement;


namespace PatientLibrary.DataAccess
{
    [Serializable]
    internal class ClientIssueRaiseDA
    {

        DateTime dayn = DateTime.Now;

        //kaleeswaran-start
        public List<FileUpload> GetAllFileById(Int64 IssueDetailID)
        {
            List<FileUpload> objissueDtlList = new List<FileUpload>();
            FileUpload objissueDtl = null;
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
                        objissueDtl = new FileUpload();
                        objissueDtl.FileId = Convert.ToInt64(reader["Id"]);
                        objissueDtl.FileName = Convert.ToString(reader["FileName"]);
                        objissueDtl.FileType = Convert.ToString(reader["MimeType"]);
                        objissueDtl.StringContent = (byte[])reader["Byte"];

                        objissueDtlList.Add(objissueDtl);
                    }
                    reader.Close();

                }
                return objissueDtlList;
            }
        }


        public Int64 Create(ClientIssueRaise objissueDtl)
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
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", objissueDtl.IsSave));
                    if (objissueDtl.IsSave == 1)
                    {
                        cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", objissueDtl.IssueID));
                    }


                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDescription", objissueDtl.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientNameId", objissueDtl.ClientNameID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientName", objissueDtl.ClientName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDate", objissueDtl.IssueDate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ApprovalFlag", objissueDtl.AssignedID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objissueDtl.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleID", objissueDtl.ModuleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleName", objissueDtl.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FormID", objissueDtl.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FormName", objissueDtl.FormName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Productid", objissueDtl.ProductID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ProductName", objissueDtl.ProductName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", objissueDtl.ClientID));

                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueType", objissueDtl.IssueType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueTypeId", objissueDtl.IssueTypeID));

                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objissueDtl.IssueID = Convert.ToInt64(param.Value);
                }
            }

            return objissueDtl.IssueID;

        }

        public Int64 UploadFile(FileUpload files)
        {
            Int64 RecordAffected = 0;
            IDbCommand cmd = null;
            IDbConnection con = null;
            string ExpectedImagePrefix = "data:" + files.FileType + ";base64,";
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_SaveClientDocuments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", files.IsSave));   
                    if (files.IsSave == 1)
                    {
                        cmd.Parameters.Add(DataFactory.CreateParameter("@id", DBNull.Value));
                        string base64 = files.FileContent.Substring(ExpectedImagePrefix.Length);
                        files.StringContent = Convert.FromBase64String(base64);
                        cmd.Parameters.Add(DataFactory.CreateParameter("@Byte", files.StringContent));
                    }
                    else
                    {
                        cmd.Parameters.Add(DataFactory.CreateParameter("@id", files.FileId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@Byte", 0));

                    }
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FileName", files.FileName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueDetailID", files.IssueDetailId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@MimeType", files.FileType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", files.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", files.ClientID));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);

                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    files.FileId = Convert.ToInt64(param.Value);


                }

            }

            return files.FileId;

        }

        public Boolean DeleteFileById(FileUpload file)
        {

            IDbConnection conn = null;
            IDbCommand cmd = null;
            Int64 Recordsaffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_DeleteClientDocument", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@fileId", file.FileId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", file.ClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@userID", file.CreatedBy));
                    Recordsaffected = cmd.ExecuteNonQuery();
                }

                if (Recordsaffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ClientIssueRaise> ListMainPage(int PageNO, int RowperPage, string searchText, int ClientID, int UserID)
        {

            List<ClientIssueRaise> objissuelist = new List<ClientIssueRaise>();


            ClientIssueRaise objissue = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;

            using (conn = DataFactory.CreateConnection())
            {
                int TotalRecords = 0;
                conn.Open();
                DateTime DT = DateTime.Now;
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListClientIssueRaisePages", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNO));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@userID", UserID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", ClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", searchText));

                    reader = cmd.ExecuteReader();   
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())

                        {
                            objissue = new ClientIssueRaise();
                            objissue.IssueID = DBNull.Value.Equals(reader["IssueRaiseDetailID"]) ? 0 : Convert.ToInt64(reader["IssueRaiseDetailID"]);//0
                            objissue.Description = DBNull.Value.Equals(reader["IssueDescription"]) ? string.Empty : Convert.ToString(reader["IssueDescription"]);//2
                            objissue.ModuleID = DBNull.Value.Equals(reader["ModuleID"]) ? 0 : Convert.ToInt64(reader["ModuleID"]);//3
                            objissue.ModuleName = DBNull.Value.Equals(reader["ModuleName"]) ? string.Empty : Convert.ToString(reader["ModuleName"]);//4
                            objissue.FormID = DBNull.Value.Equals(reader["FormID"]) ? 0 : Convert.ToInt64(reader["FormID"]);//5
                            objissue.FormName = DBNull.Value.Equals(reader["FormName"]) ? string.Empty : Convert.ToString(reader["FormName"]);//6
                            objissue.CompltIssueNo = DBNull.Value.Equals(reader["CompltIssueNo"]) ? string.Empty : Convert.ToString(reader["CompltIssueNo"]);//7
                            objissue.CreatedBy = DBNull.Value.Equals(reader["CreatedBy"]) ? 0 : Convert.ToInt64(reader["CreatedBy"]);//8
                            //objissue.CreatedDate = DBNull.Value.Equals(reader["IssueRaiseDate"]) ? DateTime.Now : Convert.ToDateTime(reader["IssueRaiseDate"]);//9
                            objissue.CreatedDate1 = DBNull.Value.Equals(reader["IssueRaiseDate"]) ? string.Empty : Convert.ToString(reader["IssueRaiseDate"]);//9
                            objissue.ClientNameID = DBNull.Value.Equals(reader["ClientNameID"]) ? 0 : Convert.ToInt64(reader["ClientNameID"]);//10
                            objissue.CompanyName = DBNull.Value.Equals(reader["ClientName"]) ? string.Empty : Convert.ToString(reader["ClientName"]);//11
                            objissue.IssueType = DBNull.Value.Equals(reader["IssueType"]) ? string.Empty : Convert.ToString(reader["IssueType"]);//12
                            objissue.Filecount = DBNull.Value.Equals(reader["Filecount"]) ? 0 : Convert.ToInt16(reader["Filecount"]);//13
                            objissue.IssueDate2 = DBNull.Value.Equals(reader["IssueDate"]) ? string.Empty : Convert.ToString(reader["IssueDate"]);//14
                            objissue.IssueTypeID = DBNull.Value.Equals(reader["IssueTypeId"]) ? 0 : Convert.ToInt16(reader["IssueTypeId"]);//15
                            objissue.ProductName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);//16
                            objissue.ProductID = DBNull.Value.Equals(reader["Productid"]) ? 0 : Convert.ToInt64(reader["Productid"]);//17
                            objissue.ShortNmae = DBNull.Value.Equals(reader["ApproveFlag"]) ? string.Empty : Convert.ToString(reader["ApproveFlag"]);
                            objissue.TotalRecords = TotalRecords;

                            objissuelist.Add(objissue);
                        }
                    }

                }

                return objissuelist;
            }
        }


        public List<ClientIssueRaise> clientList(Int64 UserID)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            ClientIssueRaise obj = null;
            List<ClientIssueRaise> objlsit = new List<ClientIssueRaise>();

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ClientInfoNamelist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", UserID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj = new ClientIssueRaise();
                        obj.ClientName = Convert.ToString(reader["CompanyName"]);
                        obj.ClientNameID = Convert.ToInt64(reader["ClientID"]);
                        objlsit.Add(obj);
                    }
                }
                con.Close();
                return objlsit;
            }

        }

        //kaleeswaran-end



        public string AutoID(int ClientID)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            string IssueID = string.Empty;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_AutoIDforCilentIssue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("ClientID", ClientID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        IssueID = Convert.ToString(reader["IssueID"]);
                    }
                    reader.Close();
                }
                return IssueID;
            }
        }

        public List<Department> ListDepartmentName()
        {
            List<Department> objdeptlist = new List<Department>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            Department objdept = null;

            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_DepartmentList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objdept = new Department();
                        objdept.DepartmentID = Convert.ToInt64(reader["DepartmentID"]);
                        objdept.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        objdeptlist.Add(objdept);
                    }
                }

                reader.Close();
                return objdeptlist;
            }

        }
        public Boolean DeleteIssueRaiseById(ClientIssueRaise Dltproperty)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            int recordsaffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_DeleteIssueRaiseMaintable", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueID", Dltproperty.IssueID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", Dltproperty.ClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@userid", Dltproperty.UserID));
                    recordsaffected = cmd.ExecuteNonQuery();
                }
            }
            if (recordsaffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    


        public List<ClientInformation> ListModuleName(int clientId)
        {
            List<ClientInformation> objlist = new List<ClientInformation>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            ClientInformation objmodule = null;

            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_IssueEntryModule", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@clientId", clientId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objmodule = new ClientInformation();
                        objmodule.ModuleID = Convert.ToInt64(reader["ModuleID"]);
                        objmodule.ModuleName = Convert.ToString(reader["ModuleName"]);
                        objlist.Add(objmodule);
                    }
                }

                reader.Close();
                return objlist;
            }

        }

        public List<ClientIssueRaiseDtl> ListFormName(Int64 ModuleID)//,int ClientID)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            ClientIssueRaiseDtl obj = null;
            List<ClientIssueRaiseDtl> objlsitForm = new List<ClientIssueRaiseDtl>();

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ListForm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleID", ModuleID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj = new ClientIssueRaiseDtl();
                        obj.FormName = Convert.ToString(reader["FormName"]);
                        obj.FormID = Convert.ToString(reader["FormID"]);
                        objlsitForm.Add(obj);
                    }
                }
                con.Close();
                return objlsitForm;
            }

        }






    }
}
