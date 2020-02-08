using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data;
using System.ServiceModel;
using HealthCareMvc5.CompliantApprovalServiceRef;
using HealthCareMvc5.Controllers.Common;
using HealthCareMvc5.Models;
using System.Data.SqlClient;
using HealthCareObjects.UserRights;


namespace HealthCareMvc5.Controllers
{
    public class ClientIssueApprovalController : Controller
    {
        string Servicepath = Convert.ToString(WebConfigurationManager.AppSettings["ServicePath"]);
        string ConnectionString = Convert.ToString(WebConfigurationManager.AppSettings["ConnectionString"]);
        // GET: ClientIssueApproval
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
            Session["CilentID"] = log.ClientID;

            Session["RoleID"] = log.RoleID;
            return View();
        }
        public ActionResult maingrid(jQueryDataTableParamModel param)
        {
            CompliantApproval ca = new CompliantApproval();
            int TotalRecords = 0;
            DateTime fromDate = Convert.ToDateTime("02/02/1880");
            DateTime toDate = Convert.ToDateTime("02/02/1880");

            CompliantApprovalServiceClient gridservice = new CompliantApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "CompliantApprovalService.svc")));
            param.PageNo = ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength) == 0 ? 1 : ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength);
            param.RowsPerPage = param.iDisplayLength;
            List<CompliantApproval> gridlist = new List<CompliantApproval>();
            var local = gridservice.ListMainPage(param.PageNo, param.RowsPerPage, param.sSearch == null ? string.Empty : param.sSearch, fromDate, toDate, Convert.ToInt64(Session["UserId"]));

            var result = from c in local
                         select new[] { c.CompliantNo, c.ClientIssueNo.ToString(), c.CompanyName, c.IssueDescription, c.ModuleName, c.FormName, c.FeatureName, c.CompliantRaisedBy, c.NoOfIssue.ToString(), c.CreatedDate.ToString("dd/MM/yyyy"),c.Priority};

            foreach (CompliantApproval river in local)
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

        public ActionResult BindGrid(string iId1)
        {

            CompliantApprovalServiceClient obj = new CompliantApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "CompliantApprovalService.svc")));

            var listall = obj.ListGrid(Convert.ToInt64(iId1));

            return this.Json(listall);


        }

        public JsonResult Create(List<CompliantApproval> approvalList)
        {
            CompliantApprovalServiceClient opbillingproxy = new CompliantApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "CompliantApprovalService.svc")));

            approvalList = approvalList ?? new List<CompliantApproval>();

            if (opbillingproxy.ListUpdate(approvalList))
            {
                return Json(new { success = 1, servicePath = Servicepath },JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = 2, servicePath = Servicepath }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult CreateComments(IssueClearance objissueDtl)
        {
            CompliantApprovalServiceClient service = new CompliantApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "CompliantApprovalService.svc")));

            var retunData = service.CreateComments(objissueDtl);

            if (retunData != 0)
            {
                return Json(retunData);
            }
            else
            {
                return Json(new { success = 0, });

            }
        }

        public JsonResult GetComments(Int64 IssueDetailID)
        {


            var listdata = ListByComments(IssueDetailID, Convert.ToInt64(Session["CilentID"]));



            return Json(listdata, JsonRequestBehavior.AllowGet);

        }
        public FileContentResult mainfile(int id)
        {

            byte[] FileContent = null;
            
            string FileName = "";
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr;
            Int64 ClientId = Convert.ToInt64(Session["CilentID"]);
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_GetClientDocument", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fileId", id));
                    cmd.Parameters.Add(new SqlParameter("@clientID", ClientId));
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


        public List<HealthCareObjects.Client.IssueClearance> ListByComments(Int64 IssueDetailID, Int64 ClientID)
        {

            List<HealthCareObjects.Client.IssueClearance> CommentsList = new List<HealthCareObjects.Client.IssueClearance>();
            HealthCareObjects.Client.IssueClearance objIssueClearance = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_GetComments", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("ClientID", ClientID));
                    cmd.Parameters.Add(new SqlParameter("IssueDetailID", IssueDetailID));
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objIssueClearance = new HealthCareObjects.Client.IssueClearance();
                        objIssueClearance.CommentsID = DBNull.Value.Equals(reader["CommentsID"]) ? 0 : Convert.ToInt64(reader["CommentsID"]);
                        objIssueClearance.Comments = DBNull.Value.Equals(reader["Comments"]) ? "" : Convert.ToString(reader["Comments"]);
                        objIssueClearance.UserName = DBNull.Value.Equals(reader["UserName"]) ? "" : Convert.ToString(reader["UserName"]);
                        objIssueClearance.UserID = DBNull.Value.Equals(reader["UserID"]) ? 0 : Convert.ToInt64(reader["UserID"]);
                        objIssueClearance.CommentsDate = DBNull.Value.Equals(reader["CreatedDate"]) ? "" : Convert.ToString(reader["CreatedDate"]);
                       
                        objIssueClearance.IssueDetailID = DBNull.Value.Equals(reader["IssueDetailID"]) ? 0 : Convert.ToInt64(reader["IssueDetailID"]);
                        CommentsList.Add(objIssueClearance);
                    }
                    reader.Close();

                    return CommentsList;
                }
            }

        }
      

    }
}