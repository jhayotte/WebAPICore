using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string PictureUrl { get; set; }
        public string Properties { get; set; }
        public int VariantId { get; set; }
        public int MerchantId { get; set; }
        public int ShippingId { get; set; }

        public virtual Shipping Shipping { get; set; }
        public virtual Merchant Merchant { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
