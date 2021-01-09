
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using XsCoinWeb.APPCode;
using XsCoinWeb.shapes;

namespace XsCoinWeb.Controllers
{


    public class UserAppAPIController : ApiController
    {




        [HttpPost]
        public HttpResponseMessage GetBTCAddminAddress(dynamic SearchForm)
        {
            try
            {
                string BTCType = string.Empty;
                BTCType = (string)SearchForm.BTCType;

                DataTable dt = new DataTable();
                UserAppClass CLE = new UserAppClass();
                dt = CLE.BTCAdminAddress(BTCType);
                string Blance = "";
                if (dt.Rows.Count > 0)
                {
                    Blance = dt.Rows[0]["Address"].ToString();

                }
                return Request.CreateResponse(HttpStatusCode.OK, Blance);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }


        [HttpPost]
        public HttpResponseMessage GetBlanceIncome(dynamic SearchForm)
        {
            try
            {
                string EmailID = string.Empty;
                EmailID = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();
                DataTable dt = new DataTable();
                UserAppClass CLE = new UserAppClass();
                dt = CLE.Fn_UserBlance(EmailID);
                string Blance = "";
                if (dt.Rows.Count > 0)
                {
                    Blance = dt.Rows[0]["balance"].ToString();

                }
                return Request.CreateResponse(HttpStatusCode.OK, Blance);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }


        [HttpPost]
        public HttpResponseMessage GetBlanceVPIncome(dynamic SearchForm)
        {
            try
            {
                string EmailID = string.Empty;
                EmailID = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();
                DataTable dt = new DataTable();
                UserAppClass CLE = new UserAppClass();
                dt = CLE.Fn_UserVPBlance(EmailID);
                string Blance = "";
                if (dt.Rows.Count > 0)
                {
                    Blance = dt.Rows[0]["vpbalance"].ToString();

                }
                return Request.CreateResponse(HttpStatusCode.OK, Blance);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }


        [HttpPost]
        public HttpResponseMessage GetName(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                RegID = (string)SearchForm.RegID;
                string Namee = "";
                UserAppClass CLE = new UserAppClass();
                Namee = CLE.Fn_UserName(RegID);
                string Blance = "";
                if (Namee != "")
                {
                    Blance = Namee;

                }
                return Request.CreateResponse(HttpStatusCode.OK, Blance);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }




        [HttpPost]
        public string MyFileUpload()
        {
            var request = HttpContext.Current.Request;
            string filename = request.Headers["filename"];
            string FileID = request.Headers["FileID"];
            int n = filename.IndexOf('.');
            string FileExt = filename.Substring(n);
            string FileNameSave = FileID + "" + FileExt;
            var filePath = HttpContext.Current.Server.MapPath("~/PaymentRecepit/" + FileNameSave);
            using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                request.InputStream.CopyTo(fs);
                UserAppClass Obj = new UserAppClass();
                Obj.Fn_UpdateFileName(FileNameSave, FileID);
            }
            return "uploaded";
        }

        [HttpPost]
        public string UploadPic()
        {
            var request = HttpContext.Current.Request;
            string filename = request.Headers["filename"];
            string FileID = request.Headers["FileID"];
            int n = filename.IndexOf('.');
            string FileExt = filename.Substring(n);
            string FileNameSave = FileID + "" + FileExt;
            var filePath = HttpContext.Current.Server.MapPath("~/ProfileImages/" + FileNameSave);
            using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                request.InputStream.CopyTo(fs);
                UserAppClass Obj = new UserAppClass();
                Obj.Fn_UpdateProilePic(FileNameSave, FileID);
            }
            return "uploaded";
        }








        [HttpPost]
        public HttpResponseMessage Purchasepackage(dynamic SearchForm)
        {
            try
            {





                string RegID = string.Empty;
                string Amt = string.Empty;
                string Type = string.Empty;
                string OTP = string.Empty;

                string Amountrate = string.Empty;
                string ConverAmt = string.Empty;



                OTP = (string)SearchForm.OTP;
                Type = (string)SearchForm.Type;
                RegID = (string)SearchForm.RegID;
                Amt = (string)SearchForm.Amt;
                Amountrate = (string)SearchForm.Amountrate;
                ConverAmt = (string)SearchForm.ConverAmt;



                APPDL Objnew = new APPDL();
                DataTable Dtt = new DataTable();
                Dtt = Objnew.Fn_UserInformation(Convert.ToString(RegID));
                int appmstpaid = 0;
                if (Dtt.Rows.Count > 0)
                {
                    appmstpaid = Convert.ToInt16(Dtt.Rows[0]["appmstpaid"]);
                }


                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();

                if (appmstpaid == 0)
                {
                    Obj.ActivateUser(RegID, Amt, OTP, Amountrate, ConverAmt);
                    string OUtMsg = "";
                    if (Obj.OutMsg == "1")
                    {
                        OUtMsg = Obj.OutMsg;
                    }
                    else { OUtMsg = Obj.OutMsg; }

                    return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);
                }

                else
                {

                    Obj.UpgradeUser(ConverAmt, RegID, Amt, OTP, Amountrate);
                    string OUtMsg = "";
                    if (Obj.OutMsg == "1")
                    {
                        OUtMsg = Obj.OutMsg;
                    }
                    else { OUtMsg = Obj.OutMsg; }

                    return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);
                }




            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }




        [HttpPost]
        public HttpResponseMessage UpgradeUser(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                string Amt = string.Empty;
                string OTPCode = string.Empty;
                string Amountrate = string.Empty;
                string ConverAmt = string.Empty;
                RegID = (string)SearchForm.RegID;
                Amt = (string)SearchForm.Amt;
                ConverAmt = (string)SearchForm.CAmt;
                Amountrate = (string)SearchForm.Amountrate;
                OTPCode = (string)SearchForm.OTPCode;
                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();
                Obj.UpgradeUser(ConverAmt, RegID, Amt, OTPCode, Amountrate);
                string OUtMsg = "";
                if (Obj.OutMsg == "1")
                {
                    OUtMsg = Obj.OutMsg;
                }
                else { OUtMsg = Obj.OutMsg; }

                return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);






            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        [HttpPost]
        public HttpResponseMessage GetCoinPayMentTxn(dynamic SearchForm)
        {

            string TransactionID = string.Empty;
            TransactionID = (string)SearchForm.TransactionID;
            string UserId = string.Empty;
            UserId = (string)SearchForm.UserId;

            string OutMsg = "No records found";
            try
            {

                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();
                DT = Obj.Fn_CoinPayMentTxn(Convert.ToString(TransactionID), UserId);
                List<PayMentCoinPayment> UserList = new List<PayMentCoinPayment>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new PayMentCoinPayment()
                                {
                                    LeftTime = (dr["LeftTime"]).ToString(),
                                    UserID = (dr["MemberID"]).ToString(),
                                    RequestAmount = dr["RequestAmount"].ToString(),
                                    Currency = dr["currency1"].ToString(),
                                    Currency2 = dr["currency2"].ToString(),
                                    amount = dr["amount"].ToString(),
                                    address = dr["Toaddress"].ToString(),
                                    txn_id = dr["txn_id"].ToString(),
                                    confirms_needed = dr["confirms_needed"].ToString(),
                                    timeout = dr["timeout"].ToString(),
                                    status_url = dr["status_url"].ToString(),
                                    qrcode_url = dr["qrcode_url"].ToString(),
                                    status_text = dr["status_text"].ToString(),
                                    status = dr["status"].ToString(),
                                    time_created = dr["time_created"].ToString(),
                                    CreatedOn = dr["AddDate"].ToString(),
                                    UpdateDate = dr["UpdateDate"].ToString(),
                                    AmountFor = dr["AmountFor"].ToString(),

                                }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, UserList);

                }

                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, OutMsg); }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }




        [HttpPost]
        public HttpResponseMessage activeandUpgradeHistory(dynamic SearchForm)
        {


            string UserId = string.Empty;
            UserId = (string)SearchForm.UserID;

            string OutMsg = "No records found";
            try
            {

                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();
                DT = Obj.activeandUpgradeHistory(UserId);
                List<activeandUpgradeHistory> UserList = new List<activeandUpgradeHistory>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new activeandUpgradeHistory()
                                {
                                    BankTranAmount = (dr["BankTranAmount"]).ToString(),
                                    BankTranDate = (dr["BankTranDate"]).ToString(),
                                    BankTranMode = dr["BankTranMode"].ToString(),
                                    AppMstRegNo = dr["AppmstRegno"].ToString(),
                                    AmountFor = dr["AmountFor"].ToString(),

                                }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, UserList);

                }

                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, OutMsg); }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }
    }
}
