using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class AttributeVariant
    {
        public int VariantId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
