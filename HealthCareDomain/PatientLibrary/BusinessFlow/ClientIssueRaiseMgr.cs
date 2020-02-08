using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatientLibrary.DataAccess;
using HealthCareObjects.Client;
using System.Data;
using HospitalManagement;
using System.Transactions;

namespace PatientLibrary.BusinessFlow
{
    [Serializable]
    public class ClientIssueRaiseMgr
    {

        public Int64 Create(ClientIssueRaise IssueDetails, List<FileUpload> Fileupload, List<FileUpload> DelListobj)
        {
            Int64 result = 0;
            using (TransactionScope objScope = new TransactionScope())
            {
                try
                {
                    
                    List<FileUpload> objdel = null;
                    ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
                     result = objissueDB.Create(IssueDetails);

                    if (Fileupload != null)
                    {
                        foreach (FileUpload objfiles in Fileupload)
                        {

                            objfiles.IssueDetailId = Convert.ToInt64(result);
                            objissueDB.UploadFile(objfiles);
                        }
                    }



                    if (DelListobj != null)
                    {
                        foreach (FileUpload file in DelListobj)
                        {

                            objissueDB.DeleteFileById(file);
                        }
                    }


                    objScope.Complete();

                    return result;

                }

                catch (Exception e)
                {
                    objScope.Dispose();
                    throw e;
                }
            }
        }



        public List<FileUpload> GetAllFileById(Int64 IssueDetailID)
        {
            ClientIssueRaiseDA objissueDtlDB = new ClientIssueRaiseDA();
            return objissueDtlDB.GetAllFileById(IssueDetailID);

        }
        public List<ClientIssueRaiseDtl> ListByID(Int64 issueId, Int32 sNo)
        {
            ClientIssueRaiseDtlDA objissueDtlDB = new ClientIssueRaiseDtlDA();
            return objissueDtlDB.ListByDetailID(issueId, sNo);
        }

        public string AutoID(int ClientID)
        {
            ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
            return objissueDB.AutoID(ClientID);
        }


        public List<ClientIssueRaise> ListMainPage(int PageNO, int RowperPage, int ClientID, int UserID, string searchText)
        {
            try
            {
                ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
                return objissueDB.ListMainPage(PageNO, RowperPage, searchText, ClientID, UserID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteIssueRaiseById(ClientIssueRaise Dltproperty)
        {
            ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
            if (objissueDB.DeleteIssueRaiseById(Dltproperty))
            {
                return true;
            }
            return false;
        }
        public List<ClientIssueRaise> clientList(Int64 UserID)
        {
            ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
            return objissueDB.clientList(UserID);
        }














        public List<Department> ListDepartmentName()
        {
            try
            {
                ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
                return objissueDB.ListDepartmentName();

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
                ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
                return objissueDB.ListModuleName(ClientID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClientIssueRaiseDtl> ListFormName(Int64 ModuleID)//,int ClientID)
        {
            try
            {
                ClientIssueRaiseDA objissueDB = new ClientIssueRaiseDA();
                return objissueDB.ListFormName(ModuleID);//, ClientID);
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
                ClientIssueRaiseDtlDA objissueDB = new ClientIssueRaiseDtlDA();
                return objissueDB.ListCompltIssueNo();
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
                ClientIssueRaiseDtlDA objissueDB = new ClientIssueRaiseDtlDA();
                return objissueDB.ListIssueDate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AutoIDSelf()
        {
            ClientIssueRaiseDtlDA objissueDB = new ClientIssueRaiseDtlDA();
            return objissueDB.AutoIDSelf();
        }
        public string FileuploadBal(Int64 id)
        {
            ClientIssueRaiseDtlDA objupload = new ClientIssueRaiseDtlDA();
            return objupload.FileuploadDal(id);
        }
    }
}
