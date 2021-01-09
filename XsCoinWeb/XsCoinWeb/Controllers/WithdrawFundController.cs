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
    public class WithdrawFundController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage GetBTCAddress(dynamic SearchForm)
        {
            try
            {
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;
                string Namee = "";
                UserClass CLE = new UserClass();
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
                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                BTCAMount = (string)SearchForm.BTCAMount;
                txtbtc = (string)SearchForm.txtbtc;
                UserClass Obj = new UserClass();
                DataTable DT = new DataTable();
                Obj.WithDraw(UserID, Amount, BTCAMount, txtbtc, SKey);
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
                string PregNo = string.Empty;
                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                PregNo = (string)SearchForm.PregNo;
                UserClass Obj = new UserClass();
                DataTable DT = new DataTable();
                Obj.FN_Fundtrasfer(UserID, PregNo, Amount,   SKey);
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
