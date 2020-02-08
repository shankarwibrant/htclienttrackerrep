using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace PatientServices
{
    [DataContract]
    public class SendMail
    {
        [DataMember]
        public string MailFrom { get; set; }

        [DataMember]
        public string MailTo { get; set; }

        [DataMember]
        public string MailSubject { get; set; }

        [DataMember]
        public String MailBody { get; set; }
    }
}