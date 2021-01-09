using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{

    public class UserAppClass
    {


        private string _OutMsg;
        public string OutMsg
        {
            get
            {
                return _OutMsg;
            }
            set
            {
                _OutMsg = value;
            }
        }
        private string _OutID;
        public string OutID
        {
            get
            {
                return _OutID;
            }
            set
            {
                _OutID = value;
            }
        }
        string SQL;
        SqlConnection Conn = new SqlConnection();
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable dtC = new DataTable();
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable("DTabel");
        public UserAppClass()
        {
            Conn.ConnectionString = method.str;
        }
        public DataTable Fn_UserBlance(string USERID)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "geteipIPKPWalletInfo";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }



        public DataTable BTCAdminAddress(string USERID)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_BTCAddreAddress";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@Type", USERID);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }


        public DataTable Fn_UserVPBlance(string USERID)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "geteipIPKPWalletInfo";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }

        public void ActivateUser(string RegID, string Amt, string OTP, string Amountrate, string ConverAmt)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeUser";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@OTP", OTP.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@Amountcv", ConverAmt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@Amountrate", Amountrate.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);

            Com.Parameters.Clear();
        }



        public void UpgradeUser(string Amountcv, string UserID,  string Amt, string OTP, string Amountrate)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "UPGRADEUSER";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@SessionRegNo", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@OTP", OTP.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@Amountcv", Amountcv.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@Amountrate", Amountrate.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.CommandText = SQL;
                 Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
                  Com.Parameters.Clear();
        }

        public void AccountTopUP(string RegID, string Amt, string UserID, string Key)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeUserActivate";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@SessionRegNo", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SKey", Key.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.Parameters.Add("@bal", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            _OutID = Convert.ToString(Com.Parameters["@bal"].Value);
            Com.Parameters.Clear();
        }






        public void RechargeuserBTC(string RegID, string Amt, string UserID, string Key)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeCheckValidation";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@SessionRegNo", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SKey", Key.Trim().Replace("'", ""));
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();

            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            Com.Parameters.Clear();
        }



        public void RechargeCheckUpgradeValidation(string RegID, string Amt, string UserID, string Key)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeCheckUpgradeValidation";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@SessionRegNo", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SKey", Key.Trim().Replace("'", ""));
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            Com.Parameters.Clear();
        }


        public void WithDraw(string UserID, string Amount, string BTCAMount, string txtbtc, string SKey)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "crowdfundtransferUser";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@appmstregno", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@amt", Amount.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@BTCAmt", BTCAMount.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@BTCAddress", txtbtc.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@OTP", SKey.Trim().Replace("'", ""));
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            Com.Parameters.Clear();
        }

        public void Fn_UpdateFileName(string FileNameSave, string PassID)
        {

            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_UpdatePaymentRecepitFile";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@ID", PassID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@FileName", FileNameSave.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.Parameters.Add("@OutMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.Parameters.Add("@OutID", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@OutMsg"].Value);
            _OutID = Convert.ToString(Com.Parameters["@OutID"].Value);
            Com.Parameters.Clear();
        }
        public void Fn_UpdateProilePic(string FileNameSave, string PassID)
        {

            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_UpdateProfilePic";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@Regno", PassID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@FileName", FileNameSave.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.Parameters.Add("@OutMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.Parameters.Add("@OutID", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@OutMsg"].Value);
            _OutID = Convert.ToString(Com.Parameters["@OutID"].Value);
            Com.Parameters.Clear();
        }
        public void FN_Fundtrasfer(string UserID, string TrsferID, string Amt, string SKey)
        {
            {
                if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
                SQL = "FundTransferVP";
                Com.Connection = Conn;
                Com.CommandType = CommandType.StoredProcedure;
                Com.Parameters.Clear();
                Com.Parameters.AddWithValue("@TrasferRegNo", TrsferID.Trim().Replace("'", ""));
                Com.Parameters.AddWithValue("@PregNo", UserID.Trim().Replace("'", ""));
                Com.Parameters.AddWithValue("@Amt", Amt.Trim().Replace("'", ""));
                Com.Parameters.AddWithValue("@SKey", SKey.Trim().Replace("'", ""));
                Com.Parameters.Add("@Abalance", SqlDbType.Float).Direction = ParameterDirection.Output;
                Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                Com.CommandText = SQL;
                Com.ExecuteNonQuery();
                _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
                Com.Parameters.Clear();
            }
        }

        public string Fn_GetBTCAddress(string USERID)
        {
            string s = USERID.ToString();
            SqlConnection con = new SqlConnection(method.str);
            if (!string.IsNullOrEmpty(USERID))
            {
                SqlCommand com = new SqlCommand();
                SqlDataReader dr;
                com.CommandText = "Select AcountNo from appmst where appmstregno=@regno";
                com.Parameters.AddWithValue("@regno", USERID.Trim());
                com.Connection = con;
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    s = Convert.ToString(dr["AcountNo"]);

                }
                else
                {
                    s = "NOT EXIST !";

                }
                dr.Close();
                con.Close();

            }
            return s;
        }


        public string Fn_UserName(string USERID)
        {
            string s = USERID.ToString();
            SqlConnection con = new SqlConnection(method.str);
            if (!string.IsNullOrEmpty(USERID))
            {

                SqlCommand com = new SqlCommand();
                SqlDataReader dr;
                com.CommandText = "select (appmsttitle+space(1)+appmstfname)as name from appmst  where appmstregno=@regno ";
                com.Parameters.AddWithValue("@regno", USERID.Trim());
                com.Connection = con;
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    s = Convert.ToString(dr["name"]);
                    // Session["sname"] = Convert.ToString(dr["name"]);


                }
                else
                {
                    s = "NOT EXIST !";

                }
                dr.Close();
                con.Close();

            }
            return s;
        }



        public DataTable Fn_CoinPayMentTxn(string TxNID, string UserId)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_Transaction_Detial";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@txID", TxNID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@UserId", UserId.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }


        public DataTable activeandUpgradeHistory(string UserId)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_activeandUpgradeHistory";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@userid", UserId.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }
    }
}