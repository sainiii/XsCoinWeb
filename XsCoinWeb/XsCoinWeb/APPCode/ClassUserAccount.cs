using XsCoinWeb.shapes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public class ClassUserAccount
    {
        string SQL;
        SqlConnection Conn = new SqlConnection(method.str);
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable dtC = new DataTable();
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable("DTabel");


        public DataTable FN_LoginUserWeb(string USERID, string PassWord)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_UserLoginWeb";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@userid", USERID);
            Com.Parameters.AddWithValue("@pwd", PassWord);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }



        public DataTable FN_ForgetPassword(string USERID)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "chkregpassword";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@userid", USERID);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }



        public bool ValidateToken(string tokenId)
        {
            string status = "";
            SqlConnection con = new SqlConnection(method.str);
            SqlCommand com = new SqlCommand("PRC_ValidateToken", con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 99999999;
            com.Parameters.AddWithValue("@tokenId", tokenId.Trim());
            com.Parameters.Add("@flag", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            con.Open();
            com.CommandTimeout = 999999;
            com.ExecuteNonQuery();
            status = com.Parameters["@flag"].Value.ToString();
            if (status == "1")
            {
                return true;
            }
             
            return false;
        }

      

        public string FN_Register(RegisterShape LoginUser, string IPAddress, out string RegNO)
        {
            string status = "";
            string AppMstRegNo = "";
            SqlConnection con = new SqlConnection(method.str);
            SqlCommand com = new SqlCommand("Insertdata5", con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 99999999;
            com.Parameters.AddWithValue("@SessionID", LoginUser.SponsorId.Trim());
            com.Parameters.AddWithValue("@sponserID", LoginUser.SponsorId.Trim());
            com.Parameters.AddWithValue("@AppMstFName", LoginUser.Name.Trim());
            com.Parameters.AddWithValue("@mobile","NA");
            com.Parameters.AddWithValue("@emailid", LoginUser.Email.Trim());
            com.Parameters.AddWithValue("@AppMstleftright", LoginUser.Position.Trim());
            com.Parameters.AddWithValue("@BTCAddres", "NA");
            com.Parameters.AddWithValue("@country", LoginUser.country.Trim());
            com.Parameters.AddWithValue("@Pwd", LoginUser.Password.Trim());
            com.Parameters.AddWithValue("@IPAddress", IPAddress);
            com.Parameters.AddWithValue("@Key", LoginUser.Password.Trim());
            com.Parameters.AddWithValue("@OTP", LoginUser.OTP.Trim());
            com.Parameters.Add("@regDisplay", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            com.Parameters.Add("@flag", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            com.Parameters.Add("@flagpwd", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                com.CommandTimeout = 999999;
                com.ExecuteNonQuery();
                RegNO = com.Parameters["@regDisplay"].Value.ToString();
                string flagpwd = com.Parameters["@flagpwd"].Value.ToString();
                status = com.Parameters["@flag"].Value.ToString();
                if (status == "1")
                {
                    AppMstRegNo = status;
                    ClassEmail OBJ = new ClassEmail();
                    string EmailText = OBJ.GetTemplate("successful.htm");
                    EmailText = EmailText.Replace("XXNameXX", LoginUser.Name.Trim().ToUpper()).Replace("XXusernameXX", RegNO).Replace("XXpasswordXX", flagpwd);
                    try { OBJ.sendMail(LoginUser.Email.Trim(), "Welcome To XS COIN", EmailText); } catch { }
                   
                }

                else
                {

                    AppMstRegNo = status;


                }

            }
            catch (Exception ex)
            {
                RegNO = "";
                AppMstRegNo = status;
            }

            return AppMstRegNo;

        }



        public string FN_UpdateProfile(UpdateShape LoginUser)
        {
            string status = "";
            string AppMstRegNo = "";
            SqlConnection con = new SqlConnection(method.str);
            SqlCommand com = new SqlCommand("UpdateProfileAPP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 99999999;
            com.Parameters.AddWithValue("@regno", LoginUser.Regno);
            com.Parameters.AddWithValue("@Btc", LoginUser.BTC.Trim());
            com.Parameters.AddWithValue("@Country", LoginUser.Country.Trim());
            com.Parameters.AddWithValue("@mobileno","NA");
            com.Parameters.AddWithValue("@emailid", LoginUser.Email.Trim());
            com.Parameters.AddWithValue("@FName", LoginUser.AppmstFName.Trim());
            
            com.Parameters.Add("@flag", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                com.CommandTimeout = 999999;
                com.ExecuteNonQuery();


                status = com.Parameters["@flag"].Value.ToString();
                if (status == "1")
                {
                    AppMstRegNo = "Update Profile";
                }

                else
                {

                    AppMstRegNo = status;


                }

            }
            catch (Exception ex)
            {
                AppMstRegNo = status;
            }

            return AppMstRegNo;

        }
    }
}