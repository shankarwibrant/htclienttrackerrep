using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
    public class ClientIssueEntryDtl
    {

        #region PrivateMember
        private Int64 _sNo;
        private string _to;
        private string _cc;
        private string _subject;
        private string _FeatureName;
        private Int64 _productID;
        private string _productName;
        private Int64 _issueDetailID;
        private string _issueDescription;
        private Int64 _issueID;
        private Int64 _activeflage;
        private Int64 _createdBy;
        private string _createdName;
        private DateTime _createdDate;
        private Int64 _cilentID;
        private Int64 _sNO;
        private string _ModuleName;
        private string _ModuleID;
        private string _FormName;
        private string _FormID;
        private Int64 _ModuleTypeID;
        private string _CompltIssueNo;
        private Int64 _AssignedID;
        private int _SelfAssign;
        private string _priority;
        private Int64 _issueClientID;
        private Int64 _aaprovalflag;
        private DateTime _dueDate;
        private Int64 _assignedTo;
        private Int64 _PastIssueDetailID;
        private string _clientName;
        private Int64 _fileID;
        private string _fileName;
        private string _fileTye;
        private byte[] _fileContent;
        private string _IssueType;
        private Int32 _IssueTypeId;
        private Int32 _FeatureNameId;
        private Int32 _FileCount;
        private DateTime _IssueDate1;
        private string _IssueDate2;
        private List<string> _totalComments;

        #endregion

        #region PublicMember

        [DataMember]
        public string FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value; }
        }
        [DataMember]
        public string CreatedName
        {
            get { return _createdName; }
            set { _createdName = value; }
        }

        [DataMember]
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        [DataMember]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        [DataMember]
        public Int64 ProductId
        {
            get { return _productID; }
            set { _productID = value; }

        }
        [DataMember]
        public Int64 FileId
        {
            get { return _fileID; }
            set { _fileID = value; }

        }
        [DataMember]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        [DataMember]
        public string FileType
        {
            get { return _fileTye; }
            set { _fileTye = value; }
        }
        [DataMember]
        public byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }
        [DataMember]
        public Int32 FileUploadFlag { get; set; }

        [DataMember]
        public string closedname { get; set; }

        [DataMember]

        public DateTime closeddate { get; set; }


        [DataMember]
        public Int64 IssueDetailID
        {
            get { return _issueDetailID; }
            set { _issueDetailID = value; }
        }
        [DataMember]
        public Int64 PastIssueDetailID
        {
            get { return _PastIssueDetailID; }
            set { _PastIssueDetailID = value; }
        }

        [DataMember]
        public string IssueDescription
        {
            get { return _issueDescription; }
            set { _issueDescription = value; }
        }
        [DataMember]
        public Int64 IssueID
        {
            get { return _issueID; }
            set { _issueID = value; }
        }
        [DataMember]
        public Int64 Activeflage
        {
            get { return _activeflage; }
            set { _activeflage = value; }
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
        }
        [DataMember]
        public Int64 CilentID
        {
            get { return _cilentID; }
            set { _cilentID = value; }
        }
        [DataMember]
        public Int64 SNO
        {
            get { return _sNO; }
            set { _sNO = value; }
        }

        [DataMember]
        public string ModuleID
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
        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }

        [DataMember]
        public string FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }
        [DataMember]
        public string CompltIssueNo
        {
            get { return _CompltIssueNo; }
            set { _CompltIssueNo = value; }
        }
        public Int64 ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }

        [DataMember]
        public Int64 AssignedID
        {
            get { return _AssignedID; }
            set { _AssignedID = value; }
        }
        [DataMember]
        public int SelfAssign
        {
            get { return _SelfAssign; }
            set { _SelfAssign = value; }
        }

        [DataMember]
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        [DataMember]
        public Int64 IssueClientID
        {
            get { return _issueClientID; }
            set { _issueClientID = value; }
        }
        [DataMember]
        public Int64 Aaprovalflag
        {
            get { return _aaprovalflag; }
            set { _aaprovalflag = value; }
        }

        [DataMember]
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        [DataMember]
        public Int64 AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }
        [DataMember]
        public string IssueType
        {
            get { return _IssueType; }
            set { _IssueType = value; }
        }
        [DataMember]
        public Int32 IssueTypeId
        {
            get { return _IssueTypeId; }
            set { _IssueTypeId = value; }
        }


        public Int32 FeatureNameId
        {
            get { return _FeatureNameId; }
            set { _FeatureNameId = value; }
        }
        [DataMember]
        public Int32 FileCount
        {
            get { return _FileCount; }
            set { _FileCount = value; }

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


        [DataMember]
        public Int64 SNo
        {
            get { return _sNo; }
            set { _sNo = value; }
        }
        private string _Body;
        [DataMember]
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        public string _From;
        [DataMember]
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        [DataMember]
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        [DataMember]
        public string CC
        {
            get { return _cc; }
            set { _cc = value; }
        }
        private string _BCC;
        [DataMember]
        public string BCC
        {
            get { return _BCC; }
            set { _BCC = value; }
        }
        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        [DataMember]
        public List<string> totalComments
        {
            get { return _totalComments; }
            set { _totalComments = value; }
        }
        #endregion
    }
}
