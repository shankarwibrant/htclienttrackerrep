using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
    public class CompliantApproval
    {
        #region PrivateMembers
        private string _compliantNo;
        private string _compliantRaisedBy;
        private Int64 _issueid;

        private string _departmentName;
        private string _Issuesubject;
        private int _noOfIssue;

        private Int64 _clientID;
        private Int64 _UserID;
        private string _companyName;
        private DateTime _issueDate;

        private Int64 _issueDetailID;
        private string _issueDescription;
        private Int64 _sNO;

        private Int64 _approveFlag;
        private bool _activeflag;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private Int64 _modifiedBy;
        private DateTime _modifiedDate;
        private int _totalRecords;
        private Int64 _smcstatus;
        private string _priority;
        private string _overAllPriority;
        private DateTime _approvalDate;
        private Int64 _clientIssueNo;
        private string _modulename;
        private string _formname;

        private string _FeatureName;


        #endregion

        #region PublicMembers

        [DataMember]
        public Int64 Issueid
        {
            get { return _issueid; }
            set { _issueid = value; }
        }
        [DataMember]
        public Int64 Smcstatus
        {
            get { return _smcstatus; }
            set { _smcstatus = value; }
        }
        [DataMember]
        public string CompliantNo
        {
            get { return _compliantNo; }
            set { _compliantNo = value; }
        }
        [DataMember]
        public string CompliantRaisedBy
        {
            get { return _compliantRaisedBy; }
            set { _compliantRaisedBy = value; }
        }
        [DataMember]
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        [DataMember]
        public string Issuesubject
        {
            get { return _Issuesubject; }
            set { _Issuesubject = value; }
        }
        [DataMember]
        public int NoOfIssue
        {
            get { return _noOfIssue; }
            set { _noOfIssue = value; }
        }
        [DataMember]
        public Int64 ApproveFlag
        {
            get { return _approveFlag; }
            set { _approveFlag = value; }
        }
        [DataMember]
        public bool Activeflag
        {
            get { return _activeflag; }
            set { _activeflag = value; }
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
        public Int64 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public Int64 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        [DataMember]
        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
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
        public Int64 SNO
        {
            get { return _sNO; }
            set { _sNO = value; }
        }
        [DataMember]
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        [DataMember]
        public string OverAllPriority
        {
            get { return _overAllPriority; }
            set { _overAllPriority = value; }
        }

        [DataMember]
        public DateTime ApprovalDate
        {
            get { return _approvalDate; }
            set { _approvalDate = value; }
        }
        [DataMember]
        public Int64 ClientIssueNo
        {
            get { return _clientIssueNo; }
            set { _clientIssueNo = value; }
        }
        [DataMember]
        public string FormName
        {
            get { return _formname; }
            set { _formname = value; }
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




        #endregion
    }
}
