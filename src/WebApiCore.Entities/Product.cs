using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Product
    {
        public Product()
        {
            Variant = new HashSet<Variant>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Variant> Variant { get; set; }
        public virtual Category Category { get; set; }
    }
}
