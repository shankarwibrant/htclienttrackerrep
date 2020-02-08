using HealthCareObjects.Client;
using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace PatientLibrary.DataAccess
{
    [Serializable]
    internal class IssueApprovalDBOps
    {
        public Boolean Updateissueapproval(CompliantApproval objCompliantNo)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateClientIssueApprovalfinal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", objCompliantNo.IssueDetailID)); ;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Clientissueid", objCompliantNo.ClientIssueNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Approvalflag", objCompliantNo.ApproveFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@userid", objCompliantNo.UserID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@clientid", objCompliantNo.ClientID));
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

        public List<IssueApproval> ListMainPagebyUserID(int PageNO, int RowperPage, Int64 UserID, int ClientID, string SearchText)

        {
            List<IssueApproval> objissuelist = new List<IssueApproval>();
            IssueApproval objissue = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            string date = Convert.ToString(DateTime.Now);
            using (conn = DataFactory.CreateConnection())
            {
                int TotalRecords = 0;
                conn.Open();
                cmd = conn.CreateCommand();


                using (cmd = DataFactory.CreateCommand("Sp_ListworkassignmentissueMaingridbyUserId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("PageNo", PageNO));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("UserID", UserID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ClientID", ClientID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {

                            objissue = new IssueApproval();
                            objissue.Issuesimple = Convert.ToString(reader["CompltIssueNo"]);
                            objissue.UserFullName = Convert.ToString(reader["FullName"]);
                            objissue.IssueDetailID = Convert.ToInt64(reader["IssueRaiseDetailID"]);
                            objissue.IssueDescription = Convert.ToString(reader["IssueDescribtion"]);
                            //objissue.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                            objissue.CreatedBy = Convert.ToInt64(reader["CreatedBy"]);
                            objissue.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            objissue.CilentID = Convert.ToInt64(reader["ClientID"]);
                            objissue.Activeflage = Convert.ToInt64(reader["Activeflag"]);
                            objissue.CompanyName = Convert.ToString(reader["ComPanyName"]);
                            objissue.ApprovalDate = DBNull.Value.Equals(reader["Approvaldate"]) ? Convert.ToDateTime(date) : Convert.ToDateTime(reader["Approvaldate"]);
                            objissue.Modulename = Convert.ToString(reader["ModuleName"]);
                            objissue.Formname = Convert.ToString(reader["EntityName"]);
                            objissue.FileUploadflag = DBNull.Value.Equals(reader["Fileuploadflag"]) ? 0 : Convert.ToInt32(reader["Fileuploadflag"]);
                            objissue.FeatureName = Convert.ToString(reader["FeatureName"]);
                            objissue.PriorityName = Convert.ToString(reader["ApproveFlag"]);


                            //objissue.PriorityName = DBNull.Value.Equals(reader["PriorityStatus"]) ? string.Empty : Convert.ToString(reader["PriorityStatus"]);
                            //objissue.SeverityName = DBNull.Value.Equals(reader["SeverityStatus"]) ? string.Empty : Convert.ToString(reader["SeverityStatus"]);
                            //objissue.IssueFrom = DBNull.Value.Equals(reader["IssueFrom"]) ? string.Empty : Convert.ToString(reader["IssueFrom"]);

                            // objissue.Status = DBNull.Value.Equals(reader["Status"]) ? string.Empty : Convert.ToString(reader["Status"]);
                            objissue.TotalRecords = TotalRecords;
                            objissuelist.Add(objissue);
                        }
                    }

                }

                return objissuelist;
            }
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
                using (cmd = DataFactory.CreateCommand("Sp_ClientIssuFinalApproval", conn))
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



        public List<ClientIssueEntryDtl> ListClientIssueEntry(string IssueDetailID, Int64 UserID, int ClientID)
        {
            try
            {
                List<ClientIssueEntryDtl> MailList = new List<ClientIssueEntryDtl>();
                ClientIssueEntryDtl objMail = null;
                IDbConnection conn = null;
                IDbCommand cmd = null;
                IDataReader reader;
                List<string> totalComments = new List<string>();
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("[Sp_MailListClientIssueEntryapporval]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", IssueDetailID));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@ClientId", ClientID));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@Userid", UserID));
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string result = Convert.ToString(reader["totalComments"]);
                            totalComments.Add(result);
                           
                        }

                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                objMail = new ClientIssueEntryDtl();
                                objMail.SNo = DBNull.Value.Equals(reader["SlNo"]) ? 0 : Convert.ToInt64(reader["SlNo"]);
                                objMail.ModuleName = DBNull.Value.Equals(reader["ModuleName"]) ? "" : Convert.ToString(reader["ModuleName"]);
                                objMail.ClientName = DBNull.Value.Equals(reader["ClientName"]) ? "" : Convert.ToString(reader["ClientName"]);
                                objMail.FormName = DBNull.Value.Equals(reader["FormName"]) ? "" : Convert.ToString(reader["FormName"]);
                                objMail.ProductName = DBNull.Value.Equals(reader["ProductName"]) ? "" : Convert.ToString(reader["ProductName"]);
                                objMail.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? "" : Convert.ToString(reader["IssueDescription"]);
                                objMail.To = DBNull.Value.Equals(reader["ToMail"]) ? "" : Convert.ToString(reader["ToMail"]);
                                objMail.CC = DBNull.Value.Equals(reader["CC"]) ? "" : Convert.ToString(reader["CC"]);
                                objMail.Subject = DBNull.Value.Equals(reader["subject"]) ? "" : Convert.ToString(reader["subject"]);
                                objMail.IssueType = DBNull.Value.Equals(reader["IssueType"]) ? "" : Convert.ToString(reader["IssueType"]);
                                objMail.Priority = DBNull.Value.Equals(reader["UserName"]) ? "" : Convert.ToString(reader["UserName"]);
                                //objMail.Comments = DBNull.Value.Equals(reader["Comments"]) ? "" : Convert.ToString(reader["Comments"]);
                                objMail.totalComments = totalComments;
                                MailList.Add(objMail);
                            }
                        }
                        reader.Close();
                    }
                    return MailList;
                }
            }
            catch (Exception msg)
            {

                string mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mail.txt";
                StringBuilder objSB = new StringBuilder();
                //objSB.Append("Skill Set:" + JobPostObj.SkillSet + ",JobTitile:" + JobPostObj.JobTitle);
                using (StreamWriter outfile = new StreamWriter(mypath))
                {
                    outfile.Write(objSB.ToString() + "   Exception" + msg.Message);
                }
                throw new Exception(msg.Message);

            }
        }






        //public List<ClientIssueEntryDtl> ListClientIssueEntry(string IssueDetailID)
        //{
        //    try
        //    {
        //        List<ClientIssueEntryDtl> MailList = new List<ClientIssueEntryDtl>();
        //        ClientIssueEntryDtl objMail = null;
        //        IDbConnection conn = null;
        //        IDbCommand cmd = null;
        //        IDataReader reader;
        //        using (conn = DataFactory.CreateConnection())
        //        {
        //            conn.Open();
        //            cmd = conn.CreateCommand();
        //            using (cmd = DataFactory.CreateCommand("[Sp_MailListClientIssueEntryapporval]", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", IssueDetailID));
        //                reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    objMail = new ClientIssueEntryDtl();
        //                    objMail.SNo = DBNull.Value.Equals(reader["SlNo"]) ? 0 : Convert.ToInt64(reader["SlNo"]);
        //                    objMail.ModuleName = DBNull.Value.Equals(reader["ModuleName"]) ? "" : Convert.ToString(reader["ModuleName"]);
        //                    objMail.ClientName = DBNull.Value.Equals(reader["ClientName"]) ? "" : Convert.ToString(reader["ClientName"]);
        //                    objMail.FormName = DBNull.Value.Equals(reader["FormName"]) ? "" : Convert.ToString(reader["FormName"]);
        //                    objMail.ProductName = DBNull.Value.Equals(reader["ProductName"]) ? "" : Convert.ToString(reader["ProductName"]);
        //                    objMail.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? "" : Convert.ToString(reader["IssueDescription"]);
        //                    objMail.To = DBNull.Value.Equals(reader["ToMail"]) ? "" : Convert.ToString(reader["ToMail"]);
        //                    objMail.CC = DBNull.Value.Equals(reader["CC"]) ? "" : Convert.ToString(reader["CC"]);
        //                    objMail.Subject = DBNull.Value.Equals(reader["subject"]) ? "" : Convert.ToString(reader["subject"]);
        //                    objMail.IssueType = DBNull.Value.Equals(reader["IssueType"]) ? "" : Convert.ToString(reader["IssueType"]);
        //                    objMail.Priority = DBNull.Value.Equals(reader["UserName"]) ? "" : Convert.ToString(reader["UserName"]);
        //                    objMail.Comments = DBNull.Value.Equals(reader["Comments"]) ? "" : Convert.ToString(reader["Comments"]);
        //                    MailList.Add(objMail);
        //                }
        //                reader.Close();
        //            }
        //            return MailList;
        //        }

        //    }
        //    catch (Exception msg)
        //    {

        //        string mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mail.txt";
        //        StringBuilder objSB = new StringBuilder();
        //        //objSB.Append("Skill Set:" + JobPostObj.SkillSet + ",JobTitile:" + JobPostObj.JobTitle);
        //        using (StreamWriter outfile = new StreamWriter(mypath))
        //        {
        //            outfile.Write(objSB.ToString() + "   Exception" + msg.Message);
        //        }
        //        throw new Exception(msg.Message);

        //    }
        //}


        //public List<ClientIssueEntryDtl> ListClientIssueEntry1(string IssueDetailID)
        //{
        //    List<ClientIssueEntryDtl> MailList = new List<ClientIssueEntryDtl>();
        //    ClientIssueEntryDtl objMail = null;
        //    IDbConnection conn = null;
        //    IDbCommand cmd = null;
        //    IDataReader reader;
        //    using (conn = DataFactory.CreateConnection())
        //    {
        //        conn.Open();
        //        cmd = conn.CreateCommand();
        //        using (cmd = DataFactory.CreateCommand("[Sp_MailListClientIssueEntryapporvalcomments]", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(DataFactory.CreateParameter("@IssueRaiseDetailID", IssueDetailID));
        //            reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                objMail = new ClientIssueEntryDtl();
        //                objMail.Comments = DBNull.Value.Equals(reader["Comments"]) ? "" : Convert.ToString(reader["Comments"]);
        //                MailList.Add(objMail);
        //            }
        //            reader.Close();
        //        }
        //        return MailList;
        //    }
        //}

        public string DesignMailListClientIssueEntry(List<ClientIssueEntryDtl> objCLIE1)
        {


            var bodyMsg = "<div style='font-size:1em;width:100%;background-color:#fff;border:1px solid #efefef;'>";
            bodyMsg += "<div style='width:99.9%;background-color:#0097A7;color:#fff;padding:1px;text-align:center;'>";
            bodyMsg += "<h3>Client Issue Entry</h3></div>";
            bodyMsg += "<table  cellpadding='10' border = '1' bordercolor='red' style='background-color:#efefef;width: 99.9%; border-collapse: collapse;'>";
            bodyMsg += "<thead>";
            bodyMsg += "<tr><th style = 'text-align: center;padding: 0;'>Sl.No.</th><th style = 'text-align: center;padding: 0;'>Client Name</th><th style = 'text-align: center;padding: 0;'>Module Name</th><th style = 'text-align: center;padding: 0;'>Form Name</th><th style = 'text-align: center;padding: 0;'>Product Name</th><th style = 'text-align: center;padding: 0 50px;'>Issue Description</th><th style = 'text-align: center;padding: 0 ;'>Issue Type</th><th style = 'text-align: center;padding: 0 50px;'>User Name</th></tr>";
            bodyMsg += "</thead>";
            List<string> lstComment=new List<string>();
            foreach (ClientIssueEntryDtl objCLIE in objCLIE1)
            {
                bodyMsg += "<tbody>";
                bodyMsg += "<tr><td style = 'text-align:center;'>" + objCLIE.SNo + "</td><td style = 'text-align: center'>" + objCLIE.ClientName + "</td><td style = 'text-align: center'>" + objCLIE.ModuleName + "</td><td style = 'text-align: center'>" + objCLIE.FormName + "</td><td style = 'text-align: center'>" + objCLIE.ProductName + "</td><td style = 'text-align: left'>" + objCLIE.IssueDescription + "</td><td style = 'text-align: center'>" + objCLIE.IssueType + "</td><td style = 'text-align: center'>" + objCLIE.Priority + "</td></tr>";
                bodyMsg += "</tbody>";
                lstComment = objCLIE.totalComments;
            }
            bodyMsg += "</table>";
            bodyMsg += "<div style='width:99.9%;background-color:#0097A7;color:#fff;padding:1px;text-align:center;'>";
            bodyMsg += "<h3>Comments</h3></div>";
            bodyMsg += "<table  cellpadding='10' border = '1' bordercolor='red' style='background-color:#efefef;width: 99.9%; border-collapse: collapse;'>";
            foreach (var cmt in lstComment)
            {
                bodyMsg += "<tbody>";
                bodyMsg += "<tr><td style = 'text-align:left;'>" + cmt + "</td></tr>";
                bodyMsg += "</tbody>";
            }

            bodyMsg += "</table>";

            bodyMsg += "<p><strong>Note: </strong>This is a system generated automatic email, please do not reply to this email.</p>";
            bodyMsg += "<p><strong>Click to proceed: </strong><a href='http://www.wibrant.com'>www.wibrant.com</a></p>";
            bodyMsg += "</div>";

            return bodyMsg;

        }

        public bool MailsendingMeeting(ClientIssueEntryDtl mail)
        {
            MailMessage msg = new MailMessage();
            string a = ConfigurationManager.AppSettings["EPASS"].ToString();
            string[] b = a.Split('$');

            using (SmtpClient smtp = new SmtpClient())
            {
                mail.From = b[0];
                string frmpass = b[1];
                int i = mail.From.LastIndexOf('@');
                int j = mail.From.LastIndexOf('.');
                int len = j - i;
                string checkmail = mail.From.Substring(i + 1, len - 1);
                msg.From = new MailAddress(mail.From);
                msg.To.Add(new MailAddress(mail.To));

                msg.CC.Add(new MailAddress(mail.CC));

                if (mail.BCC != null)
                {
                    string[] emails = mail.BCC.Split(new char[] { ',' });
                    foreach (string e in emails)
                    {
                        msg.CC.Add(new MailAddress(e));
                    }
                }

                msg.IsBodyHtml = true;
                msg.Subject = mail.Subject;
                msg.Body = mail.Body; ;

                if (checkmail == "ymail" || checkmail == "yahoo")//yahoo
                {
                    smtp.Host = "smtp.mail.yahoo.com";
                    smtp.Port = 25; //465
                }
                else if (checkmail == "gmail") //gmail
                {
                    smtp.Host = "smtp.gmail.com"; ;
                    smtp.Port = 25;
                }
                else if (checkmail == "live") //hotmail
                {
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 25; //587 out look 465 hotmail  29101990
                }
                else if (checkmail == "outlook") //hotmail
                {
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 25; //587 out look 465 hotmail  29101990
                }
                else if (checkmail == "vibrant") //hotmail
                {
                    smtp.Host = "smtp.bizmail.yahoo.com";
                    smtp.Port = 25; //587 out look 465 hotmail  29101990
                }
                else
                {
                    smtp.Host = "Secure";
                    smtp.Port = 465;
                }

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(mail.From, frmpass);
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(msg);
                    smtp.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;


                }
            }

        }

    }
}
