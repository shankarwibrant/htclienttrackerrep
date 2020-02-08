using HealthCareMvc5.Controllers.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using HealthCareObjects.UserRights;
using HealthCareMvc5.LogInServiceReference;
using System.Web.UI.WebControls;

namespace HealthCareMvc5.Controllers
{
    public class LoginController : Controller
    {
        string Servicepath = Convert.ToString(WebConfigurationManager.AppSettings["ServicePath"]);
        string ConnectionString = Convert.ToString(WebConfigurationManager.AppSettings["ConnectionString"]);

        static string UserNamevalid = string.Empty;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SessionExpiry(bool log = true)
        {

            if ((Session["Userid"] != null) || (Session["Userid"] == null))
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                FormsAuthentication.SignOut();


                this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetNoStore();
            }

            if (!log)
            {
                ViewData["a"] = "Invalid Username or Password";
            }
          
            return View();
        }




        static byte[] img = new byte[0];
        Int64 EmployID;
        
        public void Getimage()
        {

            EmployID = Convert.ToInt64(@Session["EmployeeID"]);
            string strcon = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];//"Data Source=hmssource;Initial Catalog=quill;User Id=sa;Pwd=Vibrant123*;";
            string imageid = null;

            imageid = Convert.ToString(EmployID);

            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_Viewuserimage", connection);
            command.Parameters.Add(new SqlParameter("@employeeID", imageid));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Response.BinaryWrite((byte[])dr["Empimage"]);

            }


        }

        public ActionResult Login(bool log = true)
        {

            if ((Session["Userid"] != null) || (Session["Userid"] == null))
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                FormsAuthentication.SignOut();


                this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetNoStore();
            }

            if (log == false)
            {
                ViewData["check"] = "Invalid Username or Password";
            }
           
            return View();
        }
        public static void Main()
        {
            try
            {
                string original = "Here is some data to encrypt!";
                // Create a new instance of the AesCryptoServiceProvider 
                // class.  This generates a new key and initialization  
                // vector (IV). 
                using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
                {
                    // Encrypt the string to an array of bytes. 
                    byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
                    // Decrypt the bytes to a string. 
                    string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream. 
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;
            // Create an AesCryptoServiceProvider object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt =
                            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }


            }
            return plaintext;
        }


        public ActionResult Loginpage(bool log = true, bool session = true)
        {
            if (Session["Userid"] != null)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                FormsAuthentication.SignOut();


                this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetNoStore();
            }

            if (!log)
            {
                ViewData["a"] = "Invalid Username or Password";
            }
            if (session == false)
            {
                ViewData["a"] = "Your Session has Expired";
            }
           
            return View();
        }

        
 

   
        //[HttpPost]
        //public ActionResult ResetPassword(RoleProfileServiceRef.RoleProfile user)
        //{


        //    RoleProfileServiceRef.RoleProfile samp1 = new RoleProfileServiceRef.RoleProfile();

        //    if (user.UserID != 0)
        //    {

        //        samp1.UserID = user.UserID;
        //        samp1.Password = user.Password;
        //        samp1.Description = user.Description;
        //        var s = UpdatePassword(samp1);
        //        if (s == false)
        //        {
        //            return Json(0);
        //        }
        //        else
        //        {
        //            return Json(1);
        //        }


        //    }
        //    return View();


        //}

        private static string GetEncryptedData(string sourceData)
        {
            if (!string.IsNullOrEmpty(sourceData))
            {
                byte[] sourceBytes = ASCIIEncoding.ASCII.GetBytes(sourceData);
                return Convert.ToBase64String(sourceBytes);
            }
            return string.Empty;
        }
        //public List<General>

        //public Boolean UpdatePassword(RoleProfileServiceRef.RoleProfile user)
        //{
        //    SqlConnection conn = null;
        //    SqlCommand cmd = null;
        //    RoleProfileServiceRef.RoleProfile MyData = new RoleProfileServiceRef.RoleProfile();
        //    int RecordsAffected;

        //    string Password = user.Password;
        //    string oldpwd = user.Description;
        //    var pwd = GetEncryptedData(Password);
        //    var oldpassword = GetEncryptedData(oldpwd);
        //    using (conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        cmd = conn.CreateCommand();
        //        using (cmd = new SqlCommand("sp_UserUpdatePassword", conn))
        //        {

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add(new SqlParameter("@Password", pwd));
        //            cmd.Parameters.Add(new SqlParameter("@OldPassword", oldpassword));
        //            cmd.Parameters.Add(new SqlParameter("@UserID", user.UserID));

        //            RecordsAffected = cmd.ExecuteNonQuery();


        //        }
        //        if (RecordsAffected > 0)
        //            return true;
        //        else
        //            return false;

        //    }
        //}
        public ActionResult Strap()
        {

            string[] months = new string[13];
            months[1] = "January";
            months[2] = "February";
            months[3] = "March";
            months[4] = "April";
            months[5] = "May";
            months[6] = "June";
            months[7] = "July";
            months[8] = "August";
            months[9] = "September";
            months[10] = "October";
            months[11] = "November";
            months[12] = "December";

            ViewData["day"] = DateTime.Now.DayOfWeek.ToString();
            ViewData["month"] = months[DateTime.Now.Month];
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }


        /// <summary>
        /// method to get Client ip address
        /// </summary>
        /// <param name="GetLan"> set to true if want to get local(LAN) Connected ip address</param>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;


        }





     
        string AudiTrail = "";
        Int64 USERID = 1;
        Int64 moduleid = 1;
        Int64 formid = 0;
        Int64 billid = 0;

        public string Create_AudiTrail()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            //SqlDataReader reader;
            int RecordsAffected = 0;
            string Auditrail_ID = string.Empty;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("SP_IPAUDITRAIL", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Auditrail_ID", DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("IP_Address", AudiTrail));
                    cmd.Parameters.Add(new SqlParameter("SYSTEM_DATE", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("UserID", USERID));
                    cmd.Parameters.Add(new SqlParameter("UserName", ""));
                    cmd.Parameters.Add(new SqlParameter("ModuleID", moduleid));
                    cmd.Parameters.Add(new SqlParameter("ModuleName", "Login"));
                    cmd.Parameters.Add(new SqlParameter("FormID", formid));
                    cmd.Parameters.Add(new SqlParameter("FormName", "Login"));
                    cmd.Parameters.Add(new SqlParameter("ButtonClick_Type", "Logined"));
                    cmd.Parameters.Add(new SqlParameter("Bill_ID", billid));

                    IDbDataParameter param = new SqlParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                    Auditrail_ID = param.Value.ToString();

                }
                if (RecordsAffected > 0)
                    return Convert.ToString(Auditrail_ID);
                else
                    return Convert.ToString(Auditrail_ID);
            }
        }


        //public HealthCareObjects.Inventory.General ListRoundingDetails(Int64 ClientId)
        //{
        //    SqlConnection conn = null;
        //    SqlCommand cmd = null;
        //    IDataReader reader;
        //    HealthCareObjects.Inventory.General gen = null;
        //    List<HealthCareObjects.Inventory.General> lstGen = new List<HealthCareObjects.Inventory.General>();
        //    using (conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        cmd = conn.CreateCommand();
        //        using (cmd = new SqlCommand("Sp_ListRounding", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("CLIENTID", ClientId));
        //            reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                gen = new HealthCareObjects.Inventory.General();
        //                gen.PpPrice = DBNull.Value.Equals(reader["Ppprice"]) ? 0 : Convert.ToInt64(reader["Ppprice"]);
        //                gen.ConPrice = DBNull.Value.Equals(reader["Conprice"]) ? 0 : Convert.ToInt64(reader["Conprice"]);
        //                gen.PpQty = DBNull.Value.Equals(reader["Ppqty"]) ? 0 : Convert.ToInt64(reader["Ppqty"]);
        //                gen.ConQty = DBNull.Value.Equals(reader["Conqty"]) ? 0 : Convert.ToInt64(reader["Conqty"]);
        //                gen.PoPrice = DBNull.Value.Equals(reader["Poprice"]) ? 0 : Convert.ToInt64(reader["Poprice"]);
        //                gen.PoQty = DBNull.Value.Equals(reader["Poqty"]) ? 0 : Convert.ToInt64(reader["Poqty"]);
        //                gen.GrnPrice = DBNull.Value.Equals(reader["GRNprice"]) ? 0 : Convert.ToInt64(reader["GRNprice"]);
        //                gen.GrnQty = DBNull.Value.Equals(reader["GRNqty"]) ? 0 : Convert.ToInt64(reader["GRNqty"]);
        //                gen.PayPrice = DBNull.Value.Equals(reader["Payprice"]) ? 0 : Convert.ToInt64(reader["Payprice"]);
        //                gen.StockQty = DBNull.Value.Equals(reader["Stockqty"]) ? 0 : Convert.ToInt64(reader["Stockqty"]);
        //                gen.AdsQty = DBNull.Value.Equals(reader["Adsqty"]) ? 0 : Convert.ToInt64(reader["Adsqty"]);
        //                gen.TranPrice = DBNull.Value.Equals(reader["Transprice"]) ? 0 : Convert.ToInt64(reader["Transprice"]);
        //                gen.TranQty = DBNull.Value.Equals(reader["Transqty"]) ? 0 : Convert.ToInt64(reader["Transqty"]);
        //                gen.GoodQty = DBNull.Value.Equals(reader["Noteqty"]) ? 0 : Convert.ToInt64(reader["Noteqty"]);
        //                gen.VcolQty = DBNull.Value.Equals(reader["Vcolqty"]) ? 0 : Convert.ToInt64(reader["Vcolqty"]);
        //                gen.ExQty = DBNull.Value.Equals(reader["Exqty"]) ? 0 : Convert.ToInt64(reader["Exqty"]);
        //                gen.QuoQty = DBNull.Value.Equals(reader["Quoqty"]) ? 0 : Convert.ToInt64(reader["Quoqty"]);
        //                gen.QutoPrice = DBNull.Value.Equals(reader["QuoPrice"]) ? 0 : Convert.ToInt64(reader["QuoPrice"]);
        //                gen.PredQty = DBNull.Value.Equals(reader["Predqty"]) ? 0 : Convert.ToInt64(reader["Predqty"]);
        //                gen.PromoPrice = DBNull.Value.Equals(reader["Promoprice"]) ? 0 : Convert.ToInt64(reader["Promoprice"]);
        //                gen.PromoQty = DBNull.Value.Equals(reader["Promoqty"]) ? 0 : Convert.ToInt64(reader["Promoqty"]);
        //                gen.InreqQty = DBNull.Value.Equals(reader["Ireqqty"]) ? 0 : Convert.ToInt64(reader["Ireqqty"]);
        //                gen.InwardQty = DBNull.Value.Equals(reader["Inwarqty"]) ? 0 : Convert.ToInt64(reader["Inwarqty"]);
        //                gen.SalesPrice = DBNull.Value.Equals(reader["Salesprice"]) ? 0 : Convert.ToInt64(reader["Salesprice"]);
        //                gen.SalesQty = DBNull.Value.Equals(reader["Salesqty"]) ? 0 : Convert.ToInt64(reader["Salesqty"]);
        //                gen.SalesReQty = DBNull.Value.Equals(reader["Saretqty"]) ? 0 : Convert.ToInt64(reader["Saretqty"]);
        //                gen.SaDuePrice = DBNull.Value.Equals(reader["Sadueprice"]) ? 0 : Convert.ToInt64(reader["Sadueprice"]);
        //                gen.ProfPrice = DBNull.Value.Equals(reader["Profprice"]) ? 0 : Convert.ToInt64(reader["Profprice"]);
        //                gen.ProfQty = DBNull.Value.Equals(reader["Profqty"]) ? 0 : Convert.ToInt64(reader["Profqty"]);
        //                gen.RoundDig = DBNull.Value.Equals(reader["RoundingValue"]) ? 0 : Convert.ToInt64(reader["RoundingValue"]);
        //                gen.Bar1 = DBNull.Value.Equals(reader["Bar1"]) ? 0 : Convert.ToInt64(reader["Bar1"]);
        //                gen.Bar2 = DBNull.Value.Equals(reader["Bar2"]) ? 0 : Convert.ToInt64(reader["Bar2"]);
        //                gen.Bar3 = DBNull.Value.Equals(reader["Bar3"]) ? 0 : Convert.ToInt64(reader["Bar3"]);
        //                gen.GSTId = DBNull.Value.Equals(reader["GstNameId"]) ? 0 : Convert.ToInt64(reader["GstNameId"]);
        //                gen.InputTax = DBNull.Value.Equals(reader["InputTax"]) ? 0 : Convert.ToInt64(reader["InputTax"]);
        //                gen.OutputTax = DBNull.Value.Equals(reader["OutputTax"]) ? 0 : Convert.ToInt64(reader["OutputTax"]);
        //                gen.Birthday = DBNull.Value.Equals(reader["Birthday"]) ? 0 : Convert.ToInt64(reader["Birthday"]);
        //                gen.CardNo = DBNull.Value.Equals(reader["CardNo"]) ? 0 : Convert.ToInt64(reader["CardNo"]);
        //                gen.CardType = DBNull.Value.Equals(reader["CardType"]) ? 0 : Convert.ToInt64(reader["CardType"]);
        //                gen.Price = DBNull.Value.Equals(reader["SaNotiPrice"]) ? 0 : Convert.ToInt64(reader["SaNotiPrice"]);
        //                gen.Minimum = DBNull.Value.Equals(reader["MinPoints"]) ? 0 : Convert.ToInt64(reader["MinPoints"]);
        //                gen.Maximum = DBNull.Value.Equals(reader["MaxPoints"]) ? 0 : Convert.ToInt64(reader["MaxPoints"]);
        //                // gen.GSTId = DBNull.Value.Equals(reader["GstNameId"]) ? 0 : Convert.ToInt64(reader["GstNameId"]);
        //                // gen.ClientId = DBNull.Value.Equals(reader[""]) ? 0 : Convert.ToInt64(reader[""]);
        //            }
        //            reader.Close();
        //            return gen;

        //        }
        //    }
        //}

        
        



        public int NoLoginCounts(Int64 userId, Int64 ClientID) //BALA
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            IDataReader reader;
            int Count = 0;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_LoginUserCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", userId));
                    cmd.Parameters.Add(new SqlParameter("@Clientid", ClientID));

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Count = Convert.ToInt16(reader["LoginUser"]);
                    }
                    reader.Close();
                    return Count;

                }
            }
        }






        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Loginpage1(string UName, string Password)
        {

            LogInServiceClient obj = new LogInServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "LogInService.svc")));
            Login1 log = obj.UserDetails(UName, Password);

            Session["UserName"] = log.UserName;
            Session["UserId"] = log.UserID;
            Session["CilentID"] = log.ClientID;
            Session["Employee"] = log.Employee;
            Session["EmployeeName"] = log.EmployeeName;
            Session["DesignationName"] = log.Designation;
            Session["Departmentname"] = log.Department;
            Session["UserList"] = log;
            Session["EmployeeID"] = log.EmployeeID;
            Session["RoleID"] = log.RoleID;

            if (UName == "admin" || UName == "Admin" || UName == "ADMIN")
            {
                log.UserName = "admin";
                Session["UserName"] = log.UserName;
                Session["Employee"] = "ADMIN";
                Session["EmployeeName"] = "ADMIN";
                Session["DesignationName"] = "ADMINISTRATOR";
                Session["Departmentname"] = "ADMIN";

                List<Login1> oo = new List<Login1>();
                oo = ListMainmenu(log.UserID);
                var d = oo.Count;
                Session["list"] = oo;
                Session["list1"] = Listsubmenu(log.UserID);

            }

            if (log.UserName == UName)
            {
                UserNamevalid = string.Empty;
                List<Login1> oo = new List<Login1>();
                oo = ListMainmenu(log.UserID);
                var d = oo.Count;
                Session["list"] = oo;
                Session["list1"] = Listsubmenu(log.UserID);
                return RedirectToAction("Strap", "Login");
            }

            
            else
            {
                return RedirectToAction("Login", "Login/Login", new { log = false });
            }
           
        }

        public List<Login1> ListMainmenu(Int64 EmployeeId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader;
            List<Login1> objlist = new List<Login1>();
            Login1 obj = null;

            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("laymain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userid", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj = new Login1();
                        obj.Mid = DBNull.Value.Equals(reader["ModuleTypeId"]) ? 0 : Convert.ToInt64(reader["ModuleTypeId"]);
                        obj.title = DBNull.Value.Equals(reader["ModuleName"]) ? "" : Convert.ToString(reader["ModuleName"]);

                        objlist.Add(obj);
                    }
                    reader.Close();
                }

                return objlist;
            }
        }

        public List<Login1> Listsubmenu(Int64 EmployeeId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader;
            List<Login1> objlist = new List<Login1>();
            Login1 obj = null;

            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("laysubmain", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@userid", EmployeeId));
                    reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        obj = new Login1();
                        obj.Sid = DBNull.Value.Equals(reader["ModuleTypeId"]) ? 0 : Convert.ToInt64(reader["ModuleTypeId"]);
                        obj.title = DBNull.Value.Equals(reader["ModuleName"]) ? "" : Convert.ToString(reader["ModuleName"]);
                        obj.Link = DBNull.Value.Equals(reader["EntityPath"]) ? "" : Convert.ToString(reader["EntityPath"]);
                        obj.Stitle = DBNull.Value.Equals(reader["EntityName"]) ? "" : Convert.ToString(reader["EntityName"]);

                        objlist.Add(obj);


                    }

                    reader.Close();
                }

                return objlist;

            }

        }


        
  public Boolean UpdateUser(string UserId, string Password, string ConfirmPassword)
        {
            LogInServiceClient obj = new LogInServiceClient(RIAGlobal.GetBinding(), new EndpointAddress(RIAGlobal.GetServicePath(Servicepath, "LogInService.svc")));

            User objUser = new User();

            objUser.UserID = Convert.ToInt64(@Session["UserId"]);
            objUser.Password = Convert.ToString(ConfirmPassword);
            objUser.CreatedBy = objUser.UserID;

            string password = objUser.Password;
            objUser.Password = GetEncryptedData(password);

            Update(objUser);
            return true;
        }
        
        public Boolean Update(User objUser)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            int RecordsAffected = 0;
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("Sp_pwdchange", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("UserId", objUser.UserID));
                    cmd.Parameters.Add(new SqlParameter("Password", objUser.Password));
                    cmd.Parameters.Add(new SqlParameter("CreatedBy", objUser.CreatedBy));

                    IDbDataParameter param = new SqlParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                }
                if (RecordsAffected == -1)
                    return true;
                else
                    return false;

            }
        }

        public ActionResult compare(string txtuser)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<User> l = new List<User>();
            User ob;
            string sa = null;
            using (con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (cmd = new SqlCommand("Sp_compareusid22", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserId", txtuser));

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ob = new User();

                        ob.Description = Convert.ToString(dr["password"]);
                        Byte[] data = Convert.FromBase64String(ob.Description);

                        //Byte[] decrypt = ProtectedData.Unprotect(data, null,Scope);
                        sa = ASCIIEncoding.ASCII.GetString(data);
                    }
                }
            }


            return Json(sa, JsonRequestBehavior.AllowGet);
        }


    }
}
