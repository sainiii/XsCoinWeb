using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XsCoinWeb.APPCode;

namespace XsCoinWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Web3Class obj = new Web3Class();
            string rrr = Convert.ToString(obj.MyCallingMethod());

        }
    }
}