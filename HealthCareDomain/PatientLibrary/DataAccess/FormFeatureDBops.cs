using HealthCareObjects.Client;
using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PatientLibrary.DataAccess
{
  public class FormFeatureDBops
    {
        public Int64 Create(Feature objdal)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_createformfeature", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FeatureId", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Modulename", objdal.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formname", objdal.FormName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Featurename", objdal.FeatureName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Description", objdal.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formid", objdal.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SNo", objdal.SNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Moduleid", objdal.ModuleID));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objdal.FeatureID = Convert.ToInt64(param.Value);


                }
            }
            return objdal.FeatureID;
        }

        public string Createtransaction(Feature objdal)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_createtransaction", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", 1));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Modulename", objdal.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formname", objdal.FormName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@featureid", objdal.FeatureID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Featurename", objdal.FeatureName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@formid", objdal.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@moduleid", objdal.ModuleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Description", objdal.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SNo", objdal.SNo));

                    cmd.ExecuteNonQuery();

                }
            }
            return objdal.FeatureName;
        }

        public bool UpdateDal(Feature Objupdate)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_createtransaction", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", 0));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Modulename", Objupdate.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formname", Objupdate.FormName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Featurename", Objupdate.FeatureName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Description", Objupdate.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SNo", Objupdate.SNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@featureid", Objupdate.FeatureDtlId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@formid", Objupdate.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@moduleid", Objupdate.ModuleID));


                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool UpdateDaltrans(Feature objdal)
        {
            int RecordAffected;
            IDbCommand cmd = null;
            IDbConnection con = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_updatetrans", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(DataFactory.CreateParameter("@FeatureId", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Modulename", objdal.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formname", objdal.FormName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Featurename", objdal.FeatureName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Description", objdal.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Formid", objdal.FormID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SNo", objdal.SNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Moduleid", objdal.ModuleID));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objdal.FeatureID = Convert.ToInt64(param.Value);
                }
            }
            return true;
        }

        public Boolean DelateBal(Int64 id)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_deleteformfeature", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Autoid", id));
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public List<Feature> FormfeatureList()
        {
            List<Feature> obj1 = new List<Feature>();
            Feature objlist = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_formfeaturelist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objlist = new Feature();
                        objlist.F_Id = Convert.ToInt32(reader["F_Id"]);
                        objlist.FeatureName = Convert.ToString(reader["FeatureName"]);
                        obj1.Add(objlist);
                    }
                }
                reader.Close();
            }
            return obj1;

        }

        public List<Feature> Formfeaturemodule()
        {

            List<Feature> obj2 = new List<Feature>();
            Feature objmod = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_FormFeatureModule", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objmod = new Feature();

                        objmod.ModuleName = Convert.ToString(reader["ModuleName"]);
                        objmod.ModuleID = Convert.ToInt32(reader["ModuleID"]);
                        obj2.Add(objmod);
                    }
                }
                reader.Close();
            }
            return obj2;
        }

        public List<Feature> ListDal(int PageNo, int RowsPerPage, string SearchText)
        {
            List<Feature> listobj = new List<Feature>();
            Feature obj = null;
            IDataReader reader = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            int TotalRecords = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_Listmaingridnew", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            obj = new Feature();
                            obj.FeatureName = Convert.ToString(reader["FeatureName"]);
                            obj.Description = Convert.ToString(reader["Description"]);
                            obj.FormName = Convert.ToString(reader["Formname"]);
                            obj.ModuleName = Convert.ToString(reader["Modulename"]);
                            obj.SNo = DBNull.Value.Equals(reader["SNo"]) ? 0 : Convert.ToInt64(reader["SNo"]);
                            obj.FeatureID = DBNull.Value.Equals(reader["FeatureId"]) ? 0 : Convert.ToInt32(reader["FeatureId"]);
                            obj.ModuleID = DBNull.Value.Equals(reader["ModuleId"]) ? 0 : Convert.ToInt32(reader["ModuleId"]);

                            obj.TotalRecords = TotalRecords;
                            listobj.Add(obj);
                        }

                    }
                }
                reader.Close();
            }
            return listobj;
        }

        public List<Feature> ListChildDal(int Autoid)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            List<Feature> objlist = new List<Feature>();
            Feature obj = new Feature();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Listchildgrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Autoid", Autoid));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj = new Feature();
                        obj.ModuleName = Convert.ToString(reader["Modulname"]);
                        obj.FeatureName = Convert.ToString(reader["Featurename"]);
                        obj.FormName = Convert.ToString(reader["Formname"]);
                        obj.Description = Convert.ToString(reader["Description"]);
                        obj.FeatureID = Convert.ToInt32(reader["FeatureId"]);
                        obj.FeatureDtlId = Convert.ToInt32(reader["FeatureDtlId"]);
                        obj.SNo = Convert.ToInt64(reader["SNo"]);
                        obj.FormID = Convert.ToInt32(reader["FormId"]);
                        obj.ModuleID = Convert.ToInt32(reader["ModuleId"]);
                        objlist.Add(obj);
                    }
                }
                reader.Close();
            }
            return objlist;
        }

        public List<Feature> Formfeatureform(int modulid)
        {
            List<Feature> obj3 = new List<Feature>();
            Feature objform = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_FormFeatureForm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@moduleid", modulid));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objform = new Feature();
                        objform.FormID = Convert.ToInt32(reader["EntityID"]);
                        objform.FormName = Convert.ToString(reader["EntityName"]);
                        obj3.Add(objform);
                    }
                }
                reader.Close();
            }
            return obj3;
        }

        public List<Feature> cmbformdal()
        {
            List<Feature> obj3 = new List<Feature>();
            Feature objform = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_cmbFormnew", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objform = new Feature();

                        objform.FormName = Convert.ToString(reader["EntityName"]);
                        obj3.Add(objform);
                    }
                }
                reader.Close();
            }
            return obj3;
        }

        public string AutoidDal()
        {
            //List<Feature> AutoObj = new List<Feature>();
            //Feature obj = null;
            string AutoId = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_autoid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //obj = new Feature();
                        AutoId = Convert.ToString(reader["Autoid"]);
                        //AutoObj.Add(obj);
                    }
                }
                reader.Close();
            }
            return AutoId;
        }

        public Boolean DeleteDtl(Feature objdelete)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_Deleteformsno", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FeatureDtlId", objdelete.FeatureDtlId));
                    cmd.ExecuteNonQuery();
                }
            }
            return true;

        }

        public List<Feature> ListFeatureName(Int64 FormID)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            Feature obj = null;
            List<Feature> objlsitFeature = new List<Feature>();

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_ListFeatureName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FormID", FormID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj = new Feature();
                        obj.FeatureName = Convert.ToString(reader["FeatureName"]);
                        obj.FeatureID = Convert.ToInt64(reader["FeatureID"]);
                        objlsitFeature.Add(obj);
                    }
                }
                con.Close();
                return objlsitFeature;
            }

        }
    }
}
