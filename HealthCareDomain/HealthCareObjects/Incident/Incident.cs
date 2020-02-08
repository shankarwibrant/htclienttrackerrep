using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HealthCareObjects.Incident
{
    [DataContract]
    public class Incident
    {
        //Kumar-start
        #region Private Members
        private Int64 _NotificationId;
        private string _IRNumber;
        private DateTime _DateOfEvent;
        private string _TimeOfEvent;
        private DateTime _DateOfReporting;
        private string _TimeOfReporting;
        private string _LocationOfEvent;
        private Int64 _TypeOfEvent;
        private string _EventOthers;
        private Int64 _PartyInvolved;
        private string _PartyOthers;
        private string _FullNarrative;
        private Int64 _SeverityCategories;
        private int _Activeflag;
        private Int64 _ClientId;
        private Int64 _BranchId;
        private Int64 _CreatedBy;
        private DateTime _CreatedDate;
        private Int32 _Issave;
        #endregion

        #region Public Members

        [DataMember]
        public Int32 Issave
        {
            get { return _Issave; }
            set { _Issave = value; }
        }

        [DataMember]
        public int Activeflag
        {
            get { return _Activeflag; }
            set { _Activeflag = value; }
        }
            [DataMember]
        public Int64 BranchId
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }
        [DataMember]
        public Int64 ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        [DataMember]
        public Int64 SeverityCategories
        {
            get { return _SeverityCategories; }
            set { _SeverityCategories = value; }
        }
        [DataMember]
        public Int64 PartyInvolved
        {
            get { return _PartyInvolved; }
            set { _PartyInvolved = value; }
        }
        [DataMember]
        public Int64 TypeOfEvent
        {
            get { return _TypeOfEvent; }
            set { _TypeOfEvent = value; }
        }
        [DataMember]
        public DateTime DateOfReporting
        {
            get { return _DateOfReporting; }
            set { _DateOfReporting = value; }
        }
        [DataMember]
        public DateTime DateOfEvent
        {
            get { return _DateOfEvent; }
            set { _DateOfEvent = value; }
        }
        [DataMember]
        public string FullNarrative
        {
            get { return _FullNarrative; }
            set { _FullNarrative = value; }
        }
        [DataMember]
        public string PartyOthers
        {
            get { return _PartyOthers; }
            set { _PartyOthers = value; }
        }
        [DataMember]
        public string EventOthers
        {
            get { return _EventOthers; }
            set { _EventOthers = value; }
        }
        [DataMember]
        public string LocationOfEvent
        {
            get { return _LocationOfEvent; }
            set { _LocationOfEvent = value; }
        }
        [DataMember]
        public string TimeOfReporting
        {
            get { return _TimeOfReporting; }
            set { _TimeOfReporting = value; }
        }
        [DataMember]
        public string TimeOfEvent
        {
            get { return _TimeOfEvent; }
            set { _TimeOfEvent = value; }
        }
        [DataMember]
        public string IRNumber
        {
            get { return _IRNumber; }
            set { _IRNumber = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        [DataMember]
        public Int64 NotificationId
        {
            get { return _NotificationId; }
            set { _NotificationId = value; }
        }

        #endregion

        //kumar-end


        //kalees-start
        #region Private Members
       private Int64  _PatientSafetyID       ;
       private Int64  _TypeofEventID         ;
       private string _TyepofEventValue      ;
       private string _TyepofEventOthers     ;
       private Int64  _CategoryofstaffID     ;
       private string _Categoryofstaffvalue  ;
       private string _CategoryofstaffOthers ;
       private Int64  _IPsInitiativeID       ;
       private string _IpsInitiativeValue    ;
       private string _IpsInitiativeOthers   ;
       private Int64  _IPsClinicalID         ;
       private string _IPsClinicalValue      ;
       private string _IPsClinicalOthers     ;
       private Int64  _IPsNonclinicalID      ;
       private string _IPsNonclinicalValue   ;
       private string _IPsNonclinicalOthers  ;
       private Int64  _SACMatrixFrequent     ;
       private Int64  _SACMatrixProbable     ;
       private Int64  _SACMatrixOccasional   ;
       private string _PatientSafetyRemarks  ;
        #endregion

        #region Public Members

        [DataMember]
        public string PatientSafetyRemarks
        {
            get { return _PatientSafetyRemarks; }
            set { _PatientSafetyRemarks = value; }
        }

        [DataMember]
        public Int64 SACMatrixOccasional
        {
            get { return _SACMatrixOccasional; }
            set { _SACMatrixOccasional = value; }
        }

        [DataMember]
        public Int64 SACMatrixProbable
        {
            get { return _SACMatrixProbable; }
            set { _SACMatrixProbable = value; }
        }

        [DataMember]
        public Int64 SACMatrixFrequent
        {
            get { return _SACMatrixFrequent; }
            set { _SACMatrixFrequent = value; }
        }

        [DataMember]
        public string IPsNonclinicalOthers
        {
            get { return _IPsNonclinicalOthers; }
            set { _IPsNonclinicalOthers = value; }
        }


        [DataMember]
        public string IPsNonclinicalValue
        {
            get { return _IPsNonclinicalValue; }
            set { _IPsNonclinicalValue = value; }
        }

        [DataMember]
        public Int64 IPsNonclinicalID
        {
            get { return _IPsNonclinicalID; }
            set { _IPsNonclinicalID = value; }
        }

        [DataMember]
        public string IPsClinicalOthers
        {
            get { return _IPsClinicalOthers; }
            set { _IPsClinicalOthers = value; }
        }

        [DataMember]
        public string IPsClinicalValue
        {
            get { return _IPsClinicalValue; }
            set { _IPsClinicalValue = value; }
        }

        [DataMember]
        public Int64 IPsClinicalID
        { 
            get { return _IPsClinicalID; }
            set { _IPsClinicalID = value; }
        }


        [DataMember]
        public string IpsInitiativeOthers
        {
            get { return _IpsInitiativeOthers; }
            set { _IpsInitiativeOthers = value; }
        }


        [DataMember]
        public string IpsInitiativeValue
        {
            get { return _IpsInitiativeValue; }
            set { _IpsInitiativeValue = value; }
        }


        [DataMember]
        public Int64 IPsInitiativeID
        {
            get { return _IPsInitiativeID; }
            set { _IPsInitiativeID = value; }
        }


        [DataMember]
        public string CategoryofstaffOthers
        {
            get { return _CategoryofstaffOthers; }
            set { _CategoryofstaffOthers = value; }
        }

        [DataMember]
        public string Categoryofstaffvalue
        {
            get { return _Categoryofstaffvalue; }
            set { _Categoryofstaffvalue = value; }
        }

        [DataMember]
        public Int64 CategoryofstaffID
        {
            get { return _CategoryofstaffID; }
            set { _CategoryofstaffID = value; }
        }


        [DataMember]
        public string TyepofEventOthers
        {
            get { return _TyepofEventOthers; }
            set { _TyepofEventOthers = value; }
        }

        [DataMember]
        public string TyepofEventValue
        {
            get { return _TyepofEventValue; }
            set { _TyepofEventValue = value; }
        }

        [DataMember]
        public Int64 TypeofEventID
        {
            get { return _TypeofEventID; }
            set { _TypeofEventID = value; }
        }

        [DataMember]
        public Int64 PatientSafetyID
        {
            get { return _PatientSafetyID; }
            set { _PatientSafetyID = value; }
        }

        #endregion
        //kalees-end


    }
}
