using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using HealthCareObjects.UserRights;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class EntityAccessRight : BaseClass
    {

        #region Private Members

        protected Int64 _entityAccessID;
        private Int64 _moduleTypeID;
        private Int64 _entityID;
        private Int64 _roleProfileID;
        private bool _entityCreate;
        private bool _entityRead;
        private bool _entityUpdate;
        private bool _entityDelete;
        private bool _permit;
        private bool _entityPrint;
        private string _entitydescription;
        private bool _activeflag;
        private Int64 _createdBy;
        private string _moduleTypeName;
        private string _entityName;
        private string _entityPath;
        private Int64 _userId;
        private Int64 _roleId;
        private int _uId;
        private string _password;
        private string _username;
        private string _entitypath;
        private string _rolename;
        private Int64 _clientId;
        private DateTime _createdDate;
        private Int64 _MainStoreID;
        private Int64 _SubStoreID;
        private Int64 _PatientID;
        private string _PatientName;
        private List<EntityAccessRight> _objentityAccessRightList;
        private string _Description; //senthur
        private string _reEntity;
        #endregion

        #region Public Members
        [DataMember]
        public string ReEntity
        {
            get { return _reEntity; }
            set {_reEntity = value;}
        }
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public string IP_Address
        {
            get;
            set;
        }

        [DataMember]
        public DateTime SYSTEM_DATE
        {
            get;
            set;
        }

        [DataMember]
        public string ButtonClick_Type
        {
            get;
            set;
        }

        [DataMember]
        public Int64 Bill_ID
        {
            get;
            set;
        }

        [DataMember]
        public Int64 ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        [DataMember]
        public Int64 EntityAccessID
        {
            get { return _entityAccessID; }
            set { _entityAccessID = value; }
        }

        //[DataMember]
        //public Int64 ClientId
        //{
        //    get { return _clientId; }
        //    set { _clientId = value; }
        //}
        [DataMember]
        public Int64 ModuleTypeID
        {
            get { return _moduleTypeID; }
            set { _moduleTypeID = value; }
        }
        [DataMember]
        public Int64 EntityID
        {
            get { return _entityID; }
            set { _entityID = value; }
        }
        [DataMember]
        public Int64 RoleProfileID
        {
            get { return _roleProfileID; }
            set { _roleProfileID = value; }
        }
        [DataMember]
        public bool EntityCreate
        {
            get { return _entityCreate; }
            set { _entityCreate = value; }
        }
        [DataMember]
        public bool EntityRead
        {
            get { return _entityRead; }
            set { _entityRead = value; }
        }
        [DataMember]
        public bool EntityUpdate
        {
            get { return _entityUpdate; }
            set { _entityUpdate = value; }
        }
        [DataMember]
        public bool EntityDelete
        {
            get { return _entityDelete; }
            set { _entityDelete = value; }
        }
        [DataMember]
        public bool Permit
        {
            get { return _permit; }
            set { _permit = value; }
        }
        [DataMember]
        public bool EntityPrint
        {
            get { return _entityPrint; }
            set { _entityPrint = value; }
        }
        [DataMember]
        public string EntityDescription
        {
            get { return _entitydescription; }
            set { _entitydescription = value; }
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
        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }
        [DataMember]
        public string ModuleTypeName
        {
            get { return _moduleTypeName; }
            set { _moduleTypeName = value; }
        }
        [DataMember]
        public string EntityPath
        {
            get { return _entityPath; }
            set { _entityPath = value; }
        }
        [DataMember]
        public Int64 UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        [DataMember]
        public Int64 RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [DataMember]
        public string Entitypath
        {
            get { return _entitypath; }
            set { _entitypath = value; }
        }
        [DataMember]
        public int UId
        {
            get { return _uId; }
            set { _uId = value; }
        }
        [DataMember]
        public string Rolename
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        [DataMember]
        public Int64 MainStoreID
        {
            get { return _MainStoreID; }
            set { _MainStoreID = value; }
        }
        [DataMember]
        public Int64 SubStoreID
        {
            get { return _SubStoreID; }
            set { _SubStoreID = value; }
        }
        [DataMember]
        public List<EntityAccessRight> ObjEntityAccessRightList
        {
            get { return _objentityAccessRightList; }
            set { _objentityAccessRightList = value; }
        }
        [DataMember]
        public Int64 PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }
        [DataMember]
        public string PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }
        #endregion

    }
}
