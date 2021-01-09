using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace XsCoinWeb.APPCode
{
    public class GiftCardDB
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
        public GiftCardDB()
        {
            Conn.ConnectionString = method.str;
        }

        public DataSet Fn_GetGiftCardList(string Country, string CurrencyCode)
        {
            DataSet dt = new DataSet();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_GetGiftCardList";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@Country", Country);
            Com.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }


        public DataSet GetCountryList()
        {
            DataSet dt = new DataSet();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "select distinct Country from GiftCardMst";
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }
        public DataSet OrderGiftCardUserList(string UserID)
        {
            DataSet dt = new DataSet();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_GiftOrderbyUserList";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@UserID", UserID);

            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }


        public void GetGiftCardCode(string UserID, string Skey, string OrderID)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_GetGiftCardCode";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@UserID", UserID);
            Com.Parameters.AddWithValue("@OrderID", OrderID);
            Com.Parameters.AddWithValue("@Skey", Skey);
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.Parameters.Add("@Code", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            _OutID = Convert.ToString(Com.Parameters["@Code"].Value);
            Com.Parameters.Clear();
        }




        public DataSet Fn_GetGiftCardDetialbyID(string GiftCardId)
        {
            DataSet dt = new DataSet();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_GetGiftCardByID";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@GiftCardId", GiftCardId);
            Com.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            return dt;

        }



        public void GiftOrderbyUser(string RegID, string Amt, string SentID, string RequestAmount, string GiftCardId, string SKey)
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = "PRC_GiftOrderbyUser";
            Com.Connection = Conn;
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@RegNo", RegID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@giftCardAmount", Amt.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SendID", SentID.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@RequestAmount", RequestAmount.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@GiftCardId", GiftCardId.Trim().Replace("'", ""));
            Com.Parameters.AddWithValue("@SKey", SKey.Trim().Replace("'", ""));
            Com.Parameters.Add("@flag", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            Com.CommandText = SQL;
            Com.ExecuteNonQuery();
            _OutMsg = Convert.ToString(Com.Parameters["@flag"].Value);
            Com.Parameters.Clear();
        }
    }




}


