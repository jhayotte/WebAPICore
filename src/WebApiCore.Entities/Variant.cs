using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Variant
    {
        public Variant()
        {
            AttributeVariant = new HashSet<AttributeVariant>();
            Offer = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string StandartIdentificationNunber { get; set; }
        public int ProductId { get; set; }

        public virtual ICollection<AttributeVariant> AttributeVariant { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual Product Product { get; set; }
    }
}
