using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class LeadIncome
    {
        public int Id { get; set; }
        public int? LeadId { get; set; }
        public int? IncomeTypeId { get; set; }
        public decimal? Amount { get; set; }

        public IncomeType IncomeType { get; set; }
        public Lead Lead { get; set; }
    }
}
