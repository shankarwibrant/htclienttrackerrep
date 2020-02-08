using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{   [DataContract]
    public class Feature
    {
        [DataMember]
        public Int32 F_Id { get; set; }
        [DataMember]
        public string FeatureName { get; set; }
        [DataMember]
        public Int32 ModuleID { get; set; }
        [DataMember]
        public string ModuleName { get; set; }
        [DataMember]
        public Int32 FormID { get; set; }
        [DataMember]
        public string FormName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Int32 Autoid { get; set; }
        [DataMember]
        public Int32 TotalRecords { get; set; }
        [DataMember]
        public Int64 SNo { get; set; }
        [DataMember]
        public Int64 FeatureID { get; set; }
        [DataMember]
        public Int64 FeatureDtlId { get; set; }
    }
}
