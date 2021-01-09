





using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using System.IO;
 

/// <summary>
/// Summary description for ClassCompnyMaster
/// </summary>
namespace XsCoinWeb
{
    public class ClassUserMaster
    {
        string SQL;
        SqlConnection Conn = new SqlConnection(method.str);
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable dtC = new DataTable();
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable("DTabel");

        private string _IsActive;
        public string IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        private string _SLNO;
        public string SLNO
        {
            get
            {
                return _SLNO;
            }
            set
            {
                _SLNO = value;
            }
        }

        private DateTime _LastDt;
        public DateTime LastDt
        {
            get
            {
                return _LastDt;
            }
            set
            {
                _LastDt = value;
            }
        }

        private string _UMobile;
        public string UMobile
        {
            get
            {
                return _UMobile;
            }
            set
            {
                _UMobile = value;
            }
        }

        private string _PageLink;
        public string PageLink
        {
            get
            {
                return _PageLink;
            }
            set
            {
                _PageLink = value;
            }
        }



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
        SqlConnection con = new SqlConnection(method.str);
        SqlCommand com;

        DataTable dt = new DataTable();
     

   

        public int AddFundRequest(string amt, string userIDs,string userID, string StStatu)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("PRC_AddFunBitConrequest", con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 99999999;
            com.Parameters.AddWithValue("@amt",  amt);
            com.Parameters.AddWithValue("@userIDs", userIDs);
            com.Parameters.AddWithValue("@userID", userID);
            com.Parameters.AddWithValue("@St", StStatu);
            com.Parameters.Add("@OutMsg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            com.Parameters.Add("@OutStatus", SqlDbType.Int).Direction = ParameterDirection.Output;
            con.Open();
            com.CommandTimeout = 999999;
            com.ExecuteNonQuery();
            OutMsg = com.Parameters["@OutMsg"].Value.ToString();
            int status = Convert.ToInt32(com.Parameters["@OutStatus"].Value);
            return status;

        }
        public ClassUserMaster()
        {
            Conn.ConnectionString = method.str;
        }


        public void Fn_SaveRecord()
        {

            //if (Conn.State == ConnectionState.Closed) { Conn.Open(); }

            //SQL = "PRC_PageMasterAddUpdate";
            //Com.Connection = Conn;
            //Com.CommandType = CommandType.StoredProcedure;
            //Com.Parameters.Clear();
            //Com.Parameters.AddWithValue("@PageID", _SLNO);
            //Com.Parameters.AddWithValue("@PageName", _UMobile.Trim().Replace("'", ""));
            //Com.Parameters.AddWithValue("@PageLink ", _PageLink.Trim().Replace("'", ""));
            //Com.Parameters.AddWithValue("@IsActive", _IsActive.Trim().Replace("'", ""));
            //Com.Parameters.Add("@OutMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //Com.CommandText = SQL;
            //Com.ExecuteNonQuery();
            //_OutMsg = Convert.ToString(Com.Parameters["@OutMsg"].Value);
            //Com.Parameters.Clear();
            //Com.Dispose();
            //Conn.Close();
        }
        public void Fn_DataView()
        {
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            SQL = " Select * from Appmst WHERE AppMstRegno=@AppMstRegno; ";

            Com.Connection = Conn;

            Com.CommandText = SQL;
            Com.Parameters.Clear();
            Com.Parameters.AddWithValue("@AppMstRegno", _SLNO.Trim().Replace("'", ""));
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(dtC);
            if (dtC.Rows.Count > 0)
            {

                _UMobile = dtC.Rows[0]["AppMstMobile"].ToString();
                //_PageLink = dtC.Rows[0]["PageLink"].ToString();

                //_IsActive = dtC.Rows[0]["IsActive"].ToString();

                //_LastDt = Convert.ToDateTime(dtC.Rows[0]["LastDate"].ToString());
            }
            Com.Dispose();
            DataAdapter.Dispose();
            Com.Parameters.Clear();
            dtC.Clear();
            Conn.Close();

        }

        //public DataView NW_ShiftMasterDataView(string StrFind, string Status)
        //{
        //    //DataView DVMG = new DataView();
        //    //DataSet dsMG = new DataSet();
        //    //if (Conn.State == ConnectionState.Closed) { Conn.Open(); }

        //    //SQL = " Select PageID, pageName, PageLink,     IsActive,LastDate   from PromtionMaster  WHERE pageName like '%' + @find + '%'  and  IsActive=@Stuts ";
        //    //Com.Connection = Conn;
        //    //Com.Parameters.Clear();


        //    //Com.Parameters.AddWithValue("@Stuts", Status.Trim().Replace("'", ""));
        //    //Com.Parameters.AddWithValue("@find", StrFind.Trim().Replace("'", ""));
        //    //Com.CommandText = SQL;
        //    //DataAdapter.SelectCommand = Com;
        //    //DataAdapter.Fill(dsMG);
        //    //DVMG.Table = dsMG.Tables[0];
        //    //Com.Dispose();
        //    //DataAdapter.Dispose();
        //    //Conn.Close();
        //    //return DVMG;
        //}

        public DataView DV_UserList()
        {
            SQL = "Select  0 as ID, 'Select' as Nm, 'A' as ST       Union Select  AppMstID as ID,  AppMstRegNo as Nm,  'B' as ST   from AppMst           Order By ST, Nm  ";
            //   SQL = "Select 0 as AppMstID, ' Select' as AppMstRegNo Union Select AppMstID, AppMstRegNo from AppMst Where IsActive='Y' order By AppMstID";
            DataView DVMG = new DataView();
            DataSet dsMG = new DataSet();
            if (Conn.State == ConnectionState.Closed) { Conn.Open(); }
            Com.Connection = Conn;
            Com.Parameters.Clear();
            Com.CommandText = SQL;
            DataAdapter.SelectCommand = Com;
            DataAdapter.Fill(dsMG);
            DVMG.Table = dsMG.Tables[0];
            Com.Dispose();
            DataAdapter.Dispose();
            Conn.Close();
            return DVMG;
        }
    }

}