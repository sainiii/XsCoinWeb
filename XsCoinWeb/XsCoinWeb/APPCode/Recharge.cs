using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;


namespace XsCoinWeb
{
    public class Recharge
    {
        SqlConnection con = null;
        SqlCommand com = null;
        string UrlPrePaid = "http://103.29.232.110:8089/Ezypaywebservice/PushRequest.aspx?AuthorisationCode=7dca5d1793dc4348ad&product=";
        string UrlPOstPaid = "http://103.29.232.110:8089/Ezypaywebservice/postpaidpush.aspx?AuthorisationCode=7dca5d1793dc4348ad&product=";
        //1&MobileNumber=xxxxxxxxxx& Amount=500& RequestId=xxxxx&Circle=kolkata&AcountNo=55788922554&StdCode=033";
        List<ListItem> objList = null;
        string TranId = string.Empty;
        string results = string.Empty;
        static string Circle1, AcountNo1, StdCode1 = String.Empty;
        public string RechargeMobilePrePaid(string product, string ProductName, string mobile, string amount, string UserId)
        {
            try
            {
                TranId = GetTranNo();
                string BaseUrl = UrlPrePaid + Convert.ToInt32(product) + "&MobileNumber=" + mobile + "&Amount=" + amount + "&RequestId=" + TranId;
                if (Convert.ToInt32(product) == 1)
                {
                    BaseUrl = BaseUrl + "&StoreID=ALPANA000273EZPY";
                }
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(BaseUrl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    results = sr.ReadToEnd();
                    sr.Close();

                    WriteErrorLog(UserId + "," + mobile + "," + results.ToString() + "," + amount + " RechargeMobileDTH in Recharge.cs");
                    SaveRecharge(results, UserId, product, ProductName);
                    return results;
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.Message + " RechargeMobileDTH in Recharge.cs");
                    return "0";
                }
            }
            catch
            {
                return "Error";
            }
            finally
            {
            }
        }
        public string RechargeMobilePostPaid(string product, string ProductName, string mobile, string amount, string UserId, string Circle, string StdCode)
        {
            try
            {
                TranId = GetTranNo();
                Circle1 = Circle;
                StdCode1 = StdCode;
                string BaseUrl = UrlPOstPaid + Convert.ToInt32(product) + "&MobileNumber=" + mobile + "&Amount=" + amount + "&RequestId=" + TranId + "&Circle=" + Circle + "&AcountNo=55788922554&StdCode=" + StdCode;
                if (Convert.ToInt32(product) == 32)
                {
                    BaseUrl = BaseUrl + "&StoreID=ALPANA000273EZPY";
                }
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(BaseUrl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    results = sr.ReadToEnd();
                    sr.Close();

                    WriteErrorLog(UserId + "," + mobile + "," + results.ToString() + "," + amount + " RechargeMobileDTH in Recharge.cs");
                    SaveRecharge(results, UserId, product, ProductName);
                    return results;
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.Message + " RechargeMobileDTH in Recharge.cs");
                    return "0";
                }
            }
            catch
            {
                return "Error";
            }
            finally
            {
            }
        }
        public string productName(string proid)
        {
            try
            {
                con = new SqlConnection(method.str);
                com = new SqlCommand("select productName,pid from mobileproduct where code='" + proid + "'", con);
                com.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader rd = com.ExecuteReader();
                dt.Load(rd);
                string R = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    R = dt.Rows[0]["productName"].ToString() + "," + dt.Rows[0]["pid"].ToString();
                }
                return R;
            }
            catch
            {
                return "";
            }
        }
        public double SaveRecharge(string results, string userId, string product, string ProductName)
        {
            try
            {
                double Bal = 0;
                string[] docs = results.Split('~');
                string IT = docs[0];
                string TranNo = docs[1];
                string mobile = docs[2];
                int Response = Convert.ToInt32(docs[3]);
                string Description = docs[4];
                string Amount = docs[5];
                Circle1 = String.IsNullOrEmpty(Circle1) ? "Delhi" : Circle1;
                StdCode1 = String.IsNullOrEmpty(StdCode1) ? "0" : StdCode1;
                AcountNo1 = String.IsNullOrEmpty(AcountNo1) ? "" : AcountNo1;

                con = new SqlConnection(method.str);
                com = new SqlCommand("RechargeSave", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PregNo", userId);
                com.Parameters.AddWithValue("@productName", ProductName);
                com.Parameters.AddWithValue("@circle", Circle1);
                com.Parameters.AddWithValue("@product", product);
                com.Parameters.AddWithValue("@AcountNo", AcountNo1);
                com.Parameters.AddWithValue("@StdCode", StdCode1);
                com.Parameters.AddWithValue("@Result", results);
                com.Parameters.AddWithValue("@TranNo", TranNo);
                com.Parameters.AddWithValue("@Amount", Amount);
                com.Parameters.AddWithValue("@mobile", mobile);
                com.Parameters.AddWithValue("@Response", Response);
                com.Parameters.AddWithValue("@Description", Description);
                com.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@bal", SqlDbType.Float).Direction = ParameterDirection.Output;
                con.Open();
                com.ExecuteNonQuery();
                Bal = Convert.ToDouble(com.Parameters["@bal"].Value.ToString());
                con.Close();
                return Bal;
            }
            catch (Exception ex)
            {
                //Save 
                WriteErrorLog(ex.Message + "SaveRechargeStatus in utility.cs");
                if (con.State == ConnectionState.Open)
                    con.Close();
                return 0;
            }
        }

        public string GetUserId(string Mobile, string Types)
        {
            try
            {
                con = new SqlConnection(method.str);
                com = new SqlCommand("CheckUserID", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Mobile", Mobile);
                com.Parameters.AddWithValue("@CheckType", Types);
                com.Parameters.Add("@RegNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                con.Open();
                com.ExecuteNonQuery();
                return com.Parameters["@RegNo"].Value.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static void WriteErrorLog(string err)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"~/ErrorLog/Error.xml");
                XmlDocument doc = new XmlDocument();
                if (!System.IO.File.Exists(path))
                {
                    //Create neccessary nodes
                    XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                    XmlElement root = doc.CreateElement("Root");
                    doc.AppendChild(root);
                    doc.Save(path);
                }
                doc.Load(path);
                XmlNode newNode;
                newNode = doc.CreateElement("Error");
                newNode.InnerText = err + " " + DateTime.Now.ToString();
                doc.LastChild.AppendChild(newNode);
                doc.Save(path);
            }
            catch
            {
            }
        }
        public string GetTranNo()
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("UpdateTranNo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@TranNext", SqlDbType.Float).Direction = ParameterDirection.Output;
            con.Open();
            com.ExecuteNonQuery();
            string TranNo = com.Parameters["@TranNext"].Value.ToString();
            con.Close();
            return TranNo;
        }
        public List<ListItem> GetDataCardOperators()
        {
            //fist char of every item value is added to make the value unique.
            //it must should be extracted at the time of sending request to the server.
            objList = new List<ListItem>();
            objList.Add(new ListItem("Reliance NetConnect 1X", "4"));
            objList.Add(new ListItem("Reliance NetConnect+", "4"));
            //objList.Add(new ListItem("Reliance NetConnect 3G", "5"));
            objList.Add(new ListItem("Tata Photon Whiz", "9"));
            objList.Add(new ListItem("Tata Photon+", "9"));
            objList.Add(new ListItem("MTS MBlaze", "13"));
            objList.Add(new ListItem("MTS MBrowse", "13"));
            return objList;
        }
        //public List<ListItem> POSTPAID()
        //{
        //    objList = new List<ListItem>();
        //    objList.Add(new ListItem("AIRTEL", "32"));
        //    objList.Add(new ListItem("LANLINE -(LANLINE)", "48"));
        //    objList.Add(new ListItem("BSNL -(Mobile & Landline)", "31"));
        //    objList.Add(new ListItem("DOCOMO", "52"));
        //    objList.Add(new ListItem("IDEA", "33"));
        //    objList.Add(new ListItem("MTNL DEL -(LANDLINE)", "51"));
        //    objList.Add(new ListItem("RELIANCE", "47"));
        //    objList.Add(new ListItem("RELIANCE -(LANDLINE)", "49"));
        //    objList.Add(new ListItem("LOOP MOBILE", "50"));
        //    objList.Add(new ListItem("TATA INDICOM", "53"));
        //    objList.Add(new ListItem("VODAFONE", "35"));
        //    return objList;
        //}
        public List<ListItem> GetMobileOperators()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Airtel", "1"));
            objList.Add(new ListItem("Vodafone", "2"));
            objList.Add(new ListItem("BSNL", "3"));

            objList.Add(new ListItem("BSNL Recharge/Validity (RCV)", "301"));
            objList.Add(new ListItem("BSNL 3G", "302"));
            objList.Add(new ListItem("BSNL Special (STV)", "303"));
            objList.Add(new ListItem("Reliance CDMA", "4"));
            objList.Add(new ListItem("Reliance GSM", "5"));
            objList.Add(new ListItem("Aircel", "6"));
            objList.Add(new ListItem("MTNL TopUp", "25"));
            objList.Add(new ListItem("MTNL Recharge/Special", "2501"));
            objList.Add(new ListItem("Idea", "8"));
            objList.Add(new ListItem("Tata Indicom", "9"));
            objList.Add(new ListItem("Loop Mobile", "10"));
            objList.Add(new ListItem("Tata Docomo", "11"));
            objList.Add(new ListItem("Tata Docomo Special", "1101"));

            objList.Add(new ListItem("Virgin CDMA", "12"));
            objList.Add(new ListItem("MTS", "13"));
            objList.Add(new ListItem("Virgin GSM", "14"));
            objList.Add(new ListItem("S Tel", "15"));
            objList.Add(new ListItem("Uninor", "16"));
            objList.Add(new ListItem("Uninor Special", "1601"));
            objList.Add(new ListItem("Videocon", "17"));
            objList.Add(new ListItem("Videocon Special", "1701"));
            return objList;

        }

        public List<ListItem> GetDTHOperators()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Dish TV DTH", "18"));
            objList.Add(new ListItem("Tata Sky DTH", "19"));
            objList.Add(new ListItem("Big TV DTH", "20"));
            objList.Add(new ListItem("Videocon DTH", "21"));
            objList.Add(new ListItem("Sun DTH", "22"));
            objList.Add(new ListItem("Airtel DTH", "23"));
            return objList;
        }

        public List<ListItem> GetCircles()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Andhra Pradesh", "1"));
            objList.Add(new ListItem("Assam", "2"));
            objList.Add(new ListItem("Bihar & Jharkhand", "3"));
            objList.Add(new ListItem("Chennai", "4"));
            objList.Add(new ListItem("Delhi", "5"));
            objList.Add(new ListItem("Gujarat", "6"));
            objList.Add(new ListItem("Haryana", "7"));
            objList.Add(new ListItem("Himachal Pradesh", "8"));
            objList.Add(new ListItem("Jammu & Kashmir", "9"));
            objList.Add(new ListItem("Karnataka", "10"));
            objList.Add(new ListItem("Kerala", "11"));
            objList.Add(new ListItem("Kolkata", "12"));
            objList.Add(new ListItem("Maharashtra & Goa (except Mumbai)", "13"));
            objList.Add(new ListItem("Madhya Pradesh & Chhatisgarh", "14"));
            objList.Add(new ListItem("Mumbai", "15"));
            objList.Add(new ListItem("North East", "16"));
            objList.Add(new ListItem("Orissa", "17"));
            objList.Add(new ListItem("Panjab", "18"));
            objList.Add(new ListItem("Rajasthan", "19"));
            objList.Add(new ListItem("Tamil Nadu", "20"));
            objList.Add(new ListItem("Utter Pradesh - East", "21"));
            objList.Add(new ListItem("Utter Pradesh - West", "22"));
            objList.Add(new ListItem("West Bangal", "23"));

            return objList;

        }

        public List<ListItem> GetPostpaidMobileOperators()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Airtel", "31"));
            objList.Add(new ListItem("Vodafone", "33"));
            objList.Add(new ListItem("BSNL Mobile", "36"));
            objList.Add(new ListItem("Reliance CDMA", "35"));
            objList.Add(new ListItem("Reliance GSM", "34"));
            objList.Add(new ListItem("Idea", "32"));
            objList.Add(new ListItem("Tata Indicom", "39"));
            objList.Add(new ListItem("Loop Mobile", "40"));
            objList.Add(new ListItem("Tata Docomo GSM", "38"));
            return objList;
        }


        public List<ListItem> GetLandLineNBroadBandOprtr()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Airtel Landline", "42"));
            objList.Add(new ListItem("BSNL Landline", "37"));
            objList.Add(new ListItem("MTNL Landline", "41"));
            return objList;
        }

        public List<ListItem> GetElectricityOptr()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("BSES Rajdhani Power Limited - Delhi", "43"));
            objList.Add(new ListItem("BSES Yamuna Power Limited - Delhi", "44"));
            objList.Add(new ListItem("Tata Power Delhi Limited - Delhi", "45"));
            objList.Add(new ListItem("Reliance Energy Limited", "46"));
            objList.Add(new ListItem("North Bihar Electricity", "52"));
            objList.Add(new ListItem("South Bihar Electricity", "53"));
            objList.Add(new ListItem("Best Electricity - Mumbai", "54"));
            return objList;
        }

        public List<ListItem> GetInsuranceOptr()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("ICICI Prudential Life Insurance", "48"));
            objList.Add(new ListItem("Tata AIA Life Insurance", "49"));
            return objList;
        }


        public List<ListItem> GetGasOptr()
        {
            objList = new List<ListItem>();
            objList.Add(new ListItem("Mahanagar Gas", "47"));
            return objList;
        }
    }
}