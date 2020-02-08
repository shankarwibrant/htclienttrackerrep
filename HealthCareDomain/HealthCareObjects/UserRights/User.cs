using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class User
    {

        #region Private Members

        #region Basic Properties
        protected Int64 _userID;
        private int UID;
        protected Int64 _clientID;
        protected Int64 _RoleId;
        private string _userName;
        private string _password;
        private string _description;
        private bool _activeflag;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private Int64 _modifiedBy;
        private DateTime _modifiedDate;
        private string _servicePath;
        private int _recordNO;
        private int _totalRecords;
        private string _rolename;
        private string _langResource;
        private Int64 _roleProfileID;
        private string _emailID;
        private string _contactNo;
        private string _fullName;
        private string _requestedFor;
        private bool _approveFlag;
        private Int64 _departmentId;
        private string _departmentName;
        private bool _isFirstlogin;
        private bool _isApproveReject;
        private string _oldPassword;
        private Int64 _inactive;
        private Int64 _contact;
        private string _country;
        private string _email;
        private string _branchname;
        private string _city;
        private string _state;
        private Int64 _issave;
        private int _Userlimit;
        private int _Branchlimit;
        private int _Usertype;


        private Int64 _userDetailID;
        private Int64 _Flag;
        private string _IcNo;
        private string _PassportNo;
        private Int64 _CustomerType;
        private string _StaffId;
        private string _Image;
        private byte[] _Images;
        #endregion

        #region Social Authentication Properties

        public string _googleid;
        public string _facebookid;
        public string _microsoftid;
        public string _linkedinid;
        public string _twitterid;
        public DateTime _dateofbirth;
        public int _gender;
        public string _accesstoken;
        public string _profilepicture;
        public int _connecttype;
        public string _location;
        public string _firstname;
        public string _lastname;
        public string _organisation;
        public string _socialid;
        public string _address;
        public Int64 _countryId;
        public Int64 _stateId;
        public Int64 _cityId;
        public int _pin;

        #endregion

        #endregion

        #region Public Members

        #region Basic Property
        [DataMember]
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        [DataMember]
        public byte[] Images
        {
            get { return _Images; }
            set { _Images = value; }
        }
        [DataMember]
        public int Usertype
        {
            get { return _Usertype; }
            set { _Usertype = value; }
        }
        [DataMember]
        public int Userlimit
        {
            get { return _Userlimit; }
            set { _Userlimit = value; }
        }
        [DataMember]
        public int Branchlimit
        {
            get { return _Branchlimit; }
            set { _Branchlimit = value; }
        }
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        [DataMember]
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        [DataMember]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [DataMember]
        public string BranchName
        {
            get { return _branchname; }
            set { _branchname = value; }
        }

        [DataMember]
        public Int64 InActive
        {
            get { return _inactive; }
            set { _inactive = value; }
        }

        [DataMember]
        public Int64 Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
       
        [DataMember]
        public Int64 CustomerType
        {
            get { return _CustomerType; }
            set { _CustomerType = value; }
        }
        [DataMember]
        public string StaffID
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }
        [DataMember]
        public string PassportNo
        {
            get { return _PassportNo; }
            set { _PassportNo = value; }
        }
        [DataMember]
        public string IcNo
        {
            get { return _IcNo; }
            set { _IcNo = value; }
        }
        [DataMember]
        public Int64 Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
        [DataMember]
        public Int64 UserDetailID
        {
            get { return _userDetailID; }
            set { _userDetailID = value; }
        }
        [DataMember]
        public Int64 DoctorID { get; set; }

        [DataMember]
        public string DoctorName
        {
            get;
            set;
        }
        [DataMember]
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        [DataMember]
        public Int64 DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        [DataMember]
        public Int64 RoleProfileID
        {
            get { return _roleProfileID; }
            set { _roleProfileID = value; }
        }
        [DataMember]
        public string Rolename
        {
            get { return _rolename; }
            set { _rolename = value; }
        }

        [DataMember]
        public string ServicePath
        {
            get { return _servicePath; }
            set { _servicePath = value; }
        }
        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public Int64 RoleID
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        [DataMember]
        public int UID1
        {
            get { return UID; }
            set { UID = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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
        public int RecordNO
        {
            get { return _recordNO; }
            set { _recordNO = value; }
        }
        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public string LangResource
        {
            get { return _langResource; }
            set { _langResource = value; }
        }
        [DataMember]
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        [DataMember]
        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }
        [DataMember]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
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
        public bool IsApproveReject
        {
            get { return _isApproveReject; }
            set { _isApproveReject = value; }
        }
        [DataMember]
        public string OldPassword
        {
            get { return _oldPassword; }
            set { _oldPassword = value; }
        }
        #endregion

        #region Social Authentication Properties
        [DataMember]
        public string GoogleID
        {
            get { return _googleid; }
            set { _googleid = value; }
        }
        [DataMember]
        public string FacebookID
        {
            get { return _facebookid; }
            set { _facebookid = value; }
        }
        [DataMember]
        public string MicrosoftID
        {
            get { return _microsoftid; }
            set { _microsoftid = value; }
        }
        [DataMember]
        public string LinkedinID
        {
            get { return _linkedinid; }
            set { _linkedinid = value; }
        }
        [DataMember]
        public string TwitterID
        {
            get { return _twitterid; }
            set { _twitterid = value; }
        }
        [DataMember]
        public DateTime Dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }
        [DataMember]
        public int Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        [DataMember]
        public string AccessToken
        {
            get { return _accesstoken; }
            set { _accesstoken = value; }
        }
        [DataMember]
        public string ProfilePicture
        {
            get { return _profilepicture; }
            set { _profilepicture = value; }
        }
        [DataMember]
        public int Connecttype
        {
            get { return _connecttype; }
            set { _connecttype = value; }
        }
        [DataMember]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        [DataMember]
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        [DataMember]
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        [DataMember]
        public string SocialID
        {
            get { return _socialid; }
            set { _socialid = value; }
        }
        [DataMember]
        public Int64 CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }
        [DataMember]
        public Int64 StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }
        [DataMember]
        public Int64 CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
        [DataMember]
        public int Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        [DataMember]
        public string Organisation
        {
            get { return _organisation; }
            set { _organisation = value; }
        }
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        #endregion
        #endregion
    }
}
