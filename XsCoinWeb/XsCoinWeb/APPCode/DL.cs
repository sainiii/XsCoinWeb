using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public class DL
    {
        string SQL;
        SqlConnection Conn = new SqlConnection(method.str);
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable dtC = new DataTable();
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable("DTabel");


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

    }
}