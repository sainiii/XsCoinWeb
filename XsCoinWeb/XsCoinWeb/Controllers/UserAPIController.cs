using XsCoinWeb.APPCode;
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
using XsCoinWeb.filter;

namespace XsCoinWeb.Controllers
{
    [ApiAuthenticationFilter]
    public class UserAPIController : ApiController
    {


        [HttpPost]
        public HttpResponseMessage GetServerTime(dynamic SearchForm)
        {
            try
            {


                DataTable dt = new DataTable();
                UserClass CLE = new UserClass();
                dt = CLE.FN_ServerTime();
                string ServerTime = "";
                if (dt.Rows.Count > 0)
                {
                    ServerTime = dt.Rows[0]["ServerTime"].ToString();

                }
                return Request.CreateResponse(HttpStatusCode.OK, ServerTime);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }


        [HttpPost]
        public HttpResponseMessage GetBTCAddminAddress(dynamic SearchForm)
        {
            try
            {
                string BTCType = string.Empty;
                BTCType = (string)SearchForm.BTCType;

                DataTable dt = new DataTable();
                UserClass CLE = new UserClass();
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
                UserClass CLE = new UserClass();
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
                UserClass CLE = new UserClass();
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
                UserClass CLE = new UserClass();
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
        public HttpResponseMessage CreateOTP(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                RegID = (string)SearchForm.RegID;
                string OTPType = string.Empty;
                OTPType = (string)SearchForm.OTPType;
                UserClass CLE = new UserClass();
                DataTable dt = new DataTable();
                dt = CLE.Fn_CreateOTP(RegID, OTPType);
                string OTPCode = "";

                if (dt.Rows.Count > 0)
                {
                    OTPCode = dt.Rows[0]["OPTCode"].ToString();
                    string Emails = dt.Rows[0]["email"].ToString();
                    string OTPtext = "Use  below code to  " + OTPType + " your Account (The below otp is only for " + OTPType + " Account)";
                    ClassEmail OBJ = new ClassEmail();
                    string EmailText = OBJ.GetTemplate("otp.htm");
                    EmailText = EmailText.Replace("XXXOTPTypeXX", OTPtext).Replace("XXOTPXX", OTPCode);
                    try { OBJ.sendMail(Emails, "OTP Code for " + OTPType, EmailText); } catch { }
                }

                return Request.CreateResponse(HttpStatusCode.OK, OTPCode);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }




        [HttpPost]
        public HttpResponseMessage CreateOTPRegistraion(dynamic SearchForm)
        {
            try
            {
                string Email = string.Empty;
                Email = (string)SearchForm.Email;
                string OTPType = string.Empty;
                OTPType = (string)SearchForm.OTPType;
                UserClass CLE = new UserClass();
                DataTable dt = new DataTable();
                dt = CLE.FN_CreateOTPRegistraion(Email, OTPType);
                string OTPCode = "";

                if (dt.Rows.Count > 0)
                {
                    OTPCode = dt.Rows[0]["OPTCode"].ToString();
                    string Emails = dt.Rows[0]["email"].ToString();
                    string OTPtext = "Use  below code to  " + OTPType + " your Account (The below otp is only for " + OTPType + " Account)";
                    ClassEmail OBJ = new ClassEmail();
                    string EmailText = OBJ.GetTemplate("otp.htm");
                    EmailText = EmailText.Replace("XXXOTPTypeXX", OTPtext).Replace("XXOTPXX", OTPCode);
                    try { OBJ.sendMail(Emails, "OTP code for registration", EmailText); } catch { }
                }

                return Request.CreateResponse(HttpStatusCode.OK, OTPCode);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }



        [HttpPost]
        public string MyProfilePic()
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
                UserClass Obj = new UserClass();
                // Obj.Fn_UpdateFileName(FileNameSave, FileID);
            }
            return "uploaded";
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
                UserClass Obj = new UserClass();
                Obj.Fn_UpdateFileName(FileNameSave, FileID);
            }
            return "uploaded";
        }


        [HttpPost]
        public HttpResponseMessage Rechargeuser(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                string Amt = string.Empty;
                string Mode = string.Empty;
                string modeType = string.Empty;
                string UserID = string.Empty;
                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;

                string AddressBTC = string.Empty;
                AddressBTC = (string)SearchForm.AddressBTC;



                UserID = (string)SearchForm.UserID;
                string MobileNo = string.Empty;
                string FileName = string.Empty;
                string ConverAmt = string.Empty;


                RegID = (string)SearchForm.RegID;
                Amt = (string)SearchForm.Amt;
                Mode = (string)SearchForm.Mode;
                modeType = (string)SearchForm.modeType;
                MobileNo = (string)SearchForm.MobileNo;

                ConverAmt = (string)SearchForm.CAmt;




                UserClass Obj = new UserClass();
                DataTable DT = new DataTable();

                if (Mode == "FUND")
                {
                    Obj.Rechargeuser(RegID, Amt, UserID, SKey);
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

                    Obj.RechargeuserBTC(RegID, Amt, UserID, modeType, ConverAmt, SKey, AddressBTC, "1");
                    string OUtMsg = "";
                    string OutID = "";
                    if (Obj.OutMsg == "1")
                    {
                        OUtMsg = Obj.OutMsg;
                    }
                    else { OUtMsg = Obj.OutMsg; }
                    return Request.CreateResponse(HttpStatusCode.OK, new { SeatArragement = OUtMsg, OutID = Obj.OutID });
                }



            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        [HttpPost]
        public HttpResponseMessage Package(dynamic SearchForm)
        {
            try
            {
                string RegNo = string.Empty;
                RegNo = (string)SearchForm.RegNo;
                string OutMsg = "No records found";
                UserClass CLE = new UserClass();
                DataTable DT = new DataTable();
                DT = CLE.Fn_Package(RegNo);

                List<PackageEntity> UserList = new List<PackageEntity>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new PackageEntity()
                                {

                                    srno = dr["srno"].ToString(),
                                    Pname = dr["Pname"].ToString(),
                                    Amount = dr["Amount"].ToString(),
                                    JoinFor = dr["JoinFor"].ToString(),
                                    Points = (dr["Points"]).ToString(),
                                    isactive = (dr["isactive"]).ToString()

                                }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, UserList);

                }

                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, OutMsg); }



            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }

        [HttpPost]
        public HttpResponseMessage PackageDetial(dynamic SearchForm)
        {
            try
            {
                string PackageId = string.Empty;
                PackageId = (string)SearchForm.PackageId;
                string OutMsg = "No records found";
                UserClass CLE = new UserClass();
                DataTable DT = new DataTable();
                DT = CLE.Fn_PackageDetial(PackageId);

                List<PackageEntity> UserList = new List<PackageEntity>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new PackageEntity()
                                {

                                    srno = dr["srno"].ToString(),
                                    Pname = dr["Pname"].ToString(),
                                    Amount = dr["Amount"].ToString(),
                                    JoinFor = dr["JoinFor"].ToString(),
                                    Points = (dr["Points"]).ToString(),

                                }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, UserList);

                }

                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, OutMsg); }



            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }

    }
}
