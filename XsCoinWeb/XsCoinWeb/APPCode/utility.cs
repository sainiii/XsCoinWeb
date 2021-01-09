using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
/// <summary>
/// Summary description for utility
/// </summary>

namespace XsCoinWeb
{
    public class utility
    {
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        SqlConnection con = new SqlConnection(method.str);
        SqlCommand com;
        SqlDataAdapter da;

        SqlDataReader sr;
        Boolean flag;
        WebClient client = null;
        //string url = "http://www.mobilerechargeindia.in/api/recharge.php?uid=76697374616e656f74656368&pin=4f2792d87edd4&";
        //string url = "http://www.paysuvidha.biz/api/recharge.php?uid=736d61727432303135&pin=3dc4c45322d639c6f43b78860f7a0ad9&";
        string url = "http://www.smsalertbox.com/api/recharge.php?uid=737361696e69&pin=78fc5e587edcaf729b1f7b09c04d4022&";

        public DataTable search(string a, string b)
        {
            string qstr = "select appmstregno,AppmstFName,AppMstLName,AppMstCity,AppmstState,SponsorId,AppmstDoj=convert(char(20),Appmstdoj,103) from AppMst where " + a + " like " + b + "";
            com = new SqlCommand(qstr, con);
            da = new SqlDataAdapter(com);
            DataTable t = new DataTable();
            da.Fill(t);
            return t;


        }



        public double GetBalance(string balance)
        {
            client = new WebClient();
            try
            {
                //http://smsalertbox.com/api/dailyreport.php?uid=737361696e69&pin=PIN&date=DATE&format=RESPONSE_FORMAT&version=4
                // "http://www.smsalertbox.com/api/dailyreport.php?uid=737361696e69&pin=78fc5e587edcaf729b1f7b09c04d4022&route=recharge";

                string baseurl = "http://www.smsalertbox.com/api/balance.php?uid=737361696e69&pin=78fc5e587edcaf729b1f7b09c04d4022&route=recharge";

                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    utility.WriteErrorLog(balance + " GetBalance in utility.cs");
                    return Convert.ToDouble(results);
                }
                catch (Exception ex)
                {
                    utility.WriteErrorLog(ex.Message + " GetBalance in utility.cs");
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
            }
        }



        public string RechargeMobileDTH(string mobile, string circleCode, string operatorCode, string amount)
        {
            client = new WebClient();
            try
            {
                string query = "number=" + mobile + "&circle=" + circleCode + "&operator=" + operatorCode + "&amount=" + amount;
                string baseurl = url + query;
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    utility.WriteErrorLog(mobile + "," + circleCode + "," + operatorCode + "," + amount + " RechargeMobileDTH in utility.cs");
                    return results;
                }
                catch (Exception ex)
                {
                    utility.WriteErrorLog(ex.Message + " RechargeMobileDTH in utility.cs");
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
        public string PayPostpaidLandLine(string mobile, string circleCode, string operatorCode, string amount, string AccountNo)
        {
            client = new WebClient();
            try
            {
                string query = "number=" + mobile + "&circle=" + circleCode + "&operator=" + operatorCode + "&amount=" + amount + "&account=" + AccountNo;
                string baseurl = url + query;
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    utility.WriteErrorLog(mobile + "," + circleCode + "," + operatorCode + "," + amount + " PayPostpaidLandLine in utility.cs");
                    return results;
                }
                catch (Exception ex)
                {
                    utility.WriteErrorLog(ex.Message + " PayPostpaidLandLine in utility.cs");
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
        public string PayElectricBill(string mobile, string AccountNo, string operatorCode, string amount)
        {
            client = new WebClient();
            try
            {





                string query = "number=" + mobile + "&operator=" + operatorCode + "&amount=" + amount + "&account=" + AccountNo;
                string baseurl = url + query;
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    utility.WriteErrorLog(AccountNo + "," + operatorCode + "," + amount + " PayElectricBill in utility.cs");
                    return results;
                }
                catch (Exception ex)
                {
                    utility.WriteErrorLog(ex.Message + " PayElectricBill in utility.cs");
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
        public string PayGasBill(string Number, string operatorCode, string amount)
        {
            client = new WebClient();
            try
            {
                string query = "number=" + Number + "&operator=" + operatorCode + "&amount=" + amount;
                string baseurl = url + query;
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    utility.WriteErrorLog(Number + "," + operatorCode + "," + amount + " PayGasBill in utility.cs");
                    return results;
                }
                catch (Exception ex)
                {
                    utility.WriteErrorLog(ex.Message + " PayGasBill in utility.cs");
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
        public double SaveRechargeStatus(string uid, string mobile, string amt, string status, string circle, string Operatr, string rechType, string loadType)
        {
            try
            {
                WriteErrorLog(uid + "," + mobile + "," + amt + "," + status + "," + circle + "," + Operatr + "," + rechType + "," + "SaveRechargeStatus in utility.cs ");
                string[] str = status.Split(',');
                double realamt = status.Contains("SUCCESS") && str.Length >= 3 && IsNumeric(str[2]) ? Convert.ToDouble(str[2]) : 0;
                if (String.IsNullOrEmpty(realamt.ToString()))
                    realamt = 0;
                con = new SqlConnection(method.str);
                com = new SqlCommand("FundRecharge", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PregNo", uid);
                com.Parameters.AddWithValue("@mobile", mobile);
                com.Parameters.AddWithValue("@Amt", amt);
                com.Parameters.AddWithValue("@status", status);
                com.Parameters.AddWithValue("@circle", circle);
                com.Parameters.AddWithValue("@optr", Operatr);
                com.Parameters.AddWithValue("@realAmt", realamt);
                com.Parameters.AddWithValue("@recType", rechType);
                com.Parameters.AddWithValue("@loadType", loadType);
                com.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@bal", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                com.ExecuteNonQuery();
                double Bal = Convert.ToDouble(com.Parameters["@bal"].Value.ToString());
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
        public double SavePayBillStatus(string uid, string mobile, string accountNo, string amt, double commission, string status, string circle, string Operatr, string rechType, string loadType)
        {
            try
            {
                WriteErrorLog(uid + "," + accountNo + "," + mobile + "," + amt + "," + status + "," + circle + "," + Operatr + "," + rechType + "," + "SavePayBillStatus in utility.cs ");
                string[] str = status.Split(',');
                double realamt = status.Contains("SUCCESS") && str.Length >= 3 && IsNumeric(str[2]) ? Convert.ToDouble(str[2]) : 0;
                con = new SqlConnection(method.str);
                com = new SqlCommand("FundRecharge", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PregNo", uid);
                com.Parameters.AddWithValue("@mobile", mobile);
                //com.Parameters.AddWithValue("@commision", commission);

                //com.Parameters.AddWithValue("@acno", accountNo);
                com.Parameters.AddWithValue("@Amt", amt);
                com.Parameters.AddWithValue("@status", status);
                //com.Parameters.AddWithValue("@doe", DateTime.UtcNow.AddMinutes(330));
                com.Parameters.AddWithValue("@circle", circle);
                com.Parameters.AddWithValue("@optr", Operatr);
                com.Parameters.AddWithValue("@realAmt", realamt);
                com.Parameters.AddWithValue("@recType", rechType);
                com.Parameters.AddWithValue("@loadType", loadType);
                com.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@bal", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                com.ExecuteNonQuery();
                double Bal = Convert.ToDouble(com.Parameters["@bal"].Value.ToString());
                con.Close();
                return Bal;
            }
            catch (Exception ex)
            {
                //Save 
                WriteErrorLog(ex.Message + "SavePayBillStatus in utility.cs");
                if (con.State == ConnectionState.Open)
                    con.Close();
                return 0;
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
        public DataTable searchPin(string strSearch, string min, string max)
        {
            DataTable t = new DataTable();
            try
            {
                string qstr = "select p.Pinsrno,paidappmstid=case p.paidappmstid  when 0 then 'UN USED' when 1 then 'USED' end,UPPER(p.remark) AS remark," +
                "(select Appmstregno from appmst where appmstid=p.RegNo) as usedby,(select AppMstFName from appmst where appmstid=p.RegNo) as usedbyname, " +
                "p.joinfor,pintype=case p.pintype when 0 then 'NOT UPDATED' when 1 then 'JOINING' when 2 then 'TOP UP' end,p.amount, " +
                "a.Appmstregno as allotedto, " +
                "a.AppMstFName as allotedtoname, " +
                "plantype=case p.plantype  when 1 then 'SAVING PLUS' when 2 then 'SAVE SURPLUS' when 3 then 'IMS' end, " +
                "allotmentdate=convert(char(20),p.allotmentdate,103) from pinmst p inner join AppMst a on p.allotedto=a.AppMstID " +
                "and (p.pinsrno like @search or  a.AppMstRegNo like @search or p.amount like @search ) and " +
                "(case when @min is null or len(@min)=0 then 1 when @min is not null and @min<>'' and  cast(floor(cast(p.allotmentdate as float)) as datetime)>=cast(floor(cast(convert(datetime,@min) as float)) as datetime) then 1 " +
                "else 0 end)=1 " +
                "and  " +
                "(case when @max is null or LEN(@max)=0 then 1 when @max is not null and @max <>'' and cast(floor(cast(p.allotmentdate as float)) as datetime)<=cast(floor(cast(convert(datetime,@max) as float)) as datetime) then 1 " +
                "else 0 end)=1 ";

                com = new SqlCommand(qstr, con);
                com.Parameters.AddWithValue("@search", strSearch);
                com.Parameters.AddWithValue("@min", min);
                com.Parameters.AddWithValue("@max", max);
                da = new SqlDataAdapter(com);
                da.Fill(t);
            }
            catch (Exception ex)
            {
            }
            return t;

        }


        public static void CheckSuperAdminlogin()
        {

            try
            {
                string admin = HttpContext.Current.Session["admin"].ToString();
                if (Regex.Match(admin, @"^[a-zA-Z0-9]*$").Success)
                {
                    if (HttpContext.Current.Session["admin"] == null)
                    {
                        HttpContext.Current.Response.Redirect("adminLog.aspx");
                    }
                    else
                    {
                        string admid = null;
                        string admpwd = null;
                        admid = HttpContext.Current.Session["admin"].ToString();
                        SqlConnection con = new SqlConnection(method.str);
                        string sqltext = "SessionsuperAdminExsist";
                        SqlCommand cmd = new SqlCommand(sqltext, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@uname", admid);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                        }
                        else
                        {
                            HttpContext.Current.Response.Redirect("adminLog.aspx");
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("adminLog.aspx");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("adminLog.aspx");
            }
        }
        public Boolean IsNumeric(string str)
        {
            if (Regex.Match(str, "^[0-9]+(\\.[0-9]{1,20})?$").Success)
                return true;
            else
                return false;
        }
        public Boolean IsAlphaNumeric(string str)
        {
            if (Regex.Match(str, @"^[a-zA-Z0-9]*$").Success)
                return true;
            else
                return false;
        }
        public Boolean IsAlphabet(string str)
        {
            if (Regex.Match(str, @"^[a-zA-Z]*$").Success)
                return true;
            else
                return false;
        }
        public string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                return "";
                //throw new Exception("Error in base64Encode" + ex.Message);

            }
        }

        public string base64Decode(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            try
            {
                byte[] todecode_byte = Convert.FromBase64String(sData);

                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception err)
            {

                //Response.Redirect("~/error.aspx");
                return "";
            }

        }
        public Boolean IsValidDate(int day, int month, int year)
        {

            try
            {
                if ((year % 4) == 0)
                    if ((day > 29) && (month == 2))
                        flag = false;

                    else
                        if ((month == 4) || (month == 6) || (month == 9) || (month == 11))
                        if (day > 30)
                            flag = false;
                        else
                            flag = true;

                    else
                        flag = true;

                else

                    if ((day > 28) && (month == 2))
                    flag = false;
                else
                        if ((month == 4) || (month == 6) || (month == 9) || (month == 11))

                    if (day > 30)
                        flag = false;
                    else
                        flag = true;

                else
                    flag = true;

            }
            catch
            {
                flag = false;
            }
            return flag;
        }



        public void sendsms(string mobile, String Text)
        {
            WebClient client = new WebClient();
            string website = string.Empty, url = string.Empty;
            con = new SqlConnection(method.str);
            SqlCommand cmd = new SqlCommand("selectSMSInformation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        website = rdr["website"].ToString().Trim();
                        url = rdr["url"].ToString().Trim();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            try
            {
                if (!string.IsNullOrEmpty(url.Trim()))
                {
                    if (mobile.Trim().Length > 9)
                    {
                        Text = Text + "from " + website;
                        string baseurl = url + "&mobileno=" + mobile.Trim() + "&msgtext=" + Text.Trim() + " ";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                        if (s.Split(',').GetValue(2).ToString() == "Send Successful")
                        {
                            updateSMSCredit();
                        }

                    }
                }

            }
            catch
            {
            }
            finally
            {

            }
        }

        public int sendSMSByPage1(string mobile, String Text)
        {
            string baseurl = "http://sms4u.sakshaminfosoft.com/pushsms.php?username=demo&api_password=d7e56x0f6hdfqyw3y&sender=SHOPEE" + "&to=" + mobile.Trim() + "&message=" + Text.Trim() + "&priority=11";
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                sr.BaseStream.WriteTimeout = 9000000;
                string results = sr.ReadToEnd();
                sr.Close();
                // utility.WriteErrorLog(balance + " GetBalance in utility.cs");
                return 0;
            }
            catch (Exception ex)
            {
                //  utility.WriteErrorLog(ex.Message + " GetBalance in utility.cs");
                return 0;
            }
        }


        public int sendSMSByPage(string mobile, String Text)
        {
            string baseurl = "http://sms.webgalaxy.in/SMSAPI.aspx?userid=surendra&password=123456&gsmid=TcmInc&mobile=" + mobile.Trim() + "&smstext=" + Text.Trim();
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                sr.BaseStream.WriteTimeout = 9000000;
                string results = sr.ReadToEnd();
                sr.Close();
                // utility.WriteErrorLog(balance + " GetBalance in utility.cs");
                return 0;
            }
            catch (Exception ex)
            {
                //  utility.WriteErrorLog(ex.Message + " GetBalance in utility.cs");
                return 0;
            }
        }

        public int sendSMSByPage22(string mobile, String Text)
        {
            int ret = 0;
            try
            {
                //http://sms.webgalaxy.in/SMSAPI.aspx?userid=xxxx&password=xxxx&gsmid=xxxx&mobile=999xxxxxx0,999xxxxxx1&smstext=xxxx
                //Dear#VAL#id:#VAL#Your passwordis:#VAL# From:#VAL#Thanks
                Text = Text + " from: " + "www.smartdealshopee.com" + " Thanks";
                //string baseurl = "http://sms.webgalaxy.in/SMSAPI.aspx?userid=surendra&password=123456&gsmid=SHOPEE" + "&mobile=" + mobile.Trim() + "&smstext=" + Text.Trim() + " ";

                string baseurl = "http://sms4u.sakshaminfosoft.com/pushsms.php?username=demo&api_password=d7e56x0f6hdfqyw3y&sender=SHOPEE" + "&to=" + mobile.Trim() + "&message=" + Text.Trim() + "&priority=11";
                // http://sms4u.sakshaminfosoft.com/pushsms.php?username=demo&api_password=d7e56x0f6hdfqyw3y&sender=WEBSMS&to=9910020757&message=sdfsadf&priority=11
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                DebitSMS(1, Text, mobile, s);
                ret = 1;
            }

            catch (Exception ex)
            {
                ret = 0;
            }
            finally
            {
            }
            return ret;
        }





        public string Decrypt(string stringToDecrypt)
        {
            string sEncryptionKey = "~.#)*/!(";
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public string Encrypt(string stringToEncrypt)
        {
            string SEncryptionKey = "~.#)*/!(";
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private void DebitSMS(int noOfSMS, string text, string mobile, string response)
        {
            try
            {
                con = new SqlConnection(method.str);
                com = new SqlCommand("update paymentmst set SMSCredit=SMSCredit-@count where SMSCredit>=@count;" +
                    "insert into SmsMst (Mobile,TextMsg,Response,Doe) values(@mobile,@text,@response,dateadd(minute,330,getutcdate()))", con);
                com.Parameters.AddWithValue("@count", noOfSMS);
                com.Parameters.AddWithValue("@mobile", mobile);
                com.Parameters.AddWithValue("@text", text);
                com.Parameters.AddWithValue("@response", response);
                com.CommandTimeout = 9999999;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
            }
        }

        public static void CheckAdminlogin()
        {

            try
            {
                string admin = HttpContext.Current.Session["admin"].ToString();
                if (Regex.Match(admin, @"^[a-zA-Z0-9]*$").Success)
                {
                    if (HttpContext.Current.Session["admin"] == null)
                    {
                        HttpContext.Current.Response.Redirect("adminLog.aspx");
                    }
                    else
                    {
                        string admid = null;
                        string admpwd = null;
                        admid = HttpContext.Current.Session["admin"].ToString();

                        SqlConnection con = new SqlConnection(method.str);
                        string sqltext = "HavePermissions";
                        SqlCommand cmd = new SqlCommand(sqltext, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@uname", admid);
                        cmd.Parameters.AddWithValue("@pagename", HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Length - 1].Trim());
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {

                        }
                        else
                        {
                            HttpContext.Current.Response.Redirect("adminLog.aspx");
                        }
                    }
                }


                else
                {
                    HttpContext.Current.Response.Redirect("adminLog.aspx");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("adminLog.aspx");
            }
        }


        public void updateSMSCredit()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con = new SqlConnection(method.str);
            SqlCommand com = new SqlCommand("update paymentmst set SMSCredit=SMSCredit-1", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void MessageBox(Control ctl, string ss)
        {
            ss = ss.Replace("'", @"\'");
            ScriptManager.RegisterStartupScript(ctl, ctl.GetType(), "myalert", "javascript:alert('" + ss + "');", true);
        }
        private DataSet GetDataSetForMenu()
        {
            try
            {
                con = new SqlConnection(method.str);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT CatID,CatName  FROM CategoryMst where status=1 and proType=1 order by catid desc");
                adapter.SelectCommand.Connection = con;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Categories");
                adapter.SelectCommand.CommandText = "SELECT SubCatId,SubCatName,CatID FROM SubCategoryMst where status=1";
                adapter.Fill(ds, "subcat");
                adapter.SelectCommand.CommandText = "SELECT Sub2CatId,SubCatId,SubCatName FROM Sub2CategoryMst where status=1";
                adapter.Fill(ds, "sub2cat");
                ds.Relations.Add("Children", ds.Tables["Categories"].Columns["CatID"], ds.Tables["subcat"].Columns["CatID"], false);
                ds.Relations.Add("SubChildren", ds.Tables["subcat"].Columns["SubCatId"], ds.Tables["sub2cat"].Columns["SubCatId"], false);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        private DataSet GetDataSetForDTHMenu()
        {
            try
            {
                con = new SqlConnection(method.str);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT CatID,CatName  FROM CategoryMst where status=1 and proType=2 order by catid desc");
                adapter.SelectCommand.Connection = con;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Categories");
                adapter.SelectCommand.CommandText = "SELECT SubCatId,SubCatName,CatID FROM SubCategoryMst where status=1";
                adapter.Fill(ds, "subcat");
                adapter.SelectCommand.CommandText = "SELECT Sub2CatId,SubCatId,SubCatName FROM Sub2CategoryMst where status=1";
                adapter.Fill(ds, "sub2cat");
                ds.Relations.Add("Children", ds.Tables["Categories"].Columns["CatID"], ds.Tables["subcat"].Columns["CatID"], false);
                ds.Relations.Add("SubChildren", ds.Tables["subcat"].Columns["SubCatId"], ds.Tables["sub2cat"].Columns["SubCatId"], false);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public string leftmenu1()
        {
            string MenuItem = "";
            utility obj = new utility();
            DataSet ds = GetDataSetForMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuItem += "<li><a href='ProductGrid.aspx?subcat=" + parentItem["CatName"].ToString().Replace(' ', '_') + "' class='pram'>" + parentItem["CatName"].ToString().Trim() + "</a></li> ";

                    MenuItem += "</li>";
                }
                MenuItem += "";

            }
            return MenuItem;
        }
        public string DTHmenu()
        {
            string MenuItem = "";
            utility obj = new utility();
            DataSet ds = GetDataSetForDTHMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuItem += "<div class='col_one_quarter'><h3><a href='ProductGrid.aspx?subcat=" + base64Encode(parentItem["CatName"].ToString()) + "'>" + parentItem["CatName"].ToString() + " </a></h3><ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuItem += "<li><a  href='ProductGrid.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'>" + childItem["SubcatName"].ToString() + "</a></li>";

                    }
                    MenuItem += "</ul></div>";
                }
                MenuItem += "";
            }
            return MenuItem;
        }

        public string DTHmenuMobele()
        {
            string MenuItem = "";
            utility obj = new utility();
            DataSet ds = GetDataSetForDTHMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuItem += "<li class='has-sub'><a href='javascript:void'>" + parentItem["CatName"].ToString() + " <span class='holder'></span></a> <ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuItem += "<li><a   href=" + (childItem.GetChildRows("SubChildren").Length > 0 ? "javascript:void" : "'ProductGrid.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'") + ">" + childItem["SubcatName"].ToString().Trim() + "</a></li>";

                    }
                    MenuItem += "</ul></li>";
                }
                MenuItem += "";
            }
            return MenuItem;
        }


        public string leftmenu()
        {
            string MenuleftItem = "";

            DataSet ds = GetDataSetForMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuleftItem += "<div class='col_one_quarter'><h3><a href='ProductGrid.aspx?subcat=" + parentItem["CatName"].ToString() + "'>" + parentItem["CatName"].ToString() + " </a></h3><ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuleftItem += "<li><a  href='ProductGrid.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'>" + childItem["SubcatName"].ToString() + "</a></li>";

                    }
                    MenuleftItem += "</ul></div>";
                }
                MenuleftItem += "";
            }
            return MenuleftItem;
        }


        public string bottommenu()
        {
            string MenuleftItem = "";

            DataSet ds = GetDataSetForMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuleftItem += "<li class='has-sub'><a href='javascript:void'>" + parentItem["CatName"].ToString() + "</a> <ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuleftItem += "<li><a   href=" + (childItem.GetChildRows("SubChildren").Length > 0 ? "javascript:void" : "'ProductGrid.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'") + ">" + childItem["SubcatName"].ToString().Trim() + "</a></li>";

                    }
                    MenuleftItem += "</ul></li>";
                }
                MenuleftItem += "";
            }
            return MenuleftItem;
        }



        public string leftmenu11()
        {
            string MenuleftItem = "";

            DataSet ds = GetDataSetForMenu();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuleftItem += "<li class='dir' ><a  style='color: #fff;' href='ProductGrid.aspx?subcat=" + parentItem["CatName"].ToString() + "'>" + parentItem["CatName"].ToString() + "</a><ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuleftItem += "<li class='dir' ><a class='subbb' href='ProductGrid.aspx?subcat=" + childItem["SubcatId"].ToString() + "'>" + childItem["SubcatName"].ToString() + "</a><ul>";
                        foreach (DataRow sub2childItem in childItem.GetChildRows("SubChildren"))
                        {
                            MenuleftItem += "<li><a href='/delhi/" + sub2childItem["SubcatName"].ToString().Replace(' ', '_') + "'>" + sub2childItem["SubcatName"].ToString().Trim() + "</a></li>";
                        }
                        MenuleftItem += "</ul></li>";
                    }
                    MenuleftItem += "</ul></li>";
                }
                MenuleftItem += "</ul>";
            }
            return MenuleftItem;
        }








        public void GenraterOPt(string STRUserID, ref string flag)
        {

            con.Open();
            com = new SqlCommand("GenerateOPTCode", con);
            com.Parameters.AddWithValue("@AppMstRegNo", STRUserID);
            com.CommandType = CommandType.StoredProcedure;
            sr = com.ExecuteReader();
            if (sr.Read())
            {


                flag = sr["OPTCode"].ToString();

            }
            else
            {
            }

            //con = new SqlConnection(method.str);
            //com = new SqlCommand("GenerateOPTCode", con);
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@AppMstRegNo", STRUserID);
            //com.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar, 100));
            //com.Parameters["@flag"].Direction = ParameterDirection.Output;
            //con.Open();
            //com.ExecuteNonQuery();
            //flag = com.Parameters["@flag"].Value.ToString();



        }



        private DataSet GetDataSetForCoupun()
        {
            try
            {
                con = new SqlConnection(method.str);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT CatID,CatName  FROM CatcupMst where status=1 order by catid desc");
                adapter.SelectCommand.Connection = con;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Categories");
                adapter.SelectCommand.CommandText = "SELECT SubCatId,SubCatName,CatID FROM SubcatCoupon where status=1";
                adapter.Fill(ds, "subcat");
                return ds;
            }
            catch
            {
                return null;
            }
        }


        public string CouponWeb()
        {
            string MenuItem = "";
            utility obj = new utility();
            DataSet ds = GetDataSetForCoupun();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuItem += "<div class='col_one_quarter'><h3><a href='coupons.aspx?subcat=" + base64Encode(parentItem["CatName"].ToString()) + "'>" + parentItem["CatName"].ToString() + " </a></h3><ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuItem += "<li><a  href='coupons.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'>" + childItem["SubcatName"].ToString() + "</a></li>";

                    }
                    MenuItem += "</ul></div>";
                }
                MenuItem += "";
            }
            return MenuItem;
        }


        public string couponMobele()
        {
            string MenuItem = "";
            utility obj = new utility();
            DataSet ds = GetDataSetForCoupun();
            if (ds != null && ds.Tables["Categories"] != null)
            {
                foreach (DataRow parentItem in ds.Tables["Categories"].Rows)
                {
                    MenuItem += "<li class='has-sub'><a href='javascript:void'>" + parentItem["CatName"].ToString() + " <span class='holder'></span></a> <ul>";
                    foreach (DataRow childItem in parentItem.GetChildRows("Children"))
                    {
                        MenuItem += "<li><a   href=" + (childItem.GetChildRows("SubChildren").Length > 0 ? "javascript:void" : "'coupons.aspx?subcat=" + base64Encode(childItem["SubcatName"].ToString()) + "'") + ">" + childItem["SubcatName"].ToString().Trim() + "</a></li>";

                    }
                    MenuItem += "</ul></li>";
                }
                MenuItem += "";
            }
            return MenuItem;
        }

        public DataTable companyname()
        {
            con = new SqlConnection(method.str);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("companydetails");
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Connection = con;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}