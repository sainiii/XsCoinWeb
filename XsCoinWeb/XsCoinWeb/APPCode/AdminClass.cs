using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace XsCoinWeb
{
    public class AdminClass
    {
        SqlConnection con = null;
        SqlCommand com = null;
        DataTable dt = null;
        SqlDataAdapter adapter = null;
        public static int adminIdForBankTran = -111;
        utility objUtil = null;
        SqlDataReader Reader = null;
        public Boolean IsvalidAdminExdPwd(string userid, string epassword)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select username from ControlMst  where username=@RegNo and ePassword=@ExPwd and  len(@ExPwd)>2 ", con);
            //com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regNo", userid);
            com.Parameters.AddWithValue("@ExPwd", epassword);
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close(); con.Dispose();
                    return true;
                }
                else
                {
                    con.Close(); con.Dispose();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public Boolean IsvalidFranchiseExdPwd(string userid, string epassword)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select FranchiseCode from franchisemst  where FranchiseCode=@RegNo and ePwd=@ExPwd and  len(@ExPwd)>2 ", con);
            //com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regNo", userid);
            com.Parameters.AddWithValue("@ExPwd", epassword);
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close(); con.Dispose();
                    return true;
                }
                else
                {
                    con.Close(); con.Dispose();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;

            }
        }



        public Boolean IsvalidExdPwd(string userid, string epassword)
        {
            if (userid.Length > 1)
            {
                con = new SqlConnection(method.str);
                com = new SqlCommand("IsValidExPwd", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@regNo", userid);
                com.Parameters.AddWithValue("@ExPwd", epassword);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        con.Close(); con.Dispose();
                        return true;
                    }
                    else
                    {
                        con.Close(); con.Dispose();
                        return false;
                    }

                }
                catch
                {
                    return false;

                }
            }
            else
                return false;

        }

        public Boolean IsUserUnderFranchise(string userid, string franchiseid)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select appmstid from appmst inner join franchiseMst on appmst.franchiseid=franchisemst.franchiseid where franchisemst.franchiseCode=@fcode and appmst.appmstregno=@regno", con);
            com.Parameters.AddWithValue("@fcode", franchiseid);
            com.Parameters.AddWithValue("@RegNo", userid);
            com.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                con.Close();
                con.Dispose();
                return false;
            }
        }

        public double GetAdminBalance()
        {
            double balance = 0;
            con = new SqlConnection(method.str);
            com = new SqlCommand("declare @text varchar(5000) " +
            "set @text='select ['+USER_NAME()+'].getBalance('+convert(varchar,@adminId)+')'" +
            " exec(@text)", con);
            com.Parameters.AddWithValue("@adminId", adminIdForBankTran);
            com.CommandType = CommandType.Text;
            try
            {
                con.Open();
                balance = Convert.ToDouble(com.ExecuteScalar());
            }
            catch (Exception ex)
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
                balance = 0;
            }
            return balance;
        }
        public Boolean IsUserExists(string userid)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select appmstid from appmst where appmstactivate=1 and appmstregno=@regno", con);
            com.Parameters.AddWithValue("@RegNo", userid);
            com.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                con.Close();
                con.Dispose();
                return false;
            }
        }
        public Boolean IsRetailerExists(string userid)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select Retailerid from RetailerMst where active=1 and username=@regno", con);
            com.Parameters.AddWithValue("@RegNo", userid);
            com.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                con.Close();
                con.Dispose();
                return false;
            }
        }
        public Boolean IsFranchiseExists(string userid)
        {
            con = new SqlConnection(method.str);
            com = new SqlCommand("select franchiseid from franchisemst where isActive=1 and franchisecode=@fcode", con);
            com.Parameters.AddWithValue("@fcode", userid);
            com.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                con.Close();
                con.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Used to get the current Wallet balance of top up and payout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetWalletBalance(string id)
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("declare @schema varchar(50) " +
                    "set @schema=SCHEMA_NAME()" +
                    "execute('select ['+@schema +'].getbalance((select appmstid from appmst where appmstregno='''+@regno+'''))')", con);
                com.Parameters.AddWithValue("@regno", id);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetWalletBalance in AdminClass.cs");
                return 0;
            }
        }

        /// <summary>
        /// Used to get the current load balance of mob recharge
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetLoadBalance(string id)
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("declare @schema varchar(50) " +
                    "set @schema=SCHEMA_NAME()" +
                    "execute('select ['+@schema +'].getLoadbalance((select appmstid from appmst where appmstregno='''+@regno+'''))')", con);
                com.Parameters.AddWithValue("@regno", id);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetBalance in GetRechargeLoad.cs");
                return 0;
            }
        }

        /// <summary>
        /// Used to get the current load balance of mob recharge
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetRetailerLoadBalance(string id)
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("declare @schema varchar(50) " +
                    "set @schema=SCHEMA_NAME()" +
                    "execute('select ['+@schema +'].getRetailerLoadbalance((select RetailerId from RetailerMst where username='''+@regno+'''))')", con);
                com.Parameters.AddWithValue("@regno", id);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetRetailerLoadBalance in AdminClass.cs");
                return 0;
            }
        }


        /// <summary>
        /// Used to get the current Payout load balance of mob recharge
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetPayLoadBalance(string id)
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("getPayLoadbalanceProc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@regno", id);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetPayLoadBalance in AdminClass.cs");
                return 0;
            }
        }

        /// <summary>
        /// Used to get per bill charge for the pay
        /// </summary>
        /// <returns></returns>
        /// 

        public double GetPayWalletBalance(string id)
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("getPayWalletProc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@regno", id);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetPayLoadBalance in AdminClass.cs");
                return 0;
            }
        }
        public double GetBillPayCharge()
        {
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("select PayCharge from PaymentMst", con);
                con.Open();
                double bal = Convert.ToDouble(com.ExecuteScalar());
                con.Close();
                return bal;

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetBillPayCharge in AdminClass.cs");
                return 0;
            }
        }

        /// <summary>
        /// get the tran pwd of retailer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean IsvalidRetailerExdPwd(string id, string TranPwd)
        {
            objUtil = new utility();
            con = new SqlConnection(method.str);
            com = new SqlCommand("select RetailerId from RetailerMst where username=@RegNo and ePassword=@ExPwd and  len(@ExPwd)>2  ", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@regNo", id);
            com.Parameters.AddWithValue("@ExPwd", TranPwd);
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close(); con.Dispose();
                    return true;
                }
                else
                {
                    con.Close(); con.Dispose();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// used to get retailer types e.g: national co-ordinator, retailer..
        /// </summary>
        /// <returns></returns>
        public List<ListItem> GetRetailerType()
        {
            con = new SqlConnection(method.str);
            List<ListItem> objList = null;
            try
            {
                com = new SqlCommand("select RetailerTypeId,ReType from RetailerTypeMst where Active=1 ", con);
                com.CommandType = CommandType.Text;
                con.Open();
                Reader = com.ExecuteReader();
                if (Reader.HasRows)
                {
                    objList = new List<ListItem>();
                    while (Reader.Read())
                    {
                        objList.Add(new ListItem(Reader["ReType"].ToString(), Reader["RetailerTypeId"].ToString()));
                    }
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetRetailerType in AdminClass.cs");
                objList = null;
            }
            return objList;
        }


        /// <summary>
        /// Used to get the Retailer Type name and RetailerTypeId in Text and Value field respectivively 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListItem GetRetailerTypeOfRetailer(string RetailerUserName)
        {
            ListItem objItem = null;
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("select RetailerTypeMst.RetailerTypeId,RetailerTypeMst.ReTYpe from retailermst inner join RetailerTypeMst on retailermst.RetailerTypeId=RetailerTypeMst.RetailerTypeId where RetailerMst.username=@uname ", con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@uname", RetailerUserName);
                con.Open();
                Reader = com.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        objItem = new ListItem(Reader["ReType"].ToString(), Reader["RetailerTypeId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetRetailerTypeOfRetailer in AdminClass.cs");
                objItem = null;
            }
            return objItem;
        }


        public Entities.CommssionSurcharge GetRetailerCommissionAndSurCharge(string RetailerUserName, int OperatorID)
        {

            Entities.CommssionSurcharge objCommssionSurcharge = null;
            con = new SqlConnection(method.str);
            try
            {
                com = new SqlCommand("select c.CommissionMode,c.Commission,c.Surcharge  from RetailerComMst c join RetailerMst r on c.RetailerId=r.retailerId join ReCommissionMst o on o.ReCommissionId=c.ReCommissionId where o.Operatorid=@operatorid and r.Username=@uname ", con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@uname", RetailerUserName);
                com.Parameters.AddWithValue("@operatorid", OperatorID);
                con.Open();
                Reader = com.ExecuteReader();
                if (Reader.HasRows)
                {
                    objCommssionSurcharge = new Entities.CommssionSurcharge();
                    Reader.Read();
                    objCommssionSurcharge.CommissionMode = Convert.ToString(Reader["CommissionMode"]);
                    objCommssionSurcharge.Commission = Convert.ToDouble(Reader["Commission"]);
                    objCommssionSurcharge.Surcharge = Convert.ToDouble(Reader["Surcharge"]);
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                utility.WriteErrorLog(ex.Message + " GetRetailerCommissionAndSurCharge in AdminClass.cs");
                objCommssionSurcharge = null;
            }
            return objCommssionSurcharge;
        }
    }
}