using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class DebitObligation
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string DebtCommitment { get; set; }
        public string NameOfCreditor { get; set; }
        public decimal? TotalAmountOutstanding { get; set; }
        public string MonthlyCommitment { get; set; }

        //public Lead Lead { get; set; }
    }
}
