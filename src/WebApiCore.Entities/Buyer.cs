using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int CoreCustomerId { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
