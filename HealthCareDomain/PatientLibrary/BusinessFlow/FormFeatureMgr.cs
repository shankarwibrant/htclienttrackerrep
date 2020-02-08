using HealthCareObjects.Client;
using PatientLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PatientLibrary.BusinessFlow
{
    [Serializable]
    public class FormFeatureMgr
    {

        public List<Feature> FormfeatureListbal()
        {
            FormFeatureDBops objff = new FormFeatureDBops();
            return objff.FormfeatureList();

        }

        public List<Feature> Formfeaturemodbal()
        {
            FormFeatureDBops objffmod = new FormFeatureDBops();
            return objffmod.Formfeaturemodule();
        }

        public List<Feature> Formfeatureformbal(int modulid)
        {
            FormFeatureDBops objfform = new FormFeatureDBops();
            return objfform.Formfeatureform(modulid);
        }

        public List<Feature> cmbformbal()
        {
            FormFeatureDBops objfform = new FormFeatureDBops();
            return objfform.cmbformdal();
        }
        public List<Feature> ListFeatureName(Int64 FormID)//,int ClientID)
        {
            try
            {
                FormFeatureDBops objfform = new FormFeatureDBops();
                return objfform.ListFeatureName(FormID);//, ClientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CreateBal(List<Feature> objtra)
        {
            Int64 FeatureId = 0;
            Int64 ModuleID = 0;
            Int64 FormID = 0;
            try
            {
                FormFeatureDBops objcreate = new FormFeatureDBops();
                foreach (Feature obj in objtra)
                {
                    if (obj.FeatureDtlId > 0)
                    {
                        objcreate.UpdateDal(obj);

                    }

                    else
                    {
                        if (obj.ModuleID != ModuleID && obj.FormID != FormID)
                        {
                            FeatureId = objcreate.Create(obj);
                            ModuleID = obj.ModuleID;
                            FormID = obj.FormID;
                        }
                        obj.FeatureID = FeatureId;
                        objcreate.Createtransaction(obj);

                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Updatebal(List<Feature> objupdtra, List<Feature> objformDeleteList)
        {
            try
            {
                FormFeatureDBops objupdate = new FormFeatureDBops();
                foreach (Feature objtra in objupdtra)
                {
                    if (objtra.FeatureDtlId != 0)
                    {
                        FormFeatureDBops objtrans = new FormFeatureDBops();
                        objtrans.UpdateDal(objtra);
                    }

                }
                if (objformDeleteList.Count > 0)
                {
                    foreach (Feature objissueDelete in objformDeleteList)
                    {
                        objupdate.DeleteDtl(objissueDelete);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteDtlFeature(Feature objdelftr)
        {
            FormFeatureDBops objdeleteform = new FormFeatureDBops();
            return objdeleteform.DeleteDtl(objdelftr);

        }

        public Boolean DeleteBal(Int64 id)
        {
            try
            {
                FormFeatureDBops objdelete = new FormFeatureDBops();
                return objdelete.DelateBal(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Feature> Listbal(int PageNo, int RowsPerPage, string SearchText)
        {
            FormFeatureDBops obj = new FormFeatureDBops();
            return obj.ListDal(PageNo, RowsPerPage, SearchText);
        }

        public List<Feature> Listchilbal(int Autoid)
        {
            FormFeatureDBops objchild = new FormFeatureDBops();
            return objchild.ListChildDal(Autoid);
        }

        public string AutoIdBal()
        {
            FormFeatureDBops objauto = new FormFeatureDBops();
            return objauto.AutoidDal();
        }



    }
}
