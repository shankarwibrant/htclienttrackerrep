using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{   [DataContract]
   public class Department
    {
        #region Private Members

        private Int64 _clientID;
        private Int64 _DepartmentID;
        private string _departmentName;
        private string _departmentCode;
        private bool _activeFlag;
        private Int64 _createdBy;
        private Int64 _modifiedBy;
        private DateTime _createdDate;
        private int _recordNo;
        private Int32 _type;
        private Int64 _count1;
        private string _deptDetails;
        private string _description;
        private int _totalRecords;

        #endregion

        #region Public Members

        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }

        [DataMember]
        public Int64 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        [DataMember]
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        [DataMember]
        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        [DataMember]
        public bool ActiveFlag
        {
            get { return _activeFlag; }
            set { _activeFlag = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        [DataMember]
        public int RecordNo
        {
            get { return _recordNo; }
            set { _recordNo = value; }
        }
        [DataMember]
        public Int64 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        [DataMember]
        public Int32 Type
        {
            get { return _type; }
            set { _type = value; }
        }
        [DataMember]
        public Int64 Count1
        {
            get { return _count1; }
            set { _count1 = value; }
        }
        [DataMember]
        public string DeptDetails
        {
            get { return _deptDetails; }
            set { _deptDetails = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        #endregion
    }
}
