using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
/// Summary description for Entity
/// </summary>

namespace XsCoinWeb
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }
        public int Sub2CatId { get; set; }
        public string Sub2CatName { get; set; }
        public double Price { get; set; }
        public double MRP { get; set; }
        public double retailer1 { get; set; }
        public double retailer2 { get; set; }
        public double retailer3 { get; set; }
        public double RedeemPoint { get; set; }
        public int Quantity { get; set; }
        public int PackSize { get; set; }
        public int PackSizeUnitId { get; set; }
        public string PackSizeName { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public int OfferType { get; set; }
        public string iName { get; set; }
        public int ProductId { get; set; }
        public int flag { get; set; }
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}