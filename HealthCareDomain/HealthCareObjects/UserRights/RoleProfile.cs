using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class RoleProfile : BaseClass
    {

        #region Private Members

        protected Int64 _roleProfileID;
        protected Int64 _clientID;
        protected Int64 _BranchId;
        protected Int64 _ClinicID;
        private Int64 _userID;
        private string _userName;
        private string _roleName;
        private string _password;
        private int _attempt;
        private int _mAX_ATTEMPTS;
        private string _clientName;
        private string _clientAddress;
        private Int64 _roleID;
        private string _description;
        private Boolean _activeFlag;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private Int64 _modifiedBy;
        private DateTime _modifiedDate;
        private string _langResource;
        private string _requestedFor;
        private bool _approveFlag;
        private bool _isFirstlogin;
        private string _emailID;
        private Int64 _MainStoreID;
        private int _Connecttype;
        private string _fullName;







        #endregion

        #region Public Members
        [DataMember]
        public Int64 BranchID
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }
        [DataMember]
        public Int64 ClinicID
        {
            get { return _ClinicID; }
            set { _ClinicID = value; }
        }
        [DataMember]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        [DataMember]
        public string AudiTrail
        {
            get;
            set;
        }
        [DataMember]
        public Int64 DoctorID
        {
            get;
            set;
        }
        [DataMember]
        public string DoctorName
        {
            get;
            set;
        }
        [DataMember]
        public Int64 MainStoreID
        {
            get;
            set;
        }
         [DataMember]
        public int Attempt
        {
            get { return _attempt; }
            set { _attempt = value; }
        }
         [DataMember]
         public int MAX_ATTEMPTS
        {
            get { return _mAX_ATTEMPTS; }
            set { _mAX_ATTEMPTS = value; }
        }
        [DataMember]
        public Int64 RoleProfileID
        {
            get { return _roleProfileID; }
            set { _roleProfileID = value; }
        }
        [DataMember]
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        [DataMember]
        public string ClientAddress
        {
            get { return _clientAddress; }
            set { _clientAddress = value; }
        }
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [DataMember]
        public Int64 RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public Boolean ActiveFlag
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
        public string LangResource
        {
            get { return _langResource; }
            set { _langResource = value; }
        }
        [DataMember]
        public string RequestedFor
        {
            get { return _requestedFor; }
            set { _requestedFor = value; }
        }
        [DataMember]
        public bool ApproveFlag
        {
            get { return _approveFlag; }
            set { _approveFlag = value; }
        }
        [DataMember]
        public bool IsFirstlogin
        {
            get { return _isFirstlogin; }
            set { _isFirstlogin = value; }
        }

        [DataMember]
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }

        [DataMember]
        public int Connecttype
        {
            get { return _Connecttype; }
            set { _Connecttype = value; }
        }

        #endregion

    }
}
