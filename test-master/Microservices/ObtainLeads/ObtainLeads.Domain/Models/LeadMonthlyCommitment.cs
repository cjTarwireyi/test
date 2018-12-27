using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObtainLeads.Domain.Models
{
    public class LeadMonthlyCommitment
    {
        public int Id { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }
        public int LeadId { get; set; }
        [ForeignKey("MonthlyCommitmentId")]
        public MonthlyCommitment MonthlyCommitment { get; set; }
        public int MonthlyCommitmentId { get; set; }
    }
}
