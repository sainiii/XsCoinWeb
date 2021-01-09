using XsCoinWeb.APPCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XsCoinWeb.shapes;

namespace XsCoinWeb.Controllers
{
    public class AppTreeController : ApiController
    {


        [HttpPost]
        public HttpResponseMessage GetFirstLevel(dynamic SearchForm)
        {

            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_TreeFistLavel(Convert.ToString(UserID));
                List<ClassShapeTree> UserList = new List<ClassShapeTree>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new ClassShapeTree()
                                {
                                    AppMstRegNo = (dr["AppMstRegNo"]).ToString(),
                                    AppMstFName = dr["AppMstFName"].ToString(),
                                    AppMstLeftRight = dr["AppMstLeftRight"].ToString(),
                                    SponsorID = dr["SponsorID"].ToString(),
                                    ParentID = dr["ParentID"].ToString(),
                                    joinfor = dr["joinfor"].ToString(),
                                    AppMstLeftTotal = dr["AppMstLeftTotal"].ToString(),
                                    AppMstRightTotal = dr["AppMstRightTotal"].ToString(),
                                    carryleft = dr["carryleft"].ToString(),
                                    carryright = dr["carryright"].ToString(),
                                    totalnewleft = dr["totalnewleft"].ToString(),
                                    totalnewright = dr["totalnewright"].ToString(),
                                    appmstpaid = dr["appmstpaid"].ToString(),
                                    LeftMember = dr["LeftMember"].ToString(),
                                    rightMember = dr["rightMember"].ToString(),
                                    appmstdoj = dr["appmstdoj"].ToString(),
                                    ImagePath = dr["imagePath"].ToString(),

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
        public HttpResponseMessage GetSecondLevel(dynamic SearchForm)
        {

            string UserID = string.Empty;
            UserID = (string)SearchForm.UserID;

            int PType = 0;
            PType = (int)SearchForm.PType;
            string OutMsg = "No records found";
            try
            {

                APPDL Obj = new APPDL();
                DataTable DT = new DataTable();
                DT = Obj.Fn_TreeSecondLavel(Convert.ToString(UserID), PType);
                List<ClassShapeTree> UserList = new List<ClassShapeTree>();
                if (DT.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in DT.Rows
                                select new ClassShapeTree()
                                {
                                    AppMstRegNo = (dr["AppMstRegNo"]).ToString(),
                                    AppMstFName = dr["AppMstFName"].ToString(),
                                    AppMstLeftRight = dr["AppMstLeftRight"].ToString(),
                                    SponsorID = dr["SponsorID"].ToString(),
                                    ParentID = dr["ParentID"].ToString(),
                                    joinfor = dr["joinfor"].ToString(),
                                    AppMstLeftTotal = dr["AppMstLeftTotal"].ToString(),
                                    AppMstRightTotal = dr["AppMstRightTotal"].ToString(),
                                    carryleft = dr["carryleft"].ToString(),
                                    carryright = dr["carryright"].ToString(),
                                    totalnewleft = dr["totalnewleft"].ToString(),
                                    totalnewright = dr["totalnewright"].ToString(),
                                    appmstpaid = dr["appmstpaid"].ToString(),
                                    LeftMember = dr["LeftMember"].ToString(),
                                    rightMember = dr["rightMember"].ToString(),
                                    appmstdoj = dr["appmstdoj"].ToString(),
                                    ImagePath = dr["imagePath"].ToString(),

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
