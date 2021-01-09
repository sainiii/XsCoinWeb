using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public static class TokenEncode
    {

        public static string Encode(string UserName, string pwd)
        {
            string toEncode = UserName + ":" + pwd;
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue = "Basic " + System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }



        public static string Decode(string str)
        {

            byte[] encodedDataAsBytes = System.Convert.FromBase64String(str);

            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}