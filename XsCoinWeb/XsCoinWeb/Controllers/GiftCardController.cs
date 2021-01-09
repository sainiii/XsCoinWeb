using XsCoinWeb.APPCode;
using XsCoinWeb.filter;
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

namespace XsCoinWeb.Controllers
{
  // [AuthorizationRequiredAttribute]
    public class GiftCardController : ApiController
    {



        [HttpPost]
        public HttpResponseMessage GetCountryList(dynamic SearchForm)
        {

            string Country = string.Empty;
            Country = (string)SearchForm.Country;
            string CurrencyCode = string.Empty;
            CurrencyCode = (string)SearchForm.CurrencyCode;
            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();
                DataTable DTA = new DataTable();
                DS = Obj.GetCountryList();
                dt = DS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var parents = new List<CountryList>();


                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        var parent = new CountryList()
                        {
                            country = (dt.Rows[I]["country"]).ToString(),
                        };


                        parents.Add(parent);

                    }
                    return Request.CreateResponse(HttpStatusCode.OK, parents);


                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        [HttpPost]
        public HttpResponseMessage GetGiftCardList(dynamic SearchForm)
        {

            string Country = string.Empty;
            Country = (string)SearchForm.Country;
            string CurrencyCode = string.Empty;
            CurrencyCode = (string)SearchForm.CurrencyCode;
            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();
                DataTable DTA = new DataTable();
                DS = Obj.Fn_GetGiftCardList(Country, CurrencyCode);
                dt = DS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var parents = new List<GiftCard>();
                    var MM = new List<GiftCardAmountAmst>();

                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        var parent = new GiftCard()
                        {
                            ID = (dt.Rows[I]["ID"]).ToString(),
                            ProductName = (dt.Rows[I]["ProductName"]).ToString(),
                            Curency = dt.Rows[I]["Curency"].ToString(),
                            Country = dt.Rows[I]["Country"].ToString(),
                            SendType = dt.Rows[I]["SendType"].ToString(),
                            Description = dt.Rows[I]["Description"].ToString(),
                            Termscondition = dt.Rows[I]["Termscondition"].ToString(),
                            Photo = dt.Rows[I]["Photo"].ToString(),
                            IsActive = dt.Rows[I]["IsActive"].ToString(),

                        };


                        parents.Add(parent);

                    }
                    return Request.CreateResponse(HttpStatusCode.OK, parents);


                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }

        [HttpPost]
        public HttpResponseMessage GetGiftCardListbyID(dynamic SearchForm)
        {

            string GiftCardId = string.Empty;
            GiftCardId = (string)SearchForm.GiftCardId;

            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();
                DataTable DTA = new DataTable();
                DS = Obj.Fn_GetGiftCardDetialbyID(GiftCardId);
                dt = DS.Tables[0];
                DTA = DS.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    var parents = new List<GiftCard>();
                    var MM = new List<GiftCardAmountAmst>();

                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        var parent = new GiftCard()
                        {
                            ID = (dt.Rows[I]["ID"]).ToString(),
                            ProductName = (dt.Rows[I]["ProductName"]).ToString(),
                            Curency = dt.Rows[I]["Curency"].ToString(),
                            Country = dt.Rows[I]["Country"].ToString(),
                            SendType = dt.Rows[I]["SendType"].ToString(),
                            Description = dt.Rows[I]["Description"].ToString(),
                            Termscondition = dt.Rows[I]["Termscondition"].ToString(),
                            Photo = dt.Rows[I]["Photo"].ToString(),
                            IsActive = dt.Rows[I]["IsActive"].ToString(),
                            GiftCardAmount = new List<GiftCardAmountAmst>(),
                        };


                        DataTable tblFiltered = new DataTable();
                        try
                        {
                            tblFiltered = DTA.AsEnumerable().Where(r => r.Field<Int64>("GiftCardID") == Convert.ToInt64(dt.Rows[I]["ID"])).CopyToDataTable();
                        }
                        catch (Exception ex) { }
                        if (tblFiltered.Rows.Count > 0)
                        {
                            for (int J = 0; J < tblFiltered.Rows.Count; J++)
                            {
                                GiftCardAmountAmst RR = new GiftCardAmountAmst()
                                {
                                    Amount = tblFiltered.Rows[J]["Amount"].ToString().Trim(),
                                };
                                parent.GiftCardAmount.Add(RR);
                            }
                        }

                        parents.Add(parent);

                    }
                    return Request.CreateResponse(HttpStatusCode.OK, parents);


                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }




        [HttpPost]
        public HttpResponseMessage RequestGiftOrderbyUser(dynamic SearchForm)
        {
            try
            {
                string RegID = string.Empty;
                string Amt = string.Empty;
                string SentID = string.Empty;
                string RequestAmount = string.Empty;
                string GiftCardId = string.Empty;
                string SKey = string.Empty;
                string AddressBTC = string.Empty;
                SKey = (string)SearchForm.SKey;
                RegID = (string)SearchForm.RegID;
                Amt = (string)SearchForm.Amt;
                SentID = (string)SearchForm.SentID;
                RequestAmount = (string)SearchForm.RequestAmount;
                GiftCardId = (string)SearchForm.GiftCardId;

                GiftCardDB Obj = new GiftCardDB();
                DataTable DT = new DataTable();
                Obj.GiftOrderbyUser(RegID, Amt, SentID, RequestAmount, GiftCardId, SKey);
                string OUtMsg = "1";
                if (Obj.OutMsg == "1")
                {
                    OUtMsg = Obj.OutMsg;
                }
                else { OUtMsg = Obj.OutMsg; }
                return Request.CreateResponse(HttpStatusCode.OK, new { SeatArragement = OUtMsg });

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        [HttpPost]
        public HttpResponseMessage OrderGiftCardUserList(dynamic SearchForm)
        {

            string UserID = string.Empty;

            if ((string)SearchForm.UserID == null && (string)SearchForm.UserID == "")
            {

                UserID = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();
            }
            else
            {
                UserID = (string)SearchForm.UserID;

            }

            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();

                DS = Obj.OrderGiftCardUserList(UserID);
                dt = DS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var parents = new List<OrderGiftCardList>();


                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        var parent = new OrderGiftCardList()
                        {
                            orderID = (dt.Rows[I]["orderID"]).ToString(),
                            Productname = (dt.Rows[I]["Productname"]).ToString(),
                            Curency = dt.Rows[I]["Curency"].ToString(),
                            Status = dt.Rows[I]["Status"].ToString(),
                            Amount = dt.Rows[I]["Amount"].ToString(),
                            OrderDate = dt.Rows[I]["OrderDate"].ToString(),
                        };


                        parents.Add(parent);

                    }
                    return Request.CreateResponse(HttpStatusCode.OK, parents);


                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        [HttpPost]
        public HttpResponseMessage OrderGiftCardUserListWeb(dynamic SearchForm)
        {

            string UserID = string.Empty;

            UserID = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();


            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();

                DS = Obj.OrderGiftCardUserList(UserID);
                dt = DS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var parents = new List<OrderGiftCardList>();


                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        var parent = new OrderGiftCardList()
                        {
                            orderID = (dt.Rows[I]["orderID"]).ToString(),
                            Productname = (dt.Rows[I]["Productname"]).ToString(),
                            Curency = dt.Rows[I]["Curency"].ToString(),
                            Status = dt.Rows[I]["Status"].ToString(),
                            Amount = dt.Rows[I]["Amount"].ToString(),
                            OrderDate = dt.Rows[I]["OrderDate"].ToString(),
                        };


                        parents.Add(parent);

                    }
                    return Request.CreateResponse(HttpStatusCode.OK, parents);


                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }
        [HttpPost]
        public HttpResponseMessage GetGiftCardCode(dynamic SearchForm)
        {
            string Skey = string.Empty;
            Skey = (string)SearchForm.Skey;
            string OrderID = string.Empty;
            OrderID = (string)SearchForm.OrderID;
            string UserID = string.Empty;
            UserID = HttpContext.Current.Request.Cookies["userId"].Value.ToString().Trim();
            string OutMsg = "No records found";
            try
            {
                DataSet DS = new DataSet();
                GiftCardDB Obj = new GiftCardDB();
                DataTable dt = new DataTable();
                Obj.GetGiftCardCode(UserID, Skey, OrderID);
                string OUtMsg = "";
                string Code = "";
                if (Obj.OutMsg == "1")
                {
                    OUtMsg = Obj.OutMsg;
                    Code = Obj.OutID;
                }
                else { OUtMsg = Obj.OutMsg; }
                return Request.CreateResponse(HttpStatusCode.OK, new { SeatArragement = OUtMsg, Code = Obj.OutID });


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }
    }
}
