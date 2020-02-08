using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects
{
    [DataContract]
   public class BaseClass
    {
        private int _totalRecords;
        private bool _IsCaseSheetRemove;
        private bool _IsFinalDiagnosisRemove;
        private bool _isUpdate;
        private bool _isRemove;
        private bool _multiStore;
        private string _servicePath;
        private int _moduleID;
        private string _baseentityName; 

        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public bool IsCaseSheetRemove
        {
            get { return _IsCaseSheetRemove; }
            set { _IsCaseSheetRemove = value; }
        }
        [DataMember]
        public bool IsFinalDiagnosisRemove
        {
            get { return _IsFinalDiagnosisRemove; }
            set { _IsFinalDiagnosisRemove = value; }
        }
        [DataMember]
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set { _isUpdate = value; }
        }
        [DataMember]
        public bool IsRemove
        {
            get { return _isRemove; }
            set { _isRemove = value; }
        }
        [DataMember]
        public bool MultiStore
        {
            get { return _multiStore; }
            set { _multiStore = value; }
        }
        [DataMember]
        public string ServicePath
        {
            get { return _servicePath; }
            set { _servicePath = value; }
        }
        [DataMember]
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        [DataMember]
        public bool IsDemo { get; set; }
        [DataMember]
        public string TriaText { get; set; }
        [DataMember]
        public int RowsPerPage { get; set; }
        [DataMember]
        public string IPFinalBillingCollectionFlag { get; set; }
        [DataMember]
        public string FollowUpFlag { get; set; }
        [DataMember]
        public bool IsLoginSuccess { get; set; }
        [DataMember]
        public string BaseEntityName
        {
            get { return _baseentityName; }
            set { _baseentityName = value; }
        }
    }
    }

