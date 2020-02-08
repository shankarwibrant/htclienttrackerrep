using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace PatientServices
{
    [DataContract]
    public class MailServer:SendMail
    {
        [DataMember]
        public string SmtpMailServer { get; set; }
        [DataMember]
        public string SmtpUserName { get; set; }
        [DataMember]
        public int SmtpPort { get; set; }
        [DataMember]
        public string SmtpPassword { get; set; }
        [DataMember]
        public string PopMailServer { get; set; }
        [DataMember]
        public string PopUserName { get; set; }
        [DataMember]
        public int PopPort { get; set; }
        [DataMember]
        public string PopPassword { get; set; }
    }
}