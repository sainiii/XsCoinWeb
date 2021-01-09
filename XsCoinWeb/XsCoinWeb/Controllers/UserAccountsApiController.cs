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

using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Signer;
using Nethereum.KeyStore;
using System.Threading.Tasks;

namespace XsCoinWeb.Controllers
{
    [ApiAuthenticationFilter]
    public class UserAccountsApiController : ApiController
    {

        [HttpPost]
        [ApiAuthenticationFilter(false)]
        public HttpResponseMessage GetExchangeRate(dynamic SearchForm)
        {
            try
            {

                DataTable dt = new DataTable();
                APPDL CLE = new APPDL();
                dt = CLE.Fn_GetExchangeRate();
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

        private static HttpClient Client = new HttpClient();
        public async Task<HttpResponseMessage> GetData()
        {
            var web3 = new Nethereum.Web3.Web3("https://mainnet.infura.io/v3/25976c346fcf4be19612caf07c887b3a");
            var result = await web3.Eth.GetBalance.SendRequestAsync("0xee18c75a5f2c3896EcA1026751C80e9C6B96c878", 1);
            //Client.GetAsync("https://www.test.com/users");
            return Request.CreateResponse(HttpStatusCode.OK, result);
             
        }

        [HttpPost]
        [ApiAuthenticationFilter(false)]
        public HttpResponseMessage LoginUserWeb(dynamic LoginUser)
        {

            //var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            //var privateKeyr = ecKey.GetPrivateKeyAsBytes().ToHex();
            //var accountr = new Nethereum.Web3.Accounts.Account(privateKeyr);

            //var web3 = new Nethereum.Web3.Web3("http://localhost:8545/");


            ////var newacont = web3.Eth.Accounts.SendRequestAsync(privateKeyr);
            // var balance =   web3.Eth.GetBalance.SendRequestAsync("0xB0E8Cb105Ab63300b96aA230c9528f49dd087333");
            ////        var Web3 = require('web3');
            ////        var web3 = new Web3(new Web3.providers.HttpProvider());
            ////        var version = web3.version.api;

            ////$.getJSON('http://api.etherscan.io/api?module=contract&action=getabi&address=0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359', function(data) {
            ////            var contractABI = "";
            ////            contractABI = JSON.parse(data.result);
            ////            if (contractABI != '')
            ////            {
            ////                var MyContract = web3.eth.contract(contractABI);
            ////                var myContractInstance = MyContract.at("0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359");
            ////                var result = myContractInstance.memberId("0xfe8ad7dd2f564a877cc23feea6c0a9cc2e783715");
            ////                console.log("result1 : " + result);
            ////                var result = myContractInstance.members(1);
            ////                console.log("result2 : " + result);
            ////            }
            ////            else
            ////            {
            ////                console.log("Error");
            ////            }
            ////        });
            ////        //var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            ////        //var privateKeyr = ecKey.GetPrivateKeyAsBytes().ToHex();
            ////         var accountr = new Nethereum.Web3.Accounts.Account(privateKeyr);

            ////var web3 = new Web3

            ////var balance = web3.Eth.GetBalance.SendRequestAsync("0xee18c75a5f2c3896EcA1026751C80e9C6B96c878", 1);
            //// var newacont = web3.Eth.Accounts.SendRequestAsync(privateKeyr);
            ////var result =  GetData();
            ////string rr=     GetData().ToString();

            try
            {
                string Login = string.Empty;
                string Password = string.Empty;


                Login = (string)LoginUser.LoginID;
                Password = (string)LoginUser.Password;
                ClassUserAccount Resp = new ClassUserAccount();
                DataTable dt = new DataTable();

                dt = Resp.FN_LoginUserWeb(Login, Password);





                List<CustomerList> UserList = new List<CustomerList>();
                if (dt.Rows.Count > 0)
                {
                    UserList = (from DataRow dr in dt.Rows
                                select new CustomerList()
                                {
                                    UserID = dr["AppMstID"].ToString(),
                                    AppMstRegNo = dr["AppMstRegNo"].ToString(),
                                    AppmstFName = dr["AppMstFname"].ToString(),
                                    appmstpaid = dr["appmstactivate"].ToString(),
                                    Number = dr["AppMstMobile"].ToString(),
                                    Email = dr["email"].ToString(),
                                    ProfileImage = dr["imagename"].ToString(),
                                    BTC = dr["AcountNo"].ToString(),
                                    sponsorid = dr["sponsorid"].ToString(),


                                    AccessToken = dr["AccessToken"].ToString(),


                                }).ToList();


                    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(UserList[0].AccessToken);
                    string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                    List<CustomerList> UserListNew = UserList;
                    UserListNew[0].AccessToken = returnValue;
                    return Request.CreateResponse(HttpStatusCode.OK, UserListNew);
                }


                else
                { return Request.CreateResponse(HttpStatusCode.Unauthorized, "UserID and Passwrod invalid"); }


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
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
        [ApiAuthenticationFilter(false)]
        public HttpResponseMessage ForgetPassword(dynamic LoginUser)
        {
            try
            {
                string Login = string.Empty;

                Login = (string)LoginUser.LoginID;
                ClassUserAccount Resp = new ClassUserAccount();
                DataTable dt = new DataTable();
                string Password = "";
                string Email = "";
                string Name = "";
                dt = Resp.FN_ForgetPassword(Login);

                if (dt.Rows.Count > 0)
                {
                    Password = dt.Rows[0]["AppMstPassword"].ToString();
                    Email = dt.Rows[0]["email"].ToString();
                    Name = dt.Rows[0]["AppMstFName"].ToString();
                    ClassEmail OBJ = new ClassEmail();
                    string EmailText = OBJ.GetTemplate("forgotpass.htm");
                    EmailText = EmailText.Replace("XXNameXX", Name.ToUpper()).Replace("XXUserIDXX", Login).Replace("XXPaswordIDXX", Password);
                    try { OBJ.sendMail(Email, "Password", EmailText); } catch { }

                    return Request.CreateResponse(HttpStatusCode.OK, new { USERID = Email });
                }
                else
                { return Request.CreateResponse(HttpStatusCode.Unauthorized, "UserID and Passwrod invalid"); }


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        private bool isValidate(RegisterShape LT, ref string OutMsg)
        {
            bool isValid = true;


            if (string.IsNullOrEmpty(LT.Name) || LT.Name.Length == 0)
            {
                isValid = false;
                OutMsg += "\n" + "Name" + " : " + "Required_Field";
            }

            if (string.IsNullOrEmpty(LT.Email) || LT.Email.Length == 0)
            {
                isValid = false;
                OutMsg += "\n" + "Email" + " : " + "Required_Field";
            }
            if (string.IsNullOrEmpty(LT.Password) || LT.Password.Length == 0)
            {
                isValid = false;
                OutMsg += "\n" + "Password" + " : " + "Required_Field";
            }




            return isValid;
        }








        [HttpPost]
        [ApiAuthenticationFilter(false)]
        public HttpResponseMessage Register(RegisterShape LoginUser)
        {
            try
            {
                string Login = string.Empty;
                ClassUserAccount Resp = new ClassUserAccount();
                DataTable dt = new DataTable();
                string IPAddress = "192.168.3.3";
                string UserID = "";
                string Messages = "";
                if (isValidate(LoginUser, ref UserID))
                {
                    Messages = Resp.FN_Register(LoginUser, IPAddress, out UserID);

                    if (Messages == "1")
                    {
                        LoginUser.RegNO = UserID;
                        return Request.CreateResponse(HttpStatusCode.OK, LoginUser);
                    }
                    else
                    { return Request.CreateResponse(HttpStatusCode.OK, Messages); }
                }

                else { return Request.CreateResponse(HttpStatusCode.Unauthorized, Messages); }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }





        [HttpPost]
        public HttpResponseMessage UpdateProfile(UpdateShape LoginUser)
        {
            try
            {
                string Login = string.Empty;
                ClassUserAccount Resp = new ClassUserAccount();
                DataTable dt = new DataTable();

                string UserID = "";
                string Messages = "";
                if (isUpdatValidate(LoginUser, ref UserID))
                {
                    Messages = Resp.FN_UpdateProfile(LoginUser);
                    return Request.CreateResponse(HttpStatusCode.OK, Messages);

                }

                else { return Request.CreateResponse(HttpStatusCode.Unauthorized, UserID); }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500_INTERNAL_SERVER_ERROR");
            }
        }



        private bool isUpdatValidate(UpdateShape LT, ref string OutMsg)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(LT.Number) || LT.Number.Length == 0)
            {
                isValid = false;
                OutMsg += "\n" + "Mobile" + " : " + "Required_Field";
            }
            if (string.IsNullOrEmpty(LT.Email) || LT.Email.Length == 0)
            {
                isValid = false;
                OutMsg += "\n" + "Email" + " : " + "Required_Field";
            }





            return isValid;
        }
    }
}
