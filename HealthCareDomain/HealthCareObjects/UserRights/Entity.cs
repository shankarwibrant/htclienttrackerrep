using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class Entity : BaseClass
    {

        #region Private Members

        protected Int64 _entityId;
        private string _entityName;
        private string _entityPath;
        private string _description;
        private Int64 _moduletypeId;
        private string _moduleTypeName;
        private bool _activeflag;   
        private Int64 _createdBy;
        //private string _moduletypeId;

        #endregion

        #region Public Members
        [DataMember]
        public Int64 EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }
        [DataMember]
        public string EntityPath
        {
            get { return _entityPath; }
            set { _entityPath = value; }
        }
        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public Int64 ModuletypeId
        {
            get { return _moduletypeId; }
            set { _moduletypeId = value; }
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
        public string ModuleTypeName
        {
            get { return _moduleTypeName; }
            set { _moduleTypeName = value; }
        }


        #endregion

    }

}
