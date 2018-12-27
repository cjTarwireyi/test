using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class MonthlyCommitment
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string Commitment { get; set; }
        public decimal MonthlyExpense { get; set; }

        //public Lead Lead { get; set; }
    }
}
