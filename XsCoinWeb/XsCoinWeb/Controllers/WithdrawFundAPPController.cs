
using XsCoinWeb.APPCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XsCoinWeb.Controllers
{
    public class WithdrawFundAPPController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetBTCAddress(dynamic SearchForm)
        {
            try
            {
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;
                string Namee = "";
                UserAppClass CLE = new UserAppClass();
                Namee = CLE.Fn_GetBTCAddress(UserID);
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
        public HttpResponseMessage FundWithDraw(dynamic SearchForm)
        {
            try
            {
                string Amount = string.Empty;
                string txtbtc = string.Empty;
                string BTCAMount = string.Empty;
                string UserID = string.Empty;
                string OTPCode = string.Empty;
                OTPCode = (string)SearchForm.OTPCode;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                BTCAMount = (string)SearchForm.BTCAMount;
                txtbtc = (string)SearchForm.txtbtc;
                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();
                Obj.WithDraw(UserID, Amount, BTCAMount, txtbtc, OTPCode);
                string OUtMsg = Obj.OutMsg;
                return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);





            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }

        [HttpPost]
        public HttpResponseMessage Fundtrasfer(dynamic SearchForm)
        {
            try
            {
                string Amount = string.Empty;
                string UserID = string.Empty;
                string TrsferID = string.Empty;
                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                TrsferID = (string)SearchForm.TrsferID;
                UserAppClass Obj = new UserAppClass();
                DataTable DT = new DataTable();
                Obj.FN_Fundtrasfer(UserID, TrsferID, Amount, SKey);
                string OUtMsg = Obj.OutMsg;
                return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);





            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }
    }
}
