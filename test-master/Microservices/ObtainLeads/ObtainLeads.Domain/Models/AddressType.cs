using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObtainLeads.Domain.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            EmployerAddress = new HashSet<EmployerAddress>();
            LeadAddress = new HashSet<LeadAddress>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ICollection<EmployerAddress> EmployerAddress { get; set; }
        public ICollection<LeadAddress> LeadAddress { get; set; }
    }
}
