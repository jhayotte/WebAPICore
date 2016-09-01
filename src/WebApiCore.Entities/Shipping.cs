using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Shipping
    {
        public int OfferId { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
