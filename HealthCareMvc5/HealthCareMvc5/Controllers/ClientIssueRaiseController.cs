using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using HealthCareObjects.UserRights;
using HealthCareMvc5.ClientIssueRaiseRef;
using HealthCareMvc5.Controllers.Common;
using System.ServiceModel;
using System.Transactions;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using HealthCareMvc5.FormFeatureServiceRef;
using ClientIssueRaiseDtl = HealthCareObjects.Client.ClientIssueRaiseDtl;
using HealthCareMvc5.Models;

//using FileUpload = HealthCareObjects.Client.FileUpload;

namespace HealthCareMvc5.Controllers
{
    public class ClientIssueRaiseController : Controller
    {
        // GET: ClientIssueRaise

        string Servicepath = Convert.ToString(WebConfigurationManager.AppSettings["ServicePath"]);
        string ConnectionString = Convert.ToString(WebConfigurationManager.AppSettings["ConnectionString"]);



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Addnewpartialview()
        {
            List<Login1> finallist = new List<Login1>();
            var log = (Login1)Session["UserList"];

            Session["UserName"] = log.UserName;
            Session["UserId"] = log.UserID;
            Session["ClientID"] = log.ClientID;
            Session["Employee"] = log.Employee;
            Session["EmployeeName"] = log.EmployeeName;
            Session["DesignationName"] = log.Designation;
            Session["Departmentname"] = log.Department;
            Session["UserList"] = log;
            Session["EmployeeID"] = log.EmployeeID;
            Session["RoleID"] = log.RoleID;
            Session["EmailID"] = log.Email;



            FormFeatureServicesClient objclient = new FormFeatureServicesClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "FormFeatureServices.svc")));

            var lismodulesss = IssueTypeDrop();
            ViewBag.IssuseTypee = new SelectList(lismodulesss.AsEnumerable(), "IssueTypeID", "IssueType");

            var client1 = clientList(log.UserID);
            ViewData["ClientNameId"] = client1;
        

            return View();
        }


        public ActionResult product(Int64 Branchcode)
        {
            List<ClientIssueRaiseDtl> selectionlist = new List<ClientIssueRaiseDtl>();
            ClientIssueRaiseDtl objselection = null;
            SqlConnection conn = null;
            SqlCommand cmd;
            SqlDataReader reader;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_Tracproductnamenew", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ClientId", Branchcode));
                    
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objselection = new ClientIssueRaiseDtl();
                        objselection.AssignedID = Convert.ToInt64(reader["ParameterID"]);
                        objselection.ModuleName = Convert.ToString(reader["ParameterName"]);

                        selectionlist.Add(objselection);
                    }
                }
            }
            conn.Close();
            return this.Json(selectionlist);
        }

        public string clientList(Int64 UserID)
        {
            SqlConnection conn = null;
            SqlCommand cmd;
            SqlDataReader reader;
            string ClientName = string.Empty;
            Int64 Clientid = 0;
            string ClientNameId = string.Empty;
            using (conn =  new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_ClientInfoBinding", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        ClientName = Convert.ToString(reader["CompanyName"]);
                        Clientid = Convert.ToInt64(reader["ClientID"]);
                        ClientNameId = Convert.ToString(Clientid) + '-' + ClientName;
                    }  
                 
                }
                conn.Close();
                return ClientNameId;
            }

        }


        public List<ClientIssueRaise> IssueTypeDrop()
        {

            List<ClientIssueRaise> obj2 = new List<ClientIssueRaise>();
           ClientIssueRaise objmod = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader reader = null;

            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("sp_Trackerissuetype", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objmod = new ClientIssueRaise();

                        objmod.IssueType = Convert.ToString(reader["Issuetypename"]);
                        objmod.IssueTypeID = Convert.ToInt32(reader["Issuetypeid"]);
                        obj2.Add(objmod);
                    }
                }
                reader.Close();
            }
            return obj2;
        }

        public ActionResult GetHeaderType1(Int64 Branchcode, Int64 ClientId)
        {
           
            List<ClientIssueRaise> selectionlist = new List<ClientIssueRaise>();
            ClientIssueRaise objselection = null;
            SqlConnection conn = null;
            SqlCommand cmd;
            SqlDataReader reader;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_formmoduletypenew", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Productid", Branchcode));
                    cmd.Parameters.Add(new SqlParameter("@ClientId", ClientId));
                    // cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objselection = new ClientIssueRaise();
                        objselection.AssignedID = Convert.ToInt64(reader["ModuleID"]);
                        objselection.ModuleName = Convert.ToString(reader["ModuleName"]);

                        selectionlist.Add(objselection);
                    }
                }
            }
            conn.Close();
            return this.Json(selectionlist);
        }

        public ActionResult GetHeaderType12(Int64 Branchcode, Int64 Productid, Int64 ClientId)
        {
            List<ClientIssueRaise> selectionlist = new List<ClientIssueRaise>();
            ClientIssueRaise objselection = null;
            SqlConnection conn = null;
            SqlCommand cmd;
            SqlDataReader reader;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_formentitynametypenew", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@moduleid", Branchcode));
                    cmd.Parameters.Add(new SqlParameter("@Productid", Productid));
                    cmd.Parameters.Add(new SqlParameter("@ClientId", ClientId));

                    // cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objselection = new ClientIssueRaise();
                        objselection.AssignedID = Convert.ToInt64(reader["EntityID"]);
                        objselection.ModuleName = Convert.ToString(reader["EntityName"]);

                        selectionlist.Add(objselection);
                    }
                }
            }
            conn.Close();
            return this.Json(selectionlist);
        }




        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            
            int TotalRecords = 0;
            param.PageNo = ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength) == 0 ? 1 : ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength);
            param.RowsPerPage = param.iDisplayLength;

            ClientIssueRaiseServiceClient gridservice = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));

            List<HealthCareObjects.Client.ClientIssueRaise> gridlist = new List<HealthCareObjects.Client.ClientIssueRaise>();
            var local = gridservice.ListMainpage(param.PageNo, param.RowsPerPage, Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(Session["UserId"]) , param.sSearch = param.sSearch ?? "");

            var result = from c in local
                         select new[] {
                             c.CompltIssueNo,//0
                             c.IssueID.ToString(),//1
                             c.CompanyName,//2
                             c.ModuleName,//3
                             c.FormName,//4
                             c.ProductName,//5
                             c.IssueType,//6
                             c.IssueDate2,//7
                             c.CreatedDate1,//8
                             c.Description,//9
                             c.ModuleID.ToString(),//10
                             c.FormID.ToString(),//11
                             c.ProductID.ToString(),//12
                             c.IssueTypeID.ToString(),//13
                             c.ClientNameID.ToString(),//14
                             "<center><i id='iconDelete' data-toggle='tooltip' title='Delete' class='icon-cSize fa fa-trash delete'></i></button><center>",//15
                             c.Filecount.ToString()//16
                             ,c.ShortNmae//17
                         };
            foreach (ClientIssueRaise river  in local)
            {
                TotalRecords = Convert.ToInt16(river.TotalRecords);
                break;
            }


            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },

                         JsonRequestBehavior.AllowGet);
        }

        public List<ClientIssueRaise> ListMainPage(int PageNO, int RowperPage, string searchText, int ClientID, int UserID)
        {

            List<ClientIssueRaise> objissuelist = new List<ClientIssueRaise>();


            ClientIssueRaise objissue = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            using (conn = new SqlConnection(ConnectionString))
            {
                int TotalRecords = 0;
                conn.Open();
                DateTime DT = DateTime.Now;
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_ListClientIssueRaisePages", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PageNo", PageNO));
                    cmd.Parameters.Add(new SqlParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(new SqlParameter("@userID", UserID));
                    cmd.Parameters.Add(new SqlParameter("@ClientID", ClientID));
                    cmd.Parameters.Add(new SqlParameter("@SearchText", searchText));

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
                            objissue.CreatedDate = DBNull.Value.Equals(reader["IssueRaiseDate"]) ? DateTime.Now : Convert.ToDateTime(reader["IssueRaiseDate"]);//9
                            objissue.ClientNameID = DBNull.Value.Equals(reader["ClientNameID"]) ? 0 : Convert.ToInt64(reader["ClientNameID"]);//10
                            objissue.CompanyName = DBNull.Value.Equals(reader["ClientName"]) ? string.Empty : Convert.ToString(reader["ClientName"]);//11
                            objissue.IssueType = DBNull.Value.Equals(reader["IssueType"]) ? string.Empty : Convert.ToString(reader["IssueType"]);//12
                            objissue.Filecount = DBNull.Value.Equals(reader["Filecount"]) ? 0 : Convert.ToInt16(reader["Filecount"]);//13
                            objissue.IssueDate2 = DBNull.Value.Equals(reader["IssueDate"]) ? string.Empty : Convert.ToString(reader["IssueDate"]);//14
                            objissue.IssueTypeID = DBNull.Value.Equals(reader["Filecount"]) ? 0 : Convert.ToInt16(reader["Filecount"]);//15
                            objissue.ProductName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);//16
                            objissue.ProductID = DBNull.Value.Equals(reader["Productid"]) ? 0 : Convert.ToInt64(reader["Productid"]);//17
                            
                            objissue.TotalRecords = TotalRecords;

                            objissuelist.Add(objissue);
                        }
                    }

                }

                return objissuelist;
            }
        }

    

        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static System.Drawing.Image ResizeImage(int newSize, System.Drawing.Image originalImage)
        {
            if (originalImage.Width <= newSize)
                newSize = originalImage.Width;

            var newHeight = originalImage.Height * newSize / originalImage.Width;

            if (newHeight > newSize)
            {
                // Resize with height instead
                newSize = originalImage.Width * newSize / originalImage.Height;
                newHeight = newSize;
            }

            return originalImage.GetThumbnailImage(newSize, newHeight, null, IntPtr.Zero);
        }


        public JsonResult Bindtodropdown(Int16 id)
        {
            HttpRuntime.Cache["id1"] = id;
            ClientIssueRaiseServiceClient opbillingproxy1 = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));

            var colourList = opbillingproxy1.ListModuleName(id);
            var colourData = colourList.Select(c => new SelectListItem()
            {
                Text = c.ModuleName,
                Value = c.ModuleID.ToString(),


            });

            return Json(colourData, JsonRequestBehavior.AllowGet);
        }

        
      

        public ActionResult DeleteIssueRaiseById(ClientIssueRaise Dltproperty)
        {
            ClientIssueRaiseServiceClient objdeleteproxy = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));
            Boolean result = objdeleteproxy.DeleteIssueRaiseById(Dltproperty);


            if(result == true)
            {
                return this.Json(new { success = 1 });

            }
            else {
                return this.Json(new { success = 0 });
            }
        }





        #region File

        public JsonResult GetAllFileById(int IssueDetailID)
        {
            ClientIssueRaiseServiceClient objClientIssueRaise = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));
            var data = objClientIssueRaise.GetAllFileById(Convert.ToInt64(IssueDetailID));
            return this.Json(data, JsonRequestBehavior.AllowGet);

        }
        public FileContentResult GetFile(int id)
        {

            byte[] FileContent = null;
            
            string FileName = "";
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr;

            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_GetClientDocument", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fileId", id));
                    cmd.Parameters.Add(new SqlParameter("@clientID", Convert.ToInt64(Session["ClientID"])));
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //id = DBNull.Value.Equals(rdr["Id"]) ? 0 : Convert.ToInt16(rdr["Id"]);
                        FileContent = (byte[])rdr["Byte"];
                       // Mime_Type = rdr["MimeType"].ToString();
                        FileName = rdr["FileName"].ToString();
                    }
                }

                
                return File(FileContent, FileName);

            }
        }
        public FileContentResult DownloadFile(int id)
        {

            byte[] FileContent = null;
            string Mime_Type = "";
            string FileName = "";
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr;

            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_GetClientDocument", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fileId", id));
                    cmd.Parameters.Add(new SqlParameter("@clientID", Convert.ToInt64(Session["ClientID"])));
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = DBNull.Value.Equals(rdr["Id"]) ? 0 : Convert.ToInt16(rdr["Id"]);
                        FileContent = (byte[])rdr["Byte"];
                        Mime_Type = rdr["MimeType"].ToString();
                        FileName = rdr["FileName"].ToString();
                    }
                }
                if (Mime_Type == "image/jpeg")
                {
                    FileName = FileName + ".jpeg";

                }

                return File(FileContent, Mime_Type, FileName);

            }
        }
        public Boolean DeleteFileById(FileUpload file)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;
            Int64 Recordsaffected = 0;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_DeleteClientDocument", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fileId", file.FileId));
                    cmd.Parameters.Add(new SqlParameter("@ClientID", file.ClientID));
                    cmd.Parameters.Add(new SqlParameter("@userID", file.CreatedBy));
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
        #endregion

        public JsonResult CreateIssue(ClientIssueRaise IssueDetails, List<FileUpload> Fileupload, List<FileUpload> DelListobj)
        {
            using (TransactionScope objScope = new TransactionScope())
            {
                try
                {
                    
                    ClientIssueRaiseServiceClient objcreate = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));
                    var result = objcreate.Create(IssueDetails, Fileupload, DelListobj);


                    objScope.Complete();

                    if (result > 0)
                    {
                        return Json(new { Success = 1 });

                    }
                    else
                    {
                        return Json(new { Success = 2 });

                    }
                }
                catch (Exception e)
                {
                    objScope.Dispose();
                    throw e;
                }
             
            }
        }
        //    public JsonResult CreateIssue(ClientIssueRaise IssueDetails, List<FileUpload> Fileupload, List<FileUpload> DelListobj)
        //{

        //    using (TransactionScope objScope = new TransactionScope())
        //    {
        //        try
        //        {
        //            List<FileUpload> objdel = null;
        //            ClientIssueRaiseServiceClient objcreate = new ClientIssueRaiseServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "ClientIssueRaiseService.svc")));
        //            var result = Create1(IssueDetails);

        //            if (Fileupload != null)
        //            {
        //                foreach (FileUpload objfiles in Fileupload)
        //                {

        //                    objfiles.IssueDetailId = Convert.ToInt64(result);
        //                    UploadFile(objfiles);
        //                }
        //            }



        //            if (DelListobj != null)
        //            {
        //                foreach (FileUpload file in DelListobj)
        //                {

        //                    DeleteFileById(file);
        //                }
        //            }


        //            objScope.Complete();

        //            if (result > 0)
        //            {
        //                return Json(new { Success = 1 });

        //            }
        //            else
        //            {
        //                return Json(new { Success = 2 });

        //            }
        //        }

        //        catch (Exception e)
        //        {
        //            objScope.Dispose();
        //            throw e;
        //        }
        //    }
        //}



        public Int64 Create1(ClientIssueRaise objissueDtl)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int RecordAffected = 0;

            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("Sp_CreateIssueRaiseDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IsSave", objissueDtl.IsSave));
                    if (objissueDtl.IsSave == 1)
                    {
                        cmd.Parameters.Add(new SqlParameter("@IssueRaiseDetailID", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@IssueRaiseDetailID", objissueDtl.IssueID));
                    }


                    cmd.Parameters.Add(new SqlParameter("@IssueDescription", objissueDtl.Description));
                    cmd.Parameters.Add(new SqlParameter("@ClientNameId", objissueDtl.ClientNameID));
                    cmd.Parameters.Add(new SqlParameter("@ClientName", objissueDtl.ClientName));
                    cmd.Parameters.Add(new SqlParameter("@IssueRaiseDate", objissueDtl.IssueDate));
                    cmd.Parameters.Add(new SqlParameter("@ApprovalFlag", objissueDtl.AssignedID));
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", objissueDtl.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@ModuleID", objissueDtl.ModuleID));
                    cmd.Parameters.Add(new SqlParameter("@ModuleName", objissueDtl.ModuleName));
                    cmd.Parameters.Add(new SqlParameter("@FormID", objissueDtl.FormID));
                    cmd.Parameters.Add(new SqlParameter("@FormName", objissueDtl.FormName));
                    cmd.Parameters.Add(new SqlParameter("@Productid", objissueDtl.ProductID));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", objissueDtl.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@ClientID", objissueDtl.ClientID));
                
                    cmd.Parameters.Add(new SqlParameter("@IssueType", objissueDtl.IssueType));
                    cmd.Parameters.Add(new SqlParameter("@IssueTypeId", objissueDtl.IssueTypeID));

                    IDbDataParameter param = new SqlParameter("@@guid", DBNull.Value);
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
            SqlCommand cmd = null;
            SqlConnection con = null;
            string ExpectedImagePrefix = "data:" + files.FileType + ";base64,";
            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("Sp_SaveClientDocuments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IsSave", files.IsSave));
                    if (files.IsSave == 1)
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", DBNull.Value));
                        string base64 = files.FileContent.Substring(ExpectedImagePrefix.Length);
                        files.StringContent = Convert.FromBase64String(base64);
                        cmd.Parameters.Add(new SqlParameter("@Byte", files.StringContent));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", files.FileId));
                        cmd.Parameters.Add(new SqlParameter("@Byte", 0));

                    }
                    cmd.Parameters.Add(new SqlParameter("@FileName", files.FileName));
                    cmd.Parameters.Add(new SqlParameter("@IssueDetailID", files.IssueDetailId));
                    cmd.Parameters.Add(new SqlParameter("@MimeType", files.FileType));
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", files.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@ClientID", files.ClientID));
                    IDbDataParameter param = new SqlParameter("@@guid", DBNull.Value);
                    
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    files.FileId = Convert.ToInt64(param.Value);


                }

            }

            return files.FileId;

        }


    



    }
}