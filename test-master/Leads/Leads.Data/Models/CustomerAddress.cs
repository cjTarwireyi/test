using System;
using System.Collections.Generic;

namespace Leads.Data.Models
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string PhysicalAddress { get; set; }
        public int PhysicalAddressPostalCode { get; set; }
        public string PostalAddress { get; set; }
        public int? PostalAddressPostalCode { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
