using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HealthCareObjects.UserRights
{
    [DataContract]
    public class ClientLocation
    {
        #region Private Members

        private Int64 _CountryId;
        private Int64 _StateId;
        private Int64 _CityId;
        private string _CountryName;
        private string _StateName;
        private string _CityName;

        #endregion

        #region Public Members
        [DataMember]
        public Int64 CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }
        [DataMember]
        public Int64 StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }
        [DataMember]
        public Int64 CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }
        [DataMember]
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
        [DataMember]
        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        [DataMember]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        #endregion
    }
}
