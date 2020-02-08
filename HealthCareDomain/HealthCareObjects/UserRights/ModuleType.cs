using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class ModuleType
    {

        #region Private Members

        protected Int64 _moduleTypeID;
        private string _moduleTypeName;
        private string _description;
        private Boolean _activeFlag;
        private Int64 _createdBy;
        private DateTime _createdDate;
        private Int64 _modifiedBy;
        private DateTime _modifiedDate;
        private Int64 _totalRecords;
        private string _enumMod;
        private Int64 _InventoryModuleID;
        #endregion

        #region Public Members
        [DataMember]
        public Int64 InventoryModuleID
        {
            get { return _InventoryModuleID; }
            set { _InventoryModuleID = value; }
        }
        [DataMember]
        public Int64 ModuleTypeID
        {
            get { return _moduleTypeID; }
            set { _moduleTypeID = value; }
        }
          [DataMember]
        public string EnumMod
        {
            get { return _enumMod; }
            set { _enumMod = value; }
        }
        [DataMember]
        public string ModuleTypeName
        {
            get { return _moduleTypeName; }
            set { _moduleTypeName = value; }
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
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        #endregion

    }
}
