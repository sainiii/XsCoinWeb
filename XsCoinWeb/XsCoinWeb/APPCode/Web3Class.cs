using Nethereum.Hex.HexConvertors.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace XsCoinWeb.APPCode
{
    public class Web3Class
    {

        public async Task<string> MyCallingMethod()
        {

            //string password = "MYSTRONGPASS";
            //EthECKey key = EthECKey.GenerateKey();
            //byte[] privateKey = key.GetPrivateKeyAsBytes();
            //string address = key.GetPublicAddress();
            //var keyStore = new KeyStoreScryptService();

            //string json = keyStore.EncryptAndGenerateKeyStoreAsJson(
            //    password: password,
            //    privateKey: privateKey,
            //    addresss: address);

            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKeyr = ecKey.GetPrivateKeyAsBytes().ToHex();
              var accountr = new Nethereum.Web3.Accounts.Account(privateKeyr);

            var web3 = new Nethereum.Web3.Web3("http://localhost:8545/");
             

            var newacont =   web3.Eth.Accounts.SendRequestAsync(privateKeyr);


            var newacontr = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(privateKeyr);

            //var balance = web3.Eth.GetBalance.SendRequestAsync("0xee18c75a5f2c3896EcA1026751C80e9C6B96c878");

            ///var balance = web3.Eth.GetBalance.SendRequestAsync("0x6f7d8d0378993fe55628257710160f3bb83490b0");

            //var txCount =   web3.Eth.Transactions.GetTransactionCount.SendRequestAsync("0x4D7fB0C555314222e0690fe80DAE8Ba2F9450595");

            ////var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            ////var account = new Account(privateKey);
            ////Console.WriteLine("Our account: " + account.Address);
            //////Now let's create an instance of Web3 using our account pointing to our nethereum testchain
            //var web3 = new Web3(accountr, "http://testchain.nethereum.com:8545");

            ////  //Check the balance of the account we are going to send the Ether
            // var balance =   web3.Eth.GetBalance.SendRequestAsync("0xB0E8Cb105Ab63300b96aA230c9528f49dd087333");
            //// //Console.WriteLine("Receiver account balance before sending Ether: " + balance.Value + " Wei");
            // //Console.WriteLine("Receiver account balance before sending Ether: " + Web3.Convert.FromWei(balance.Value) + " Ether");

            ////// Lets transfer 1.11 Ether
            // var transaction =   web3.Eth.GetEtherTransferService().TransferEtherAndWaitForReceiptAsync(accountr.ToString(), 1.11m);

            ////balance = await web3.Eth.GetBalance.SendRequestAsync("0x13f022d72158410433cbd66f5dd8bf6d2d129924");
            ////Console.WriteLine("Receiver account balance after sending Ether: " + balance.Value);
            ////Console.WriteLine("Receiver account balance after sending Ether: " + Web3.Convert.FromWei(balance.Value) +
            ////                  " Ether");
            ///
            return newacont.ToString();
        }
    }
}