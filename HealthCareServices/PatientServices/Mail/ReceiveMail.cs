using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace PatientServices
{
    [DataContract]
    public class ReceiveMail
    {
        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string To { get; set; }

        [DataMember]
        public string MessageId { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public int MessageNumber { get; set; }

       
    }
}