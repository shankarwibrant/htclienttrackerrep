using HealthCareObjects.UserRights;
using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PatientLibrary.DataAccess
{
    
    public class LogInDA
    {
        public List<Login1> ListOrganizationName()
        {
            List<Login1> objOrgList = new List<Login1>();
            Login1 objOrg = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_OrgName_List", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objOrg = new Login1();
                        objOrg.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                        objOrg.OrganizationCode = Convert.ToString(reader["OrganizationCode"]);
                        objOrgList.Add(objOrg);
                    }
                    reader.Close();
                    return objOrgList;
                }
            }

        }


        public Login1 MyHome(string UserName, string Password)
        {
            Login1 objUserName = new Login1();
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_UserLogin", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", UserName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Password", Password));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        objUserName.UserName = Convert.ToString(reader["UserName"]);
                        objUserName.ClientID = Convert.ToInt64(reader["ClientID"]);
                        objUserName.UserID = Convert.ToInt64(reader["UserID"]);
                        objUserName.EmployeeCode = Convert.ToString(reader["EmployeeCode"]);
                    }
                    reader.Close();
                    return objUserName;
                }
            }

        }


        public String Orgname(string OrganizationCode)
        {
            string OrganizationName = string.Empty;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;

            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_OrgName", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@OrgaizationCode", OrganizationCode));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrganizationName = Convert.ToString(reader["OrganizationName"]);
                    }
                    reader.Close();
                    return OrganizationName;
                }
            }
        }


        public Login1 MyHome1(string UserName, string Password)
        {
            Login1 objUserName = new Login1();
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_loginclient", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", UserName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Password", Password));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        objUserName.UserName = Convert.ToString(reader["UserName"]);
                        objUserName.ClientID = Convert.ToInt64(reader["ClientID"]);
                        objUserName.UserID = Convert.ToInt64(reader["UserID"]);
                        objUserName.RoleID = Convert.ToInt32(reader["RoleId"]);

             
                    }
                    reader.Close();
                    return objUserName;
                }
            }
        }


    }
}