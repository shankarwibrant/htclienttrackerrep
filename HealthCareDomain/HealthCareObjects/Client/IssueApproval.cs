using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
    public class IssueApproval
    {
        #region PrivateMember

        private Int64 _issueDetailID;
        private string _issueDescription;
        private Int64 _issueID;
        private Int64 _activeflage;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private Int64 _cilentID;
        private Int64 _sNO;
        private string _status;
        private Int64 _aaprovalflag;
        private DateTime _approvalDate;
        private Int64 _departmentID;
        private string _departmentName;
        private string _priority;

        private DateTime _dueDate;
        private DateTime _startDate;
        private string _ourDescribtion;
        private Int64 _totalRecords;
        private string _companyName;
        private Int64 _developerID;
        private Int64 _assignedTo;
        private string _developerName;
        private Int64 _assignID;
        private string _IsIssueNO;
        private string _assignedName;
        private string _assignedBy;
        private DateTime _closedDate;
        private string _cIssueID;
        private string _totalComplient;
        private string _isCompany;
        private Int64 _issueClientID;
        private string _dailyUpdate;
        private string _shortName;

        private Int64 _userID;
        private string _userName;
        private string _userFullName;
        private string _issueSubject;

        private string _fromDate;
        private string _toDate;
        private string _modulename;
        private string _formname;

        private string _FeatureName;
        private string _issuesimple;
        private string _CompltIssueNo;
        //private DateTime _fromdate;
        //private DateTime _toDate;
        private string _Assignee;
        private int _Fileuploadflag;
        private string _PriorityName;
        private string _SeverityName;
        private Int64 _SeverityId;
        private Int64 _PriorityId;
        private Int64 _IssueFromId;
        private string _IssueFrom;


        #endregion

        #region PublicMember
        [DataMember]
        public string NoOfDays { get; set; }
        [DataMember]
        public string CompltIssueNo
        {
            get { return _CompltIssueNo; }
            set { _CompltIssueNo = value; }

        }
        [DataMember]
        public string Issuesimple
        {
            get { return _issuesimple; }
            set { _issuesimple = value; }
        }
        [DataMember]
        public string Modulename
        {
            get { return _modulename; }
            set { _modulename = value; }
        }

        [DataMember]
        public string Formname
        {
            get { return _formname; }
            set { _formname = value; }
        }




        [DataMember]
        public string FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        [DataMember]
        public string ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
        [DataMember]
        public string IssueSubject
        {
            get { return _issueSubject; }
            set { _issueSubject = value; }
        }

        [DataMember]
        public string UserFullName
        {
            get { return _userFullName; }
            set { _userFullName = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }


        [DataMember]
        public Int64 IssueDetailID
        {
            get { return _issueDetailID; }
            set { _issueDetailID = value; }
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
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        [DataMember]
        public Int64 Aaprovalflag
        {
            get { return _aaprovalflag; }
            set { _aaprovalflag = value; }
        }
        [DataMember]
        public DateTime ApprovalDate
        {
            get { return _approvalDate; }
            set { _approvalDate = value; }
        }
        [DataMember]

        public Int64 DepartmentID
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

        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        [DataMember]
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        [DataMember]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        [DataMember]
        public string OurDescribtion
        {
            get { return _ourDescribtion; }
            set { _ourDescribtion = value; }
        }
        [DataMember]
        public Int64 AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }
        [DataMember]
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        [DataMember]
        public Int64 DeveloperID
        {
            get { return _developerID; }
            set { _developerID = value; }
        }
        [DataMember]
        public string DeveloperName
        {
            get { return _developerName; }
            set { _developerName = value; }
        }
        [DataMember]
        public Int64 AssignID
        {
            get { return _assignID; }
            set { _assignID = value; }
        }

        [DataMember]
        public string IsIssueNO
        {
            get { return _IsIssueNO; }
            set { _IsIssueNO = value; }
        }
        [DataMember]
        public string AssignedName
        {
            get { return _assignedName; }
            set { _assignedName = value; }
        }
        [DataMember]
        public string AssignedBy
        {
            get { return _assignedBy; }
            set { _assignedBy = value; }
        }
        [DataMember]
        public DateTime ClosedDate
        {
            get { return _closedDate; }
            set { _closedDate = value; }
        }
        [DataMember]
        public string CIssueID
        {
            get { return _cIssueID; }
            set { _cIssueID = value; }
        }
        [DataMember]
        public string TotalComplient
        {
            get { return _totalComplient; }
            set { _totalComplient = value; }
        }
        [DataMember]
        public string IsCompany
        {
            get { return _isCompany; }
            set { _isCompany = value; }
        }
        [DataMember]
        public Int64 IssueClientID
        {
            get { return _issueClientID; }
            set { _issueClientID = value; }
        }
        [DataMember]
        public string DailyUpdate
        {
            get { return _dailyUpdate; }
            set { _dailyUpdate = value; }
        }
        [DataMember]
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }
        //[DataMember]
        //public DateTime FromDate
        //{
        //    get { return _fromdate; }
        //    set { _fromdate = value; }
        //}
        //[DataMember]
        //public DateTime ToDate
        //{
        //    get { return _toDate; }
        //    set { _toDate = value; }
        //}
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        [DataMember]
        public string Assignee
        {
            get { return _Assignee; }
            set { _Assignee = value; }
        }


        [DataMember]

        public int FileUploadflag
        {
            get { return _Fileuploadflag; }
            set { _Fileuploadflag = value; }

        }
        [DataMember]
        public string FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value; }
        }
        [DataMember]
        public string PriorityName
        {
            get { return _PriorityName; }
            set { _PriorityName = value; }
        }

        [DataMember]
        public string SeverityName
        {
            get { return _SeverityName; }
            set { _SeverityName = value; }
        }


        [DataMember]

        public Int64 SeverityId
        {
            get { return _SeverityId; }
            set { _SeverityId = value; }

        }
        [DataMember]

        public Int64 PriorityId
        {
            get { return _PriorityId; }
            set { _PriorityId = value; }

        }
        [DataMember]

        public Int64 IssueFromId
        {
            get { return _IssueFromId; }
            set { _IssueFromId = value; }

        }

        [DataMember]
        public string IssueFrom
        {
            get { return _IssueFrom; }
            set { _IssueFrom = value; }
        }
        #endregion
    }
}
