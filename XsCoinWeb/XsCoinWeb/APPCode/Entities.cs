using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for utility
/// </summary>
namespace XsCoinWeb
{
    public class Entities
    {
        [Serializable]
        public class Item
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public string ID { get; set; }
        }

        [Serializable]
        public class CommssionSurcharge
        {
            public double Commission { get; set; }
            public double Surcharge { get; set; }
            public string CommissionMode { get; set; }
        }
    }

}