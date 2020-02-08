using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects
{
    [DataContract]
    public class VibrantExceptions
    {

        #region Private Members
        private Int64 _exceprionID;
        private string _url;
        private string _data;
        private string _innerException;
        private string _stackTrace;
        private Int64 _userID;
        private DateTime _currentDateTime;

        #region NewlyAdded

        private TimeSpan _timeStamp;
        private string _message;
        private string _ipAddress;
        private string _warning;
        private string _error;
        private Int64 _clientID;
        private string _entityName;

        

       

        
        #endregion

        private string _recordNO;

        public string RecordNO
        {
            get { return _recordNO; }
            set { _recordNO = value; }
        }

        #endregion


        #region Public Members
        [DataMember]
        public Int64 ExceprionID
        {
            get { return _exceprionID; }
            set { _exceprionID = value; }
        }

        [DataMember]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        [DataMember]
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public string InnerException
        {
            get { return _innerException; }
            set { _innerException = value; }
        }

        [DataMember]
        public string StackTrace
        {
            get { return _stackTrace; }
            set { _stackTrace = value; }
        }

        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        [DataMember]
        public DateTime CurrentDateTime
        {
            get { return _currentDateTime; }
            set { _currentDateTime = value; }
        }
        [DataMember]
        public TimeSpan TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        [DataMember]
        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        [DataMember]
        public string Warning
        {
            get { return _warning; }
            set { _warning = value; }
        }

        [DataMember]
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
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
