using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int OfferId { get; set; }
        public short Quantity { get; set; }
        public string TrackingSatus { get; set; }
        public string ExternalTrackingId { get; set; }
        public int MerchantId { get; set; }
        public string OfferSnapshot { get; set; }

        public virtual Order Order { get; set; }
    }
}
