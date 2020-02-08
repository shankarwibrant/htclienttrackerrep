using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HealthCareObjects.Client;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClientIssueRaiseService" in both code and config file together.
    [ServiceContract]
    public interface IClientIssueRaiseService
    {
        [OperationContract]
        Int64 Create(ClientIssueRaise IssueDetails, List<FileUpload> Fileupload, List<FileUpload> DelListobj);
        [OperationContract]
        Boolean DeleteIssueRaiseById(ClientIssueRaise Dltproperty);
        [OperationContract]
        List<ClientIssueRaise> ListMainpage(int PageNO, int RowperPage, int ClientID, int UserID, string searchText);
        [OperationContract]
        List<ClientIssueRaise> clientList(Int64 UserID);

        [OperationContract]
        ClientIssueRaiseDtl UpdateIssueEntrys(string idString, ClientIssueRaiseDtl objissuedtllist, List<FileUpload> objFileUpload);
        [OperationContract]
        Boolean SaveRecord(List<ClientIssueRaiseDtl> objissueDtl);
        [OperationContract]
        List<FileUpload> GetAllFileById(Int64 IssueDetailID);
        [OperationContract]
        List<ClientIssueRaiseDtl> ListByDtLID(Int64 IssueID, Int32 sNo);
        [OperationContract]
        string AutoID(int ClientID);
        [OperationContract]
        List<Department> ListDepartmentName();
        
        
        [OperationContract]
        List<ClientInformation> ListModuleName(int ClientID);
        [OperationContract]
        List<ClientIssueRaiseDtl> ListFormName(Int64 ModuleID);//, int ClientID);
        
        [OperationContract]
        string ListCompltIssueNo();
        [OperationContract]
        List<Feature> ListFeatureName(Int64 FormID);
        [OperationContract]
        string ListIssueDate();
        [OperationContract]
        string AutoIDSelf();
        [OperationContract]
        List<ClientIssueRaiseDtl> PastIssueSearch(Int64 clientId, Int64 moduleId, Int64 formId);
        [OperationContract]
        string FileuploadSer(Int64 id);
    }
}
