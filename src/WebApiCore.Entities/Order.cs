using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public string ExternalTrackingId { get; set; }
        public string TransactionStatus { get; set; }
        public string BuyerSnapshot { get; set; }
        public int BuyerId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
