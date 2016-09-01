using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributeSet = new HashSet<AttributeSet>();
            AttributeVariant = new HashSet<AttributeVariant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public string Unit { get; set; }
        public bool IsHidden { get; set; }

        public virtual ICollection<AttributeSet> AttributeSet { get; set; }
        public virtual ICollection<AttributeVariant> AttributeVariant { get; set; }
    }
}
