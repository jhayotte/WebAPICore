using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class PaymentMethod
    {
        public int MerchantId { get; set; }
        public short Code { get; set; }

        public virtual Merchant Merchant { get; set; }
    }
}
