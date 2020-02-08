using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
    public class IssueClearance
    {
        #region PrivateMember       
        private string _comments;
        private string _userName;
        private Int64 _branchID;
        private Int64 _userID;
        private Int64 _commentsID;
        private string _commentsDate;
        private Int64 _type;
        private Int64 _compliantNo;
        private Int64 _assignedID;
        private Int64 _taskId;
        private string _compliantDescription;
        private string _ourDescription;
        private string _reason;
        private string _dailyUpdate;
        private string _assignedBy;
        private string _status;
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _closedDate;
        private DateTime _openedDate;
        private string _priority;
        private Int64 _clientID;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private string _companyName;
        private Int64 _activeflage;
        private DateTime _issueDate;
        private Int64 _totalRecords;
        private string _username;
        private string _IsIssueNO;
        private int _SNO;
        private string _ClientIssueNo;
        private string _issueSubject;
        private Int64 _clientNameID;
        private string _filename;
        private byte[] _file;
        private string _clientName;
        private string _Address;
        private string _CustomerName;
        private Int64 _ContactNo;
        private string _CompltIssueNo;
        private string _formname;
        private Int64 _ModuleID;
        private Int64 _FormID;
        private string _modulename;

        private string _FeatureName;



        private string _FromTime;
        private string _ToTime;
        private Int64 _TaskDetailID;
        private Int64 _IssueDetailID;
        private Int64 _DepartmentID;
        private Int64 _AssignedTO;
        private Int64 _IssueID;
        //private DateTime _FromDate;
        //private DateTime _ToDate;

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
        public string CompltIssueNo
        {
            get { return _CompltIssueNo; }
            set { _CompltIssueNo = value; }

        }


        [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }

        }
        [DataMember]
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        [DataMember]
        public Int64 ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        [DataMember]
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }

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

        public long IssueID
        {
            get { return _IssueID; }

            set { _IssueID = value; }
        }


        [DataMember]

        public int FileUploadflag
        {
            get { return _Fileuploadflag; }
            set { _Fileuploadflag = value; }


        }

        #endregion

        #region Public Member
        [DataMember]
        public string IssueSubject
        {
            get { return _issueSubject; }
            set { _issueSubject = value; }
        }

        [DataMember]
        public string ClientIssueNo
        {
            get { return _ClientIssueNo; }
            set { _ClientIssueNo = value; }
        }
        [DataMember]
        public string CommentsDate
        {
            get { return _commentsDate; }
            set { _commentsDate = value; }
        }

        [DataMember]
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public Int64 CommentsID
        {
            get { return _commentsID; }
            set { _commentsID = value; }
        }
        [DataMember]
        public Int64 Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        [DataMember]
        public Int64 BranchID
        {
            get { return _branchID; }
            set { _branchID = value; }
        }

        [DataMember]
        public int SNO
        {
            get { return _SNO; }
            set { _SNO = value; }
        }

        [DataMember]
        public string IsIssueNO
        {
            get { return _IsIssueNO; }
            set { _IsIssueNO = value; }
        }

        [DataMember]
        public Int64 CompliantNo
        {
            get { return _compliantNo; }
            set { _compliantNo = value; }
        }
        [DataMember]
        public Int64 AssignedID
        {
            get { return _assignedID; }
            set { _assignedID = value; }
        }
        [DataMember]
        public Int64 TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }
        [DataMember]
        public string CompliantDescription
        {
            get { return _compliantDescription; }
            set { _compliantDescription = value; }
        }
        [DataMember]
        public string OurDescription
        {
            get { return _ourDescription; }
            set { _ourDescription = value; }
        }
        [DataMember]
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        [DataMember]
        public string DailyUpdate
        {
            get { return _dailyUpdate; }
            set { _dailyUpdate = value; }
        }
        [DataMember]
        public string AssignedBy
        {
            get { return _assignedBy; }
            set { _assignedBy = value; }
        }
        [DataMember]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        [DataMember]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        [DataMember]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        [DataMember]
        public DateTime OpenedDate
        {
            get { return _openedDate; }
            set { _openedDate = value; }
        }
        [DataMember]
        public DateTime ClosedDate
        {
            get { return _closedDate; }
            set { _closedDate = value; }
        }
        [DataMember]
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
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
        public DateTime IssueDate
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
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [DataMember]
        public Int64 FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }
        [DataMember]
        public string FormName
        {
            get { return _formname; }
            set { _formname = value; }

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
            get { return _modulename; }
            set { _modulename = value; }
        }


        [DataMember]
        public string FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value; }
        }


        [DataMember]
        public string Fromtime
        {
            get { return _FromTime; }
            set { _FromTime = value; }
        }
        [DataMember]
        public string ToTime
        {
            get { return _ToTime; }
            set { _ToTime = value; }
        }
        [DataMember]
        public Int64 TaskDetailID
        {
            get { return _TaskDetailID; }
            set { _TaskDetailID = value; }
        }
        [DataMember]
        public Int64 IssueDetailID
        {
            get { return _IssueDetailID; }
            set { _IssueDetailID = value; }
        }
        [DataMember]
        public Int64 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        [DataMember]
        public Int64 AssignTo
        {
            get { return _AssignedTO; }
            set { _AssignedTO = value; }
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


        //public DateTime Fromdate
        //{
        //    get { return _FromDate; }
        //    set { _ToDate = value; }
        //}
        //public DateTime ToDate
        //{
        //    get { return _ToDate; }
        //    set { _ToDate = value; }
        //}
        #endregion
    }
}
