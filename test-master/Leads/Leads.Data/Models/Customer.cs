using System;
using System.Collections.Generic;

namespace Leads.Data.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNo { get; set; }
        public int CustomerAddressId { get; set; }
        public int CustomerContactDetailsId { get; set; }
        public int EmployerId { get; set; }

        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual CustomerContactDetail CustomerContactDetails { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
