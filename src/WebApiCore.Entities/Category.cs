using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Category
    {
        public Category()
        {
            AttributeSet = new HashSet<AttributeSet>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }
        public byte DisplayOrder { get; set; }
        public int? CoreCategoryId { get; set; }

        public virtual ICollection<AttributeSet> AttributeSet { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
