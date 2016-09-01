using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Address
    {
        public int BuyerId { get; set; }
        public int Id { get; set; }
        public byte AddressType { get; set; }
        public string Value { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
