using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class IncomeType
    {
        public IncomeType()
        {
            LeadIncome = new HashSet<LeadIncome>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ICollection<LeadIncome> LeadIncome { get; set; }
    }
}
