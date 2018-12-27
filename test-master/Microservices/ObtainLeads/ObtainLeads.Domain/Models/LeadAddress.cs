using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class LeadAddress
    {
        public int Id { get; set; }
        public int LeadsId { get; set; }
        public int AddressTypeId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }

        public AddressType AddressType { get; set; }
        public Lead Leads { get; set; }
    }
}
