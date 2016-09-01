using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class AttributeSet
    {
        public int AttributeId { get; set; }
        public int CategoryId { get; set; }
        public bool IsVariant { get; set; }
        public bool IsMandatory { get; set; }
        public byte DisplayOrder { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Category Category { get; set; }
    }
}
