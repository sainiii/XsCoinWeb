using XsCoinWeb.APPCode;
using XsCoinWeb.shapes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XsCoinWeb.filter;

namespace XsCoinWeb.Controllers
{
    [AuthorizationRequiredAttribute]
    public class ReportUserAPIController : ApiController
    {

        [HttpPost]

        [ApiAuthenticationFilter(false)]
        public HttpResponseMessage GetUserInformation(dynamic SearchForm)
        {
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;

            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_UserInformation(Convert.ToString(UserID));
                List<CustomerList> UserList = new List<CustomerList>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new CustomerList()
                                {

                                    appmstpaid = dr["appmstpaid"].ToString(),
                                    appmstDOJ = dr["appmstDOJ"].ToString(),
                                    appPaiddatetime = dr["appPaiddatetime"].ToString(),
                                    AppMstRegNo = dr["AppMstRegNo"].ToString(),
                                    AppmstFName = (dr["AppmstFName"]).ToString(),
                                    appmststate = dr["appmststate"].ToString(),
                                    appmstcity = dr["appmstcity"].ToString(),
                                    AppmstSponsorTotal = dr["AppmstSponsorTotal"].ToString(),
                                    appmstLeftTotal = dr["appmstLeftTotal"].ToString(),
                                    appmstRightTotal = (dr["appmstRightTotal"]).ToString(),
                                    sponsorid = dr["sponsorid"].ToString(),
                                    Email = (dr["email"]).ToString(),
                                    Number = dr["AppMstMobile"].ToString(),
                                    BTC = dr["AcountNo"].ToString(),
                                    Country = dr["distt"].ToString(),
                                    zipCode = dr["appmstpincode"].ToString(),
                                    ProfileImage = dr["imagename"].ToString(),
                                    Type = dr["Type"].ToString(),
                                    Passowrd = dr["AppMstPassword"].ToString(),
                                    EPassowrd = dr["ePassword"].ToString(),

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
        public HttpResponseMessage Fn_UserInformationFull(dynamic SearchForm)
        {
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_UserInformationFull(Convert.ToString(UserID));
                List<CustomerList> UserList = new List<CustomerList>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new CustomerList()
                                {

                                    appmstpaid = dr["appmstpaid"].ToString(),
                                    appmstDOJ = dr["appmstDOJ"].ToString(),
                                    appPaiddatetime = dr["appPaiddatetime"].ToString(),
                                    AppMstRegNo = dr["AppMstRegNo"].ToString(),
                                    AppmstFName = (dr["AppmstFName"]).ToString(),
                                    appmststate = dr["appmststate"].ToString(),
                                    appmstcity = dr["appmstcity"].ToString(),
                                    AppmstSponsorTotal = dr["AppmstSponsorTotal"].ToString(),
                                    appmstLeftTotal = dr["appmstLeftTotal"].ToString(),
                                    appmstRightTotal = (dr["appmstRightTotal"]).ToString(),
                                    sponsorid = dr["sponsorid"].ToString(),
                                    newsponsortotal = dr["newsponsortotal"].ToString(),
                                    membersince = dr["membersince"].ToString(),
                                    expirydays = dr["expirydays"].ToString(),
                                    
                                    TeamSales = dr["TeamSales"].ToString(),
                                    TWithDraw = dr["TWithDraw"].ToString(),
                                    TPending = (dr["TPending"]).ToString(),
                                    DirectINcome = dr["DirectINcome"].ToString(),
                                    ROI = dr["ROI"].ToString(),
                                    TeamIncome = dr["TeamIncome"].ToString(),
                                    imagename = dr["imagename"].ToString(),
                                    MYpakage = dr["MYpakage"].ToString(),
                                    DAysCount = dr["DAysCount"].ToString(),
                                    ROICountShow = dr["ROICountShow"].ToString(),




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
        public HttpResponseMessage GetBlanceVPIncome(dynamic SearchForm)
        {
            try
            {
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;
                DataTable dt = new DataTable();
                APPDL CLE = new APPDL();
                dt = CLE.Fn_UserVPBlance(UserID);
                string UserBlance = "";
                string ERate= "00";
                if (dt.Rows.Count > 0)
                {
                    UserBlance = dt.Rows[0]["vpbalance"].ToString();
                    ERate = dt.Rows[0]["ERate"].ToString();

                }
                return Request.CreateResponse(HttpStatusCode.OK, new {Blance = UserBlance, ExchangeRate = ERate });
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_Internal_Server_Error");
            }
        }

        [HttpPost]
        public HttpResponseMessage Getaccountstatement(dynamic SearchForm)
        {

            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_UserDetail(Convert.ToString(UserID));
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
                                    OutAmount = dr["OutAmount"].ToString(),
                                    dollar = dr["dollar"].ToString(),


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
        public HttpResponseMessage Getrefreport(dynamic SearchForm)
        {
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_referral(Convert.ToString(UserID));
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
        public HttpResponseMessage Getdownlinedetail(dynamic SearchForm)
        {
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_downlinedetail(Convert.ToString(UserID));
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
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_referralincome(Convert.ToString(UserID));
                List<referralincomePage> UserList = new List<referralincomePage>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new referralincomePage()
                                {
                                    Amount = (dr["banktranamount"]).ToString(),
                                    BankTranDate = dr["BankTranDate"].ToString(),
                                    BankTranRemarks = dr["PName"].ToString(),
                                    OutAmount = dr["OutAmount"].ToString(),
                                    dollar = dr["dollar"].ToString(),


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
                DT = Obj.Fn_ROIincome(Convert.ToString(UserID));
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
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_transferreport(Convert.ToString(UserID));
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
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_withdrawhistory(Convert.ToString(UserID));
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
            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_upgradereport(Convert.ToString(UserID));
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


        [HttpPost]
        public HttpResponseMessage GetBTCAddress(dynamic SearchForm)

        {
            try
            {
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;


                //CustomerList U = new AppUserAccounts().GetUserDetails(Request);
                string Namee = "";
                APPDL CLE = new APPDL();
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

                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                BTCAMount = (string)SearchForm.BTCAMount;
                txtbtc = (string)SearchForm.txtbtc;
                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                string OUtMsg = "";
                Obj.WithDraw(UserID, Amount, BTCAMount, txtbtc, SKey, out OUtMsg);
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

                string PregNo = string.Empty;
                string SKey = string.Empty;
                SKey = (string)SearchForm.SKey;
                string UserID = string.Empty;
                UserID = (string)SearchForm.UserID;
                Amount = (string)SearchForm.Amount;
                PregNo = (string)SearchForm.PregNo;
                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                string OUtMsg = "";
                Obj.FN_Fundtrasfer(UserID, PregNo, Amount, SKey, out OUtMsg);
                return Request.CreateResponse(HttpStatusCode.OK, OUtMsg);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }
    }
}
