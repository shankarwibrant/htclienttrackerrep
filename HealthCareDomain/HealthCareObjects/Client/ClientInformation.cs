using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
   public class ClientInformation
    {

        #region Privatevariable
        private Int64 _clientID;
        private string _companyName;
        private string _licence;
        private string _mobileNO;
        private string _phone;
        private string _fax;
        private string _email;
        private string _website;
        private string _address;
        private string _city;
        private string _area;
        private string _region;
        private string _state;
        private string _zipcode;
        private string _linkForVoIP;
        private string _vPNUser;
        private string _vPNPassword;
        private string _logo;
        private Int64 _createdBy;
        private int _activeflag;
        private Int64 _totalRecords;
        private DateTime _createdDate;
        private string _shortName;
        private Int64 _smcstatus;
        private Int64 _moduleID;
        private string _moduleName;
        private string _formID;
        private string _formName;
        private Int64 _modifiedBy;
        private Int64 _clientuserID;
        private DateTime _modifiedDate;
        private Int64 _formfeatureid;
        private string _formfeaturename;
        private string _desc;
        private int _ChkDescription;
        private int _F_id;
        private int _FeatureID;
        private Int64 _Productid;

        private string _ProductName;
        #endregion


        #region PublicVariable
        [DataMember]
        public int FeatureID
        { get; set; }

        [DataMember]
        public int F_id
        { get; set; }

        [DataMember]
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        [DataMember]
        public Int64 formfeatureid
        {
            get { return _formfeatureid; }
            set { _formfeatureid = value; }
        }
        [DataMember]
        public string formfeaturename
        {
            get { return _formfeaturename; }
            set { _formfeaturename = value; }
        }
        [DataMember]
        public Int64 Smcstatus
        {
            get { return _smcstatus; }
            set { _smcstatus = value; }
        }

        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public int ChkDescription
        {
            get { return _ChkDescription; }
            set { _ChkDescription = value; }
        }

        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        [DataMember]
        public string Licence
        {
            get { return _licence; }
            set { _licence = value; }
        }
        [DataMember]

        public string MobileNO
        {
            get { return _mobileNO; }
            set { _mobileNO = value; }
        }
        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        [DataMember]
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [DataMember]
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        [DataMember]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        [DataMember]
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        [DataMember]
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        [DataMember]
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        [DataMember]
        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        [DataMember]
        public string LinkForVoIP
        {
            get { return _linkForVoIP; }
            set { _linkForVoIP = value; }
        }
        [DataMember]
        public string VPNUser
        {
            get { return _vPNUser; }
            set { _vPNUser = value; }
        }
        [DataMember]
        public string VPNPassword
        {
            get { return _vPNPassword; }
            set { _vPNPassword = value; }
        }
        [DataMember]
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        [DataMember]
        public int Activeflag
        {
            get { return _activeflag; }
            set { _activeflag = value; }
        }
        [DataMember]
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        [DataMember]
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }


        [DataMember]
        public Int64 ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        [DataMember]
        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }
        [DataMember]
        public string FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }
        [DataMember]
        public string FormName
        {
            get { return _formName; ; }
            set { _formName = value; }
        }

        [DataMember]
        public Int64 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        [DataMember]
        public Int64 ClientUserID
        {
            get { return _clientuserID; }
            set { _clientuserID = value; }
        }
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        [DataMember]
        public Int64 Productid
        {
            get { return _Productid; }
            set { _Productid = value; }
        }
        [DataMember]
        public string Productname
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        #endregion
    }
}
