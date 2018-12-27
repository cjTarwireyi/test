using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class Employer
    {
        public Employer()
        {
            EmployerAddress = new HashSet<EmployerAddress>();
            EmployerContactDetail = new HashSet<EmployerContactDetail>();
        }

        public int Id { get; set; }
        public int? LeadsId { get; set; }
        public string EmployerName { get; set; }

        public Lead Leads { get; set; }
        public ICollection<EmployerAddress> EmployerAddress { get; set; }
        public ICollection<EmployerContactDetail> EmployerContactDetail { get; set; }
    }
}
