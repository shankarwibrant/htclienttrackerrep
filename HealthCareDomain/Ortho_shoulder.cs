using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthCareObjects.Patient.OutPatient;
using System.Runtime.Serialization;

namespace HealthCareObjects.Ortho
{
    [DataContract]
   public  class Ortho_shoulder:BaseClass
    {
        # region privatemember

        private Int32 _Companycode;
        private Int32 _Shoulderid;
        private DateTime _ShoulderDate;
        private Int32 _Patienttype;
        private Int64 _Patientid;
        private string _Patientname;
        private Int32 _Doctorid;
        private string _Doctorname;
        private string _DeformityLeft;
        private string _DeformityRight;
        private string _WastingRight;
        private string _WastingLeft;
        private string _TenderRight;
        private string _TenderLeft;
        private string _FlexRight;
        private string _DoctorDept;
        private string _FlexLeft;
        private string _AbductionRight;

        private string _AbductionLeft;

        private Int64 _vitalsid;
        private string _Pressure;
        private string _Temparature;
        private string _Heartrate;
        private string _Respiration;
        private string _spo2;
        private string _weight;
        private string _height;
         #endregion



        #region publicmember
        [DataMember]
        public Int32 Companycode
        {
            get { return _Companycode; }
            set { _Companycode = value; }
        }

        [DataMember]
        public Int32 Shoulderid
        {
            get { return _Shoulderid; }
            set { _Shoulderid = value; }
        }

        [DataMember]
        public DateTime ShoulderDate
        {
            get { return _ShoulderDate; }
            set { _ShoulderDate = value; }
        }
      
        [DataMember]
        public Int32 Patienttype
        {
            get { return _Patienttype; }
            set { _Patienttype = value; }
        }
     
        [DataMember]
        public Int64 Patientid
        {
            get { return _Patientid; }
            set { _Patientid = value; }
        }
      
        [DataMember]
        public string Patientname
        {
            get { return _Patientname; }
            set { _Patientname = value; }
        }
      
        [DataMember]
        public Int32 Doctorid
        {
            get { return _Doctorid; }
            set { _Doctorid = value; }
        }
      
        [DataMember]
        public string Doctorname
        {
            get { return _Doctorname; }
            set { _Doctorname = value; }
        }
        [DataMember]
        public string DoctorDept
        {
            get { return _DoctorDept; }
            set { _DoctorDept = value; }
        }
        [DataMember]
        public string DeformityRight
        {
            get { return _DeformityRight; }
            set { _DeformityRight = value; }
        }
       
        [DataMember]
        public string DeformityLeft
        {
            get { return _DeformityLeft; }
            set { _DeformityLeft = value; }
        }
       
        [DataMember]
        public string WastingRight
        {
            get { return _WastingRight; }
            set { _WastingRight = value; }
        }
   
        [DataMember]
        public string WastingLeft
        {
            get { return _WastingLeft; }
            set { _WastingLeft = value; }
        }
     
        [DataMember]
        public string TenderRight
        {
            get { return _TenderRight; }
            set { _TenderRight = value; }
        }
      
        [DataMember]
        public string TenderLeft
        {
            get { return _TenderLeft; }
            set { _TenderLeft = value; }
        }
    
        [DataMember]
        public string FlexRight
        {
            get { return _FlexRight; }
            set { _FlexRight = value; }
        }
       
        [DataMember]
        public string FlexLeft
        {
            get { return _FlexLeft; }
            set { _FlexLeft = value; }
        }
      
        [DataMember]
        public string AbductionRight
        {
            get { return _AbductionRight; }
            set { _AbductionRight = value; }
        }
       
        [DataMember]
        public string AbductionLeft
        {
            get { return _AbductionLeft; }
            set { _AbductionLeft = value; }
        }
        private string _ExternalRight;
        [DataMember]
        public string ExternalRight
        {
            get { return _ExternalRight; }
            set { _ExternalRight = value; }
        }
        private string _ExternalLeft;
        [DataMember]
        public string ExternalLeft
        {
            get { return _ExternalLeft; }
            set { _ExternalLeft = value; }
        }
        private string _InternalRight;
        [DataMember]
        public string InternalRight
        {
            get { return _InternalRight; }
            set { _InternalRight = value; }
        }
        private string _InternalLeft;
        [DataMember]
        public string InternalLeft
        {
            get { return _InternalLeft; }
            set { _InternalLeft = value; }
        }
        private string _External90Right;
        [DataMember]
        public string External90Right
        {
            get { return _External90Right; }
            set { _External90Right = value; }
        }
        private string _External90Left;
        [DataMember]
        public string External90Left
        {
            get { return _External90Left; }
            set { _External90Left = value; }
        }
        private string _Internal90Right;
        [DataMember]
        public string Internal90Right
        {
            get { return _Internal90Right; }
            set { _Internal90Right = value; }
        }
        private string _Internal90Left;
        [DataMember]
        public string Internal90Left
        {
            get { return _Internal90Left; }
            set { _Internal90Left = value; }
        }
        private string _EmptycanRight;
        [DataMember]
        public string EmptycanRight
        {
            get { return _EmptycanRight; }
            set { _EmptycanRight = value; }
        }
        private string _EmptycanLeft;
        [DataMember]
        public string EmptycanLeft
        {
            get { return _EmptycanLeft; }
            set { _EmptycanLeft = value; }
        }
        private string _FullRight;
        [DataMember]
        public string FullRight
        {
            get { return _FullRight; }
            set { _FullRight = value; }
        }
        private string _FullLeft;
        [DataMember]
        public string FullLeft
        {
            get { return _FullLeft; }
            set { _FullLeft = value; }
        }
        private string _InfraRight;
        [DataMember]
        public string InfraRight
        {
            get { return _InfraRight; }
            set { _InfraRight = value; }
        }
        private string _InfraLeft;
        [DataMember]
        public string InfraLeft
        {
            get { return _InfraLeft; }
            set { _InfraLeft = value; }
        }
        private string _ObriensRight;
        [DataMember]
        public string ObriensRight
        {
            get { return _ObriensRight; }
            set { _ObriensRight = value; }
        }
        private string _ObriensLeft;
        [DataMember]
        public string ObriensLeft
        {
            get { return _ObriensLeft; }
            set { _ObriensLeft = value; }
        }
        private string _ObriensRight1;
        [DataMember]
        public string ObriensRight1
        {
            get { return _ObriensRight1; }
            set { _ObriensRight1 = value; }
        }
        private string _ObriensLeft1;
        [DataMember]
        public string ObriensLeft1
        {
            get { return _ObriensLeft1; }
            set { _ObriensLeft1 = value; }
        }
        private string _ObriensRight2;
        [DataMember]
        public string ObriensRight2
        {
            get { return _ObriensRight2; }
            set { _ObriensRight2 = value; }
        }
        private string _ObriensLeft2;
        [DataMember]
        public string ObriensLeft2
        {
            get { return _ObriensLeft2; }
            set { _ObriensLeft2 = value; }
        }
        private string _HornRight;
        [DataMember]
        public string HornRight
        {
            get { return _HornRight; }
            set { _HornRight = value; }
        }
        private string _HornLeft;
        [DataMember]
        public string HornLeft
        {
            get { return _HornLeft; }
            set { _HornLeft = value; }
        }
        private string _HornRight1;
        [DataMember]
        public string HornRight1
        {
            get { return _HornRight1; }
            set { _HornRight1 = value; }
        }
        private string _HornLeft1;
        [DataMember]
        public string HornLeft1
        {
            get { return _HornLeft1; }
            set { _HornLeft1 = value; }
        }
        private string _HornRight2;
        [DataMember]
        public string HornRight2
        {
            get { return _HornRight2; }
            set { _HornRight2 = value; }
        }
        private string _HornLeft2;
        [DataMember]
        public string HornLeft2
        {
            get { return _HornLeft2; }
            set { _HornLeft2 = value; }
        }
        private string _ListRight;
        [DataMember]
        public string ListRight
        {
            get { return _ListRight; }
            set { _ListRight = value; }
        }
        private string _ListLeft;
        [DataMember]
        public string ListLeft
        {
            get { return _ListLeft; }
            set { _ListLeft = value; }
        }
        private string _ListRight1;
        [DataMember]
        public string ListRight1
        {
            get { return _ListRight1; }
            set { _ListRight1 = value; }
        }
        private string _ListLeft1;
        [DataMember]
        public string ListLeft1
        {
            get { return _ListLeft1; }
            set { _ListLeft1 = value; }
        }
        private string _ListRight2;
        [DataMember]
        public string ListRight2
        {
            get { return _ListRight2; }
            set { _ListRight2 = value; }
        }
        private string _ListLeft2;
        [DataMember]
        public string ListLeft2
        {
            get { return _ListLeft2; }
            set { _ListLeft2 = value; }
        }
        private string _HawRight;
        [DataMember]
        public string HawRight
        {
            get { return _HawRight; }
            set { _HawRight = value; }
        }
        private string _HawLeft;
        [DataMember]
        public string HawLeft
        {
            get { return _HawLeft; }
            set { _HawLeft = value; }
        }
        private string _HawRight1;
        [DataMember]
        public string HawRight1
        {
            get { return _HawRight1; }
            set { _HawRight1 = value; }
        }
        private string _HawLeft1;
        [DataMember]
        public string HawLeft1
        {
            get { return _HawLeft1; }
            set { _HawLeft1 = value; }
        }
        private string _HawRight2;
        [DataMember]
        public string HawRight2
        {
            get { return _HawRight2; }
            set { _HawRight2 = value; }
        }
        private string _HawLeft2;
        [DataMember]
        public string HawLeft2
        {
            get { return _HawLeft2; }
            set { _HawLeft2 = value; }
        }
        private Int32 _AppTypeRight;
        [DataMember]
        public Int32 AppTypeRight
        {
            get { return _AppTypeRight; }
            set { _AppTypeRight = value; }
        }
        private string _AppRightremarks;
        [DataMember]
        public string AppRightremarks
        {
            get { return _AppRightremarks; }
            set { _AppRightremarks = value; }
        }
        private Int32 _AppTypeLeft;
        [DataMember]
        public Int32 AppTypeLeft
        {
            get { return _AppTypeLeft; }
            set { _AppTypeLeft = value; }
        }
        private string _AppLeftRemarks;
        [DataMember]
        public string AppLeftRemarks
        {
            get { return _AppLeftRemarks; }
            set { _AppLeftRemarks = value; }
        }
        private string _JobeRight;
        [DataMember]
        public string JobeRight
        {
            get { return _JobeRight; }
            set { _JobeRight = value; }
        }
        private string _JobeLeft;
        [DataMember]
        public string JobeLeft
        {
            get { return _JobeLeft; }
            set { _JobeLeft = value; }
        }
        private string _SulcusRight;
        [DataMember]
        public string SulcusRight
        {
            get { return _SulcusRight; }
            set { _SulcusRight = value; }
        }
        private string _SulcusLeft;
        [DataMember]
        public string SulcusLeft
        {
            get { return _SulcusLeft; }
            set { _SulcusLeft = value; }
        }
        private Int16 _Activeflag;
        [DataMember]
        public Int16 Activeflag
        {
            get { return _Activeflag; }
            set { _Activeflag = value; }
        }
        private Int16 _CreatedBy;
        [DataMember]
        public Int16 CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        private DateTime _CreatedDate;
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private Int32 _ModifiedBy;
        [DataMember]
        public Int32 ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        private DateTime _ModifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        [DataMember]
        public Int64 vitalsid
        {
            get { return _vitalsid; }
            set { _vitalsid = value; }
        }
        [DataMember]
        public string Pressure
        {
            get { return _Pressure; }
            set { _Pressure = value; }
        }
        [DataMember]
        public string temperature
        {
            get { return _Temparature; }
            set { _Temparature = value; }
        }
        [DataMember]
        public string Heartrate
        {
            get { return _Heartrate; }
            set { _Heartrate = value; }
        }
        [DataMember]
        public string Respiration
        {
            get { return _Respiration; }
            set { _Respiration = value; }
        }
        [DataMember]
        public string Spo2
        {
            get { return _spo2; }
            set { _spo2 = value; }
        }
        [DataMember]
        public string Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        [DataMember]
        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }
         


        #endregion
    }
}
