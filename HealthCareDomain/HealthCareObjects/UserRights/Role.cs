using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class Role
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
        private DateTime _createdDate;
        private string _moduleTypeName;
        private string _entityName;
        protected Int64 _roleID;
        private string _roleName;
        private Int64 _totalRecords;
        private Int64 _createdBy;
        private Int64 _modifiedBy;
        private bool _activeflag;
        protected Int64 _clientID;
        private DateTime _modifiedDate;
        private string _description;
        private string _Entitypath;
        private string _Password;
        #endregion

        #region Public Members

        [DataMember]
        public Int64 RoleId
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        [DataMember]
        public string Entitypath
        {
            get { return _Entitypath; }
            set { _Entitypath = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        [DataMember]
        public string Rolename
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        [DataMember]
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        [DataMember]
        public Int64 ClientId
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
        public Int64 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

        [DataMember]
        public bool Activeflag
        {
            get { return _activeflag; }
            set { _activeflag = value; }
        }

        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public Int64 EntityAccessID
        {
            get { return _entityAccessID; }
            set { _entityAccessID = value; }
        }
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
        public string EntityDescription
        {
            get { return _entitydescription; }
            set { _entitydescription = value; }
        }
        [DataMember]
        public bool EntityPrint
        {
            get { return _entityPrint; }
            set { _entityPrint = value; }
        }
        [DataMember]
        public string ModuleTypeName
        {
            get { return _moduleTypeName; }
            set { _moduleTypeName = value; }
        }
        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }
        #endregion

    }
}
