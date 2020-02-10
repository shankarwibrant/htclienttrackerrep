using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace HealthCareObjects.Client
{
    [DataContract]
    public class ClientIssueRaise
    {
        #region PrivateMember
        private Int64 _issueID;
        
        private Int64 _issuedBy;
        private string _departmentID;
        private string _departmentName;
        private string _issueSubject;
        private Int64 _clientID;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private DateTime? _createdDate2;
        private string _createdDate1;
        private string _companyName;
        private Int64 _activeflage;
        private DateTime? _issueDate;
        private Int64 _git;
        private Int64 _git1;
        private Int64 _totalRecords;
        private string _FullName;
        private string _FullName1;
        private string _cIssueID;
        private Int64 _ContactNo;
        private string _EmailId;
        private string _SerialNo;
        private string _ProductNo;
        private DateTime _DateofIntialization;
        private string _clientName;
        private Int64 _clientNameID;
        private string _filename;
        private byte[] _file;
        private Int64 _ClientAddressID;
        private string _ModuleName;
        private Int64 _ModuleID;
        private string _FormName;
        private string _FeatureName;

        private Int64 _FormID;

        private Int64 _userID;
        private string _compltIssueNo;
        private string _ShortName;


        private Int64 _SNo;
        private int _SelfAssign;

        private string _IssueType;
        private Int64 _FeatureID;
        private Int64 _Filecount;

        private Int64 _IssueTypeNameId;
        private DateTime _IssueDate1;
        private string _IssueDate2;

        private Int32 _IssueTypeID;

        private Int64 _AssignedID;

        private Int64 _FileUploadFlag;
        private Int32 _IsSave;

        private Int64 _ProductID;
        private string _ProductName;

        #endregion

        #region PublicMember

        [DataMember]
        public string ProductName
        {

            get { return _ProductName; }
            set { _ProductName = value; }

        }

        [DataMember]
        public Int64 ProductID
        {

            get { return _ProductID; }
            set { _ProductID = value; }

        }

        [DataMember]
        public Int32 IsSave
        {

            get { return _IsSave; }
            set { _IsSave = value; }

        }


        [DataMember]
        public Int64 FileUploadFlag
        {

            get { return _FileUploadFlag; }
            set { _FileUploadFlag = value; }

        }

        [DataMember]
        public Int64 AssignedID
        {

            get { return _AssignedID; }
            set { _AssignedID = value; }

        }

        [DataMember]
        public Int32 IssueTypeID
        {

            get { return _IssueTypeID; }
            set { _IssueTypeID = value; }

        }


        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Int64 UserID
        {

            get { return _userID; }
            set { _userID = value; }

        }

        [DataMember]
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }

        }
        [DataMember]
        public string CompltIssueNo
        {
            get { return _compltIssueNo; }
            set { _compltIssueNo = value; }

        }
        [DataMember]
        public Int64 ClientNameID
        {
            get { return _clientNameID; }
            set { _clientNameID = value; }
        }
        [DataMember]
        public string fileName
        {
            get { return _filename; }
            set { _filename = value; }

        }
        [DataMember]
        public byte[] File
        {
            get { return _file; }
            set { _file = value; }
        }
        [DataMember]
        public Int64 IssueID
        {
            get { return _issueID; }
            set { _issueID = value; }
        }

        [DataMember]
        public Int64 IssuedBy
        {
            get { return _issuedBy; }
            set { _issuedBy = value; }
        }
        [DataMember]
        public string DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
        [DataMember]
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        [DataMember]
        public string IssueSubject
        {
            get { return _issueSubject; }
            set { _issueSubject = value; }
        }
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }[DataMember]
        public DateTime? CreatedDate2
        {
            get { return _createdDate2; }
            set { _createdDate2 = value; }
        }
        [DataMember]
        public string CreatedDate1
        {
            get { return _createdDate1; }
            set { _createdDate1 = value; }
        }
        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        [DataMember]
        public Int64 Activeflage
        {
            get { return _activeflage; }
            set { _activeflage = value; }
        }
        [DataMember]

        public DateTime? IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }
        [DataMember]
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        [DataMember]
        public string CIssueID
        {
            get { return _cIssueID; }
            set { _cIssueID = value; }
        }

        [DataMember]
        public Int64 ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        [DataMember]
        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        [DataMember]
        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        [DataMember]
        public string ProductNo
        {
            get { return _ProductNo; }
            set { _ProductNo = value; }
        }
        [DataMember]
        public DateTime DateofIntialization
        {
            get { return _DateofIntialization; }
            set { _DateofIntialization = value; }
        }
        [DataMember]
        public Int64 ClientAddressID
        {
            get { return _ClientAddressID; }
            set { _ClientAddressID = value; }
        }
        [DataMember]
        public Int64 ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }

        }
        [DataMember]
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }

        }


        [DataMember]
        public string FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value; }

        }
        [DataMember]
        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }
        [DataMember]
        public Int64 FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }
        [DataMember]
        public string ShortNmae
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        [DataMember]
        public Int64 SNo
        {
            get { return _SNo; }
            set { _SNo = value; }

        }
        [DataMember]
        public int SelfAssign
        {
            get { return _SelfAssign; }
            set { _SelfAssign = value; }
        }

        [DataMember]
        public string IssueType
        {
            get { return _IssueType; }
            set { _IssueType = value; }
        }
        [DataMember]
        public Int64 FeatureID
        {

            get { return _FeatureID; }
            set { _FeatureID = value; }

        }

        [DataMember]
        public Int64 Filecount
        {
            get { return _Filecount; }
            set { _Filecount = value; }
        }

        [DataMember]
        public Int64 IssueTypeNameId
        {
            get { return _IssueTypeNameId; }
            set { _IssueTypeNameId = value; }
        }
        [DataMember]
        public DateTime IssueDate1
        {
            get { return _IssueDate1; }
            set { _IssueDate1 = value; }
        }
        [DataMember]
        public string IssueDate2
        {
            get { return _IssueDate2; }
            set { _IssueDate2 = value; }
        }

        #endregion
    }
}
