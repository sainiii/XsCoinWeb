using XsCoinWeb.APPCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using XsCoinWeb.shapes;

namespace XsCoinWeb.Controllers
{
    public class UserAPIdataController : ApiController
    {


        [HttpPost]
        public HttpResponseMessage Getaccountstatement(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_UserDetail(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<accountstatementPage> UserList = new List<accountstatementPage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new accountstatementPage()
                                {
                                    Amount = (dr["BankTranAmount"]).ToString(),
                                    BankTranBalance = dr["BankTranBalance"].ToString(),
                                    BankTranRemarks = dr["BankTranRemarks"].ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    PType = dr["PType"].ToString(),
                                    PName = dr["PName"].ToString(),


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
        public HttpResponseMessage Getdownlinedetail(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_downlinedetail(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<downlinedetailPage> UserList = new List<downlinedetailPage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new downlinedetailPage()
                                {
                                    AppMstRegNo = (dr["AppMstRegNo"]).ToString(),
                                    membername = dr["membername"].ToString(),
                                    AppMstLeftRight = dr["AppMstLeftRight"].ToString(),
                                    AppMstMobile = dr["AppMstMobile"].ToString(),
                                    AppmstDOJ = (dr["AppmstDOJ"]).ToString(),
                                    topupdate = dr["topupdate"].ToString(),
                                    jamount = dr["jamount"].ToString(),
                                    Appmstpaid = dr["Appmstpaid"].ToString(),


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
        public HttpResponseMessage Getreferralincome(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_referralincome(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<referralincomePage> UserList = new List<referralincomePage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new referralincomePage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    BankTranRemarks = dr["BankTranRemarks"].ToString(),



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
        public HttpResponseMessage GetROIIncome(dynamic SearchForm)
        {
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try 
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_ROIincome(HttpContext.Current.Request.Cookies["userId"].Value.ToString());
                List<referralincomePage> UserList = new List<referralincomePage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new referralincomePage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    BankTranRemarks = dr["BankTranRemarks"].ToString(),



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
        public HttpResponseMessage transferreport(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_transferreport(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<transferreportPage> UserList = new List<transferreportPage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new transferreportPage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    PaidDetail = dr["PaidDetail"].ToString(),



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
        public HttpResponseMessage withdrawhistory(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_withdrawhistory(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<withdrawhistoryPage> UserList = new List<withdrawhistoryPage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new withdrawhistoryPage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    BankTranRemarks = dr["BankTranRemarks"].ToString(),



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
        public HttpResponseMessage upgradereport(dynamic SearchForm)
        {
            string DATE = string.Empty;
            DATE = (string)SearchForm.DATE;
            string OutMsg = "";
            try
            {

                DL Obj = new DL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_upgradereport(Convert.ToString(HttpContext.Current.Request.Cookies["userId"].Value.ToString()));
                List<upgradereportPage> UserList = new List<upgradereportPage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new upgradereportPage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    PaidDetail = dr["PaidDetail"].ToString(),



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
