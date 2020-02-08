using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class EntityUser
    {
        #region Private Members

        protected Int64 _roleProfileID;
        private Int64 _roleID;
        private Int64 _userID;
        private string _userName;
 
       private string _roleName;
 
       private string _password;

     
        private Int64 _totalRecords;
        private Int64 _createdBy;
        private Int64 _modifiedBy;
        private bool _activeflag;
        private Int64 _clientID;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private string _description;
        private bool _usersSelect; 


        #endregion

        #region Public Members

        [DataMember]
        public Int64 RoleProfileID
        {
            get { return _roleProfileID; }
            set { _roleProfileID = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
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
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        [DataMember]
        public Int64 TotalRecords
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
        public bool UsersSelect
        {
            get { return _usersSelect; }
            set { _usersSelect = value; }
        }

        #endregion
    }
}
