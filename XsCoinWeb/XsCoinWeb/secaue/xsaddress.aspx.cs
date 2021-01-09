using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nethereum.Contracts;
using Nethereum.Contracts.DeploymentHandlers;
using Nethereum.Contracts.Services;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

using System.Collections;
 
using System.Numerics;
using System.Runtime.InteropServices;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
 
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.Extensions;

using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;

namespace XsCoinWeb.secaue
{
    public partial class xsaddress : System.Web.UI.Page
    {
        protected async System.Threading.Tasks.Task Page_LoadAsync(object sender, EventArgs e)
        {
            var url = "http://localhost:8545";
            var privateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);
            //var deployment = XsCoinWeb.;
            //var receipt = await XsCoinWeb.DeployContractAndWaitForReceiptAsync(web3, deployment);
            //var service = new SimpleStorageService(web3, receipt.ContractAddress);
 
        }
    }
}