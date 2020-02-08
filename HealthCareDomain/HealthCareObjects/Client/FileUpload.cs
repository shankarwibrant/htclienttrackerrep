using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.Client
{
    [DataContract]
   public class FileUpload
    {

        #region PrivateMember

        private int _fileSNo;
        private Int64 _fileID;
        private string _fileName;
        private string _fileTye;
        private string _fileContent;
        private byte[] _stringContent;
        private Int64 _createdBy;
        private Int64 _issueDetailId;
        private Int32 _IsSave;
        private Int64 _clientID;

        #endregion
        #region PublicMember
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public Int32 IsSave
        {
            get { return _IsSave; }
            set { _IsSave = value; }
        }

        [DataMember]
        public Int64 IssueDetailId
        {
            get { return _issueDetailId; }
            set { _issueDetailId = value; }

        }
        [DataMember]
        public int FileSNo
        {
            get { return _fileSNo; }
            set { _fileSNo = value; }

        }
        [DataMember]
        public Int64 FileId
        {
            get { return _fileID; }
            set { _fileID = value; }

        }
        [DataMember]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        [DataMember]
        public string FileType
        {
            get { return _fileTye; }
            set { _fileTye = value; }
        }
        [DataMember]
        public string FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }
        [DataMember]
        public byte[] StringContent
        {
            get { return _stringContent; }
            set { _stringContent = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        #endregion

    }
}
