using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XsCoinWeb
{
    public class UserShape
    {
    }
    public class CustomerList
    {
        public string UserID { get; set; }
        public string appmstpaid { get; set; }
        public string appmstDOJ { get; set; }
        public string appPaiddatetime { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string ProfileImage { get; set; }
        public string BTC { get; set; }
        public string AppMstRegNo { get; set; }
        public string AppmstFName { get; set; }
        public string appmststate { get; set; }
        public string appmstcity { get; set; }
        public string AppmstSponsorTotal { get; set; }
        public string appmstLeftTotal { get; set; }
        public string appmstRightTotal { get; set; }
        public string sponsorid { get; set; }
        public string newsponsortotal { get; set; }
        public string membersince { get; set; }
        public string expirydays { get; set; }
        public string LeftMember { get; set; }
        public string rightMember { get; set; }
        public string leftactivate { get; set; }
        public string rightactivate { get; set; }
        public string leftDirect { get; set; }
        public string RightDirect { get; set; }
        public string LeftPaidDirect { get; set; }
        public string RightPaidDirect { get; set; }
        public string TeamSales { get; set; }
        public string TWithDraw { get; set; }
        public string TPending { get; set; }
        public string DirectINcome { get; set; }
        public string ROI { get; set; }
        public string TeamIncome { get; set; }
        public string imagename { get; set; }
        public string MYpakage { get; set; }
        public string DAysCount { get; set; }
        public string ROICountShow { get; set; }
        public string Passowrd { get; set; }
        public string EPassowrd { get; set; }
        public string Country { get; set; }

        public string zipCode { get; set; }
        public string Type { get; set; }
        public string AccessToken { get; set; }
    }
    public class accountstatementPage
    {
        public string Amount { get; set; }
        public string PaidDetail { get; set; }
        public string BankTranBalance { get; set; }
        public string BankTranDate { get; set; }
        public string BankTranRemarks { get; set; }
        public string PType { get; set; }
        public string PName { get; set; }
        public string OutAmount { get; set; }
        public string dollar { get; set; }
    }

    public class transferreportPage
    {
        public string Amount { get; set; }
        public string BankTranDate { get; set; }
        public string PaidDetail { get; set; }

    }


    public class withdrawhistoryPage
    {
        public string Amount { get; set; }
        public string BankTranDate { get; set; }
        public string BankTranRemarks { get; set; }

    }



    public class upgradereportPage
    {
        public string Amount { get; set; }
        public string BankTranDate { get; set; }
        public string PaidDetail { get; set; }

    }



    public class referralincomePage
    {
        public string Amount { get; set; }
        public string BankTranDate { get; set; }
        public string BankTranRemarks { get; set; }
        public string OutAmount { get; set; }
        public string dollar { get; set; }

    }

    public class directreferralsPage
    {
        public string AppMstRegNo { get; set; }
        public string membername { get; set; }
        public string AppMstLeftRight { get; set; }
        public string AppMstMobile { get; set; }
        public string AppmstDOJ { get; set; }
        public string topupdate { get; set; }
        public string jamount { get; set; }
        public string Appmstpaid { get; set; }
    }

    public class downlinedetailPage
    {
        public string AppMstRegNo { get; set; }
        public string membername { get; set; }
        public string AppMstLeftRight { get; set; }
        public string AppMstMobile { get; set; }
        public string AppmstDOJ { get; set; }
        public string topupdate { get; set; }
        public string jamount { get; set; }
        public string Appmstpaid { get; set; }
    }


    public class PackageEntity
    {
        public string srno { get; set; }
        public string Pname { get; set; }
        public string Amount { get; set; }
        public string JoinFor { get; set; }
        public string Points { get; set; }
        public string isactive { get; set; }

    }
}