using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public class UserClass
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
        public UserClass()
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

        public DataTable FN_ServerTime()
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_ServerTime";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();

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

        public void Rechargeuser(string RegID, string Amt, string UserID, string Key)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeUser";
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






        public void RechargeuserBTC(string RegID, string Amt, string UserID, string modeType, string ConverAmt, string Key, string Address, string Type)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "RechargeUserBTC";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@SessionRegNo", UserID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@AmountType", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@modeType", modeType.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@ConverAmt", ConverAmt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@BTCAddress", Address.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SKey", Key.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RType", Type.Trim().Replace("'", ""));
            Com.Parameters.Add("@PayMentID", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutID = Convert.ToString(Com.Parameters["@PayMentID"].Value);
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
            Com.Parameters.AddWithValue("@SKey", SKey.Trim().Replace("'", ""));
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

        public void FN_Fundtrasfer(string UserID, string PregNo, string Amt, string SKey)
        {
            {
                if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
                SQL = "FundTransferVP";
                Com.Connection = Conn;
                Com.CommandType = CommandType.StoredProcedure;
                Com.Parameters.Clear();
                Com.Parameters.AddWithValue("@TrasferRegNo", PregNo.Trim().Replace("'", ""));
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


        public DataTable Fn_CreateOTP(string USERID, string Types   )
        {
            string s = USERID.ToString();

            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "GenerateOPTCodeNew";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@AppMstRegNo", USERID.Trim());
            Com.Parameters.AddWithValue("@Type", Types.Trim());
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

              
        }


        public DataTable FN_CreateOTPRegistraion(string USERID, string Types)
        {
            string s = USERID.ToString();

            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "CreateOTPRegistraion";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@email", USERID.Trim());
            Com.Parameters.AddWithValue("@Type", Types.Trim());
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;


        }

        
        public DataTable Fn_Package(string USERID)
        { 
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_packages";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@AppMstRegNo", USERID.Trim());
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;


        }

        public DataTable Fn_PackageDetial(string USERID)
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "select * from PlanTypeMst where srno="+ USERID;
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;


        }

    }
}