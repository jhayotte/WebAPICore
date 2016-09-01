using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            Offer = new HashSet<Offer>();
            PaymentMethod = new HashSet<PaymentMethod>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Emails { get; set; }
        public string LogoUrl { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }
    }
}
