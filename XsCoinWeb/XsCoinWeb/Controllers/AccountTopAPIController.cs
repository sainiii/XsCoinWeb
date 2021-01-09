using XsCoinWeb.APPCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace XsCoinWeb.Controllers
{
    public class AccountTopAPIController : ApiController
    {



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
        public HttpResponseMessage RechargeuserTOP(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                string Amt = string.Empty;
                string Mode = string.Empty;
                string modeType = string.Empty;
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID; 
                string MobileNo = string.Empty;
                string FileName = string.Empty;
                string ConverAmt = string.Empty;
                string SKey = string.Empty;

                string AddressBTC = string.Empty;
                AddressBTC = (string)SearchForm.AddressBTC;


                SKey = (string)SearchForm.SKey;
                RegID = (string)SearchForm.RegID;
                Amt = (string)SearchForm.Amt;
                Mode = (string)SearchForm.Mode;
                modeType = (string)SearchForm.modeType;
                MobileNo = (string)SearchForm.MobileNo;
                ConverAmt = (string)SearchForm.CAmt;
                UserClass Obj = new UserClass();
                DataTable DT = new DataTable();
                if (Mode == "CRP")
                {

                    Obj.RechargeuserBTC(RegID, Amt, UserID, modeType, ConverAmt, SKey, AddressBTC, "0");
                    string OUtMsg = "";
                    string OutID = "";
                    if (Obj.OutMsg == "1")
                    {
                        OUtMsg = Obj.OutMsg;
                    }
                    else { OUtMsg = Obj.OutMsg; }
                    return Request.CreateResponse(HttpStatusCode.OK, new { SeatArragement = OUtMsg, OutID = Obj.OutID });
                }

                else
                {

                    Obj.AccountTopUP(RegID, Amt, UserID, SKey);
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

    }
}
