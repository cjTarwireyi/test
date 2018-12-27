using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class DeductionType
    {
        public DeductionType()
        {
            LeadDeduction = new HashSet<LeadDeduction>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ICollection<LeadDeduction> LeadDeduction { get; set; }
    }
}
