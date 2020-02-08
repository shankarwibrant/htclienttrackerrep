using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HealthCareObjects.Client;
using PatientLibrary.BusinessFlow;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FormFeatureServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FormFeatureServices.svc or FormFeatureServices.svc.cs at the Solution Explorer and start debugging.
    public class FormFeatureServices : IFormFeatureServices
    {
        public List<Feature> formfeatureser()
        {
            FormFeatureMgr objff = new FormFeatureMgr();
            return objff.FormfeatureListbal();
        }
        public List<Feature> formfeaturemodser()
        {
            FormFeatureMgr objffmod = new FormFeatureMgr();
            return objffmod.Formfeaturemodbal();
        }
        public List<Feature> formfeatureformser(int moduleid)
        {
            FormFeatureMgr objffform = new FormFeatureMgr();
            return objffform.Formfeatureformbal(moduleid);
        }
        public List<Feature> cmbformser()
        {
            FormFeatureMgr objform = new FormFeatureMgr();
            return objform.cmbformbal();
        }
        public bool Createser(List<Feature> objtrans)
        {
            FormFeatureMgr objser = new FormFeatureMgr();
            return objser.CreateBal(objtrans);
        }
        public bool Updateser(List<Feature> objtra, List<Feature> objformDeleteList)
        {
            FormFeatureMgr objupdate = new FormFeatureMgr();
            return objupdate.Updatebal(objtra, objformDeleteList);
        }
        public Boolean DeleteSer(Int64 id)
        {
            FormFeatureMgr objservice = new FormFeatureMgr();
            return objservice.DeleteBal(id);
        }

        public List<Feature> ListService(int PageNo, int RowsPerPage, string SearchText)
        {
            FormFeatureMgr objlist = new FormFeatureMgr();
            return objlist.Listbal(PageNo, RowsPerPage, SearchText);
        }
        public List<Feature> Listchildser(int Autoid)
        {
            FormFeatureMgr objchild = new FormFeatureMgr();
            return objchild.Listchilbal(Autoid);
        }
        public string AutoIdSer()
        {
            FormFeatureMgr objauto = new FormFeatureMgr();
            return objauto.AutoIdBal();
        }
        public Boolean DeleteDtlFeat(Feature objdelftr)
        {
            FormFeatureMgr objrmv = new FormFeatureMgr();
            return objrmv.DeleteDtlFeature(objdelftr);
        }


    }
}
