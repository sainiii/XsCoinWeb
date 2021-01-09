using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XsCoinWeb
{


    public class GiftCardShape
    {

    }

    public class CountryList
    {
        public string country { get; set; }
    }


    public class GiftCard
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string Curency { get; set; }
        public string Country { get; set; }
        public string SendType { get; set; }
        public string Description { get; set; }
        public string Termscondition { get; set; }
        public string Photo { get; set; }
        public string LastDate { get; set; }
        public string IsActive { get; set; }
        public List<GiftCardAmountAmst> GiftCardAmount { get; set; }
    }
    public class GiftCardAmountAmst
    {
        public string Amount { get; set; }
    }


    public class OrderGiftCardList
    {
        public string orderID { get; set; }
        public string Productname { get; set; }
        public string Curency { get; set; }
        public string Status { get; set; }
        public string Amount { get; set; }
        public string OrderDate{ get; set; }
    }


}