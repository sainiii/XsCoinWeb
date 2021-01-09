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
namespace XsCoinWeb
{
    public class ClassEmail
    {

        SqlConnection con = new SqlConnection(method.str);
        SqlCommand com;
        SqlDataAdapter da;
        public void sendInvoiceMail(string to, string subject, string msg)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            WebClient client = new WebClient();
            string companyname = "", gMailAccount = "", password = "";
            con = new SqlConnection(method.str);
            SqlCommand cmd = new SqlCommand("selectGmailAccountInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        companyname = rdr["companyname"].ToString().Trim();
                        gMailAccount = rdr["gmailAccount"].ToString().Trim();
                        password = rdr["gmailPassword"].ToString().Trim();
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


                MailMessage MsgObj = new MailMessage();

                //set the addresses
                MsgObj.From = new MailAddress("info@smartdealshopee.com");
                MsgObj.To.Add(to);
                MsgObj.Bcc.Add("smartdealshopee@gmail.com");
                //set the content
                MsgObj.Subject = "Welcome to SmartdealShopee";
                MsgObj.Body = msg;
                MsgObj.IsBodyHtml = true;

                //send the message
                SmtpClient smtp = new SmtpClient("207.174.214.79");
                smtp.Credentials = new System.Net.NetworkCredential(gMailAccount, password);
                smtp.Send(MsgObj);





                //NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
                //MailMessage mm = new MailMessage();
                //mm.From = new MailAddress(gMailAccount, "Welcome to Smartdealshopee ");
                //mm.To.Add(new MailAddress(to));
                //mm.Bcc.Add("smartdealshopee@gmail.com");

                //mm.SubjectEncoding = System.Text.Encoding.UTF8;
                //mm.Subject = "Welcome to Smartdealshopee";
                //mm.BodyEncoding = System.Text.Encoding.UTF8;
                //mm.IsBodyHtml = true;
                //System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(msg, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                //System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(msg, null, "text/html");
                //mm.AlternateViews.Add(plainView);
                //mm.AlternateViews.Add(htmlView);
                //mm.Body = msg;
                //mm.Priority = MailPriority.Normal;

                //SmtpClient emailClient = new SmtpClient("207.174.214.79");
                //emailClient.Port = 587;
                //emailClient.EnableSsl = false;
                //emailClient.UseDefaultCredentials = false;
                //emailClient.Credentials = loginInfo;
                //emailClient.Send(mm);



            }
            catch (Exception e)
            {
            }
            finally
            {
            }
        }






        public string GetTemplate(string URL)
        {
            string MailBody = "";
            try
            {
                string StrURL = "https://xscoin.io/emails/" + URL;
                WebRequest request = WebRequest.Create(StrURL);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(data))
                {
                    MailBody = sr.ReadToEnd();
                }
                return MailBody;
            }
            catch
            {
                return MailBody;
            }

        }


        public Int64 SMSCOUnt()
        {
            Int64 smsCount = 0;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con = new SqlConnection(method.str);
            SqlCommand cmd = new SqlCommand("select SMSCredit from paymentMst ", con);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        smsCount = Convert.ToInt64(rdr["SMSCredit"].ToString().Trim());
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
            return smsCount;
        }
        public void SendSMSPage(string mobile, string Text)
        {
            Int64 SMSCT = SMSCOUnt();

            if (SMSCT > 0)
            {
                string baseurl = "http://sms.gawivo.com/api/sendsms.php?user=APLGRO&apikey=2Rztt1SfNbx2Kv1AUE6V&mobile=" + mobile.Trim() + "&message=" + Text.Trim() + "&senderid=APLGRO&type=txt";
                //string baseurl = "http://alerts.jkmjbm.com:8080/sendsms/bulksms?username=jain-berich&password=berich&type=0&dlr=1&destination=" + mobile.Trim() + "&source=GlobAM&message=" + Text.Trim();
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(baseurl);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    sr.BaseStream.WriteTimeout = 9000000;
                    string results = sr.ReadToEnd();
                    sr.Close();
                    DebitSMS(1, Text, mobile, results);
                }
                catch (Exception ex)
                {

                }

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
        public void sendMail(string to, string subject, string msg)
        {
            try
            {

                string stramdinemail = string.Empty;
                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(to);
                mailMessage.From = new MailAddress("noreply@xscoin.io", subject);
                mailMessage.Subject = subject;
                mailMessage.Body = msg;
                SmtpClient smtpClient = new SmtpClient("mail.privateemail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("noreply@xscoin.io", "Xscoin@12345");
                smtpClient.Send(mailMessage);
            }


            catch (Exception e)
            {
            }
            finally
            {
            }
        }

    }
}