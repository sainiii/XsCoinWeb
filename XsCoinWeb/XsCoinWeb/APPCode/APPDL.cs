using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public class APPDL
    {
        string SQL;
        SqlConnection Conn = new SqlConnection(method.str);
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable dtC = new DataTable();
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable("DTabel");



        public DataTable Fn_TreeFistLavel(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "sp_tree1FirstApp";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }

        public DataTable Fn_TreeSecondLavel(string USERID, int PType)
        {
            DataTable RDT = new DataTable();
            SQL = "sp_tree1App";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@AppMstRegNo", USERID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@Postion", PType);
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }

        public DataTable Fn_UserDetail(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "Incomehistoryvpdraw";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@AppMstRegNo", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }

        public DataTable Fn_UserInformation(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "getUseriNFORMATION";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }

        public DataTable Fn_GetExchangeRate()
        {
            DataTable dt = new DataTable();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "geteipIPKPWalletInfo";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
        
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
        public DataTable Fn_UserInformationFull(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_getUserMaster";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }

        public DataTable Fn_referral(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "sponsarlist";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }

        public DataTable Fn_downlinedetail(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_DownlineReport";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }









        public DataTable Fn_referralincome(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_IncomeReport";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@isType", "Direct Income");
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }

        public DataTable Fn_ROIincome(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_IncomeReport";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@isType", "ROI");
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;
        }



        public DataTable Fn_transferreport(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_FundTrasferlist";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }



        public DataTable Fn_withdrawhistory(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_WithDrawlist";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }


        public DataTable Fn_upgradereport(string USERID)
        {
            DataTable RDT = new DataTable();
            SQL = "PRC_UpgradeAccountlist";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@regno", USERID.Trim().Replace("'", ""));
            Com.CommandText = SQL;
            Com.CommandType = CommandType.StoredProcedure;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(RDT);
            return RDT;

        }



        public void WithDraw(string UserID, string Amount, string BTCAMount, string txtbtc, string SKey, out string OutMsg)
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
            OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            Com.Parameters.Clear();
        }



        public void FN_Fundtrasfer(string UserID, string PregNo, string Amt, string SKey, out string OutMsg)
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
                OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
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
    }
}