using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XsCoinWeb.shapes
{
    public class RegisterShape
    {
        public string SponsorId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public string SKey { get; set; }
        public string OTP { get; set; }
        public string RegNO { get; set; }
        public string country { get; set; }
    }

    public class UpdateShape
    {
        public string Regno { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
        public string zipCode { get; set; }
        public string BTC { get; set; }
        public string SKey { get; set; }
        public string AppmstFName { get; set; }
    }
}