using HealthCareMvc5.Controllers.Common;
using HealthCareMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.ServiceModel;
using System.Web.Mvc;
using HealthCareMvc5.IssueApprovalServiceRef;
using HealthCareMvc5.LogInServiceReference;
using HealthCareObjects.UserRights;
using HealthCareMvc5.CompliantApprovalServiceRef;

namespace HealthCareMvc5.Controllers
{
    public class FinalApprovalController : Controller
    {
        string Servicepath = Convert.ToString(WebConfigurationManager.AppSettings["ServicePath"]);
        string ConnectionString = Convert.ToString(WebConfigurationManager.AppSettings["ConnectionString"]);
        // GET: IssueApproval

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addnewpartialview()
        {
            IssueApprovalServiceClient objclient = new IssueApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "IssueApprovalService.svc")));
            var lisclient = objclient.clientList(Convert.ToInt16(Session["UserId"]));
            ViewBag.list = new SelectList(lisclient.AsEnumerable(), "ClientNameID", "ClientName");

            List<Login1> finallist = new List<Login1>();
            var log = (Login1)Session["UserList"];

            Session["UserName"] = log.UserName;
            Session["UserId"] = log.UserID;
            Session["CilentID"] = log.ClientID;

            Session["RoleID"] = log.RoleID;

            return View();
        }
        public ActionResult BindGrid(string iId10)
        {

            IssueApprovalServiceClient obj = new IssueApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "IssueApprovalService.svc")));

            var listall2 = obj.ListGrid(Convert.ToInt64(iId10));

            return this.Json(listall2);

        }
        public JsonResult Create(List<IssueApprovalServiceRef.CompliantApproval> approvalList)
        {
            IssueApprovalServiceClient opbillingproxy = new IssueApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "IssueApprovalService.svc")));

            approvalList = approvalList ?? new List<IssueApprovalServiceRef.CompliantApproval>();

            if (opbillingproxy.ListUpdate(approvalList))
            {
                return Json(new { success = 1 }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = 2 }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult AjaxHandler(int value, jQueryDataTableParamModel param)
        {
            int clientId = value;
            int TotalRecords = 0;
            param.PageNo = ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength) == 0 ? 1 : ((param.iDisplayStart + param.iDisplayLength) / param.iDisplayLength);
            param.RowsPerPage = param.iDisplayLength;

            IssueApprovalServiceClient ws = new IssueApprovalServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "IssueApprovalService.svc")));

            var a = ws.ListMainPagebyUserID(param.PageNo, param.RowsPerPage, Convert.ToInt16(Session["UserId"]), clientId, param.sSearch == null ? string.Empty : param.sSearch);
            var result = from c in a
                             //select new[] { c.Issuesimple, c.IssueDescription, c.Modulename, c.Formname,c.FeatureName, c.UserFullName, c.ApprovalDate.ToString("dd/MM/yyyy"), c.DueDate.ToString("dd/MM/yyyy"), c.IssueDetailID.ToString(), c.IssueID.ToString(), c.CilentID.ToString(), c.IssueClientID.ToString(), c.Priority, c.Aaprovalflag.ToString(), c.FileUploadflag.ToString()};

                         select new[] { c.Issuesimple,//0
                         c.CreatedDate.ToString("dd/MM/yyyy"),//1
                             c.CompanyName,//2
                             c.FeatureName,//6
                             c.Modulename,//4
                             c.Formname,//5
                             c.IssueDescription,//9
                             c.UserFullName,//7
                             c.PriorityName,//3
                             c.Aaprovalflag.ToString(),//8
                             
                             c.IssueDetailID.ToString(),//10
                             c.CilentID.ToString(),//11
                             c.FileUploadflag.ToString(),//12
                             c.SeverityName,//13
                             c.IssueFrom,//14
                             };

            foreach (var river in a)
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
    }
}