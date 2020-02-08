using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using System.Configuration;

/////////////////////////////////////////////////////
///CreatedBy Newton     Date:30/01/2010
///Sl.No    ModifiedBy      Date        Changes Made
///1.       Newton          30/01/2010  Code Updation Comments Added          
///2.                                                   
//////////////////////////////////////////////////////

namespace HospitalManagement
{
    public enum DatabaseType
    {
        Access,
        SQLServer,
        Oracle
    }
    public enum DataType
    {
        Integer,
        Char,
        VarChar
    }

    public class DataFactory
    {

        private static DatabaseType _dbType;
        //private static DataType _dataType;

        static DataFactory()
        {
            string dbType = ConfigurationManager.AppSettings["DatabaseType"].ToString();
            //string paramType = ConfigurationManager.AppSettings[""].ToString();

            if (dbType.Equals("SqlServer"))
                _dbType = DatabaseType.SQLServer;
            else if (dbType.Equals("Oracle"))
                _dbType = DatabaseType.Oracle;
            else if (dbType.Equals("Access"))
                _dbType = DatabaseType.Access;
        }

        public static IDbConnection CreateConnection() 
        {
            System.Data.IDbConnection cnn;
            string ConnectionString;
            switch (_dbType)
            {
                case DatabaseType.Access: 

                    ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
                case DatabaseType.SQLServer:
                    ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
                default:
                    ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
            }

            return cnn;
        }

        public static System.Data.IDbCommand CreateCommand(string CommandText, System.Data.IDbConnection cnn)
        {
            System.Data.IDbCommand cmd;
            switch (_dbType)
            {
                case DatabaseType.Access:
                    cmd = new OleDbCommand(CommandText, (OleDbConnection)cnn);
                    break;
                case DatabaseType.SQLServer:
                    cmd = new SqlCommand(CommandText, (SqlConnection)cnn);
                    break;
                default:
                    cmd = new SqlCommand(CommandText, (SqlConnection)cnn);
                    break;
            }
            return cmd;
        }

        public static DbDataAdapter CreateAdapter(System.Data.IDbCommand cmd, DatabaseType dbtype)
        {
            DbDataAdapter da;
            switch (_dbType)
            {
                case DatabaseType.Access:
                    da = new OleDbDataAdapter((OleDbCommand)cmd);
                    break;
                case DatabaseType.SQLServer:
                    da = new SqlDataAdapter((SqlCommand)cmd);
                    break;
                default:
                    da = new SqlDataAdapter((SqlCommand)cmd);
                    break;
            }
            return da;
        }


        public static DbParameter CreateParameter(string paramName, object paramValue)
        {
            switch (_dbType)
            {
                case DatabaseType.SQLServer:
                    return new SqlParameter(paramName, paramValue);
            }
            return new SqlParameter(paramName, paramValue);
        }
    }
}








