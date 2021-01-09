using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for InsertFunction
/// </summary>
namespace XsCoinWeb
{
    public class InsertFunction
    {
        public SqlDataReader dr;
        //private static string conStr = ConfigurationManager.ConnectionStrings["con1"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(method.str);
        public string SID, Uname, PID, REGNO;
        public int check, LeftRight, appmst;
        public InsertFunction()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string Sponserid
        {
            set { SID = value; }
            get { return SID; }
        }
        public string UserName
        {
            set { Uname = value; }
            get { return Uname; }
        }
        public int CheckFlag
        {
            set { check = value; }
            get { return check; }
        }
        public int LeftOrRight
        {
            set { LeftRight = value; }
            get { return LeftRight; }
        }
        public int AppMstIdData
        {
            set { appmst = value; }
            get { return appmst; }
        }
        public string ParrentId
        {
            set { PID = value; }
            get { return PID; }
        }
        public string RegistrationNo
        {
            set { REGNO = value; }
            get { return REGNO; }
        }
        public void SponserCheck()
        {
            con.Close();
            SqlCommand com = new SqlCommand("CheckSidAndUname", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SID", SID);
            com.Parameters.AddWithValue("@uname", Uname);
            com.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
            com.Parameters["@flag"].Direction = ParameterDirection.Output;
            com.CommandTimeout = 9999999;
            con.Open();
            dr = com.ExecuteReader();
            check = Convert.ToInt32(com.Parameters["@flag"].Value);
        }
        public void FindMax()
        {
            con.Close();
            SqlCommand com = new SqlCommand("FindMaxId", con);
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            dr = com.ExecuteReader();
        }
        //public void UpdateParentId()
        //{
        //    con.Close();
        //    SqlCommand com = new SqlCommand("UpdateParrentId", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@PID", PID);
        //    com.Parameters.AddWithValue("@LeftRight",LeftRight);
        //    com.Parameters.AddWithValue("@appmstregno",REGNO);
        //    con.Open();
        //    com.ExecuteNonQuery();
        //}
        public void UpdateIncreaseSponser()
        {
            SqlCommand com = new SqlCommand("IncreaseSponsor", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", SID);
            con.Open();
            com.ExecuteNonQuery();
        }
        public void UpdateLeftRight()
        {
            SqlConnection con = new SqlConnection(method.str);
            SqlCommand com = new SqlCommand("UpdateLeftRight", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@downid", REGNO);
            con.Open();
            com.ExecuteNonQuery();
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
        public static void Checklogin()
        {
            try
            {
                string regno = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();
                if (Regex.Match(regno, @"^[a-zA-Z0-9]*$").Success)
                {

                    {
                        if (HttpContext.Current.Request.Cookies["userId"].Value == null)
                        {
                            HttpContext.Current.Response.Redirect("loginagain.aspx");
                        }
                        else
                        {
                            string userid = HttpContext.Current.Request.Cookies["userId"].Value.ToString();
                            SqlConnection con = new SqlConnection(method.str);
                            string sqltext = "SessionuserExsist";
                            SqlCommand cmd = new SqlCommand(sqltext, con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@regno", userid);
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                            }
                            else
                            {
                                HttpContext.Current.Response.Redirect("loginagain.aspx");
                            }
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("loginagain.aspx");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("loginagain.aspx");
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
        public static string CheckAdminloginInside()
        {
            string admintype = "";

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
                        string sqltext = "select admintype from controlmst where username=@uname";
                        SqlCommand cmd = new SqlCommand(sqltext, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@uname", admid);
                        con.Open();
                        admintype = cmd.ExecuteScalar().ToString();
                        con.Close();
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
            return admintype;
        }

    }
}