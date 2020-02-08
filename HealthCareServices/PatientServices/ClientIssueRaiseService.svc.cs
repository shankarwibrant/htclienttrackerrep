using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HealthCareObjects.Client;
using PatientLibrary.BusinessFlow;


namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClientIssueRaiseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClientIssueRaiseService.svc or ClientIssueRaiseService.svc.cs at the Solution Explorer and start debugging.
    public class ClientIssueRaiseService : IClientIssueRaiseService
    {
        public Int64 Create(ClientIssueRaise IssueDetails, List<FileUpload> Fileupload, List<FileUpload> DelListobj)
        {
            ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
            return objissuemgr.Create(IssueDetails, Fileupload, DelListobj);
        }
      

        public Boolean DeleteIssueRaiseById(ClientIssueRaise Dltproperty)
        {
            ClientIssueRaiseMgr objIssueEntryDBops = new ClientIssueRaiseMgr();
            return objIssueEntryDBops.DeleteIssueRaiseById(Dltproperty);

        }

        public List<FileUpload> GetAllFileById(Int64 IssueDetailID)
        {
            ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
            return objissuemgr.GetAllFileById(IssueDetailID);

        }

        public List<ClientIssueRaise> ListMainpage(int PageNO, int RowperPage, int ClientID, int UserID, string searchText)
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListMainPage(PageNO, RowperPage, ClientID, UserID, searchText);

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }



        public List<ClientIssueRaiseDtl> ListByDtLID(Int64 IssueID, Int32 sNo)
        {
            ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
            return objissuemgr.ListByID(IssueID, sNo);
        }

       
        public string AutoID(int ClientID)
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.AutoID(ClientID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Department> ListDepartmentName()
        {

            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListDepartmentName();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

     
        public List<ClientIssueRaise> clientList(Int64 UserID)
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.clientList(UserID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClientInformation> ListModuleName(int ClientID)
        {

            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListModuleName(ClientID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClientIssueRaiseDtl> ListFormName(Int64 ModuleID)//, int ClientID)
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListFormName(ModuleID);//, ClientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Feature> ListFeatureName(Int64 FormID)
        {
            try
            {
                FormFeatureMgr objff = new FormFeatureMgr();
                return objff.ListFeatureName(FormID);//, ClientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ListCompltIssueNo()
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListCompltIssueNo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ListIssueDate()
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.ListIssueDate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AutoIDSelf()
        {
            try
            {
                ClientIssueRaiseMgr objissuemgr = new ClientIssueRaiseMgr();
                return objissuemgr.AutoIDSelf();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string FileuploadSer(Int64 id)
        {
            ClientIssueRaiseMgr objfileupload = new ClientIssueRaiseMgr();
            return objfileupload.FileuploadBal(id);
        }

        public ClientIssueRaiseDtl UpdateIssueEntrys(string idString, ClientIssueRaiseDtl objissuedtllist, List<FileUpload> objFileUpload)
        {
            throw new NotImplementedException();
        }

        public bool SaveRecord(List<ClientIssueRaiseDtl> objissueDtl)
        {
            throw new NotImplementedException();
        }

        public List<ClientIssueRaiseDtl> PastIssueSearch(long clientId, long moduleId, long formId)
        {
            throw new NotImplementedException();
        }
    }
}
