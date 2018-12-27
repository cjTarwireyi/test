using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class Lead
    {
        public Lead()
        {
            LeadObligation = new HashSet<LeadObligation>();
            DeclarationByConsumer = new HashSet<DeclarationByConsumer>();
            Employer = new HashSet<Employer>();
            LeadAddress = new HashSet<LeadAddress>();
            LeadContactDetails = new HashSet<LeadContactDetail>();
            LeadDeduction = new HashSet<LeadDeduction>();
            LeadIncome = new HashSet<LeadIncome>();
            LeadMonthlyCommitment = new HashSet<LeadMonthlyCommitment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sent { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<LeadObligation> LeadObligation { get; set; }
        public ICollection<DeclarationByConsumer> DeclarationByConsumer { get; set; }
        public ICollection<Employer> Employer { get; set; }
        public ICollection<LeadAddress> LeadAddress { get; set; }
        public ICollection<LeadContactDetail> LeadContactDetails { get; set; }
        public ICollection<LeadDeduction> LeadDeduction { get; set; }
        public ICollection<LeadIncome> LeadIncome { get; set; }
        public ICollection<LeadMonthlyCommitment> LeadMonthlyCommitment { get; set; }
    }
}
