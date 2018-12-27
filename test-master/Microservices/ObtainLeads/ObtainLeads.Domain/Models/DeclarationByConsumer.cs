using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class DeclarationByConsumer
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string SignedAt { get; set; }
        public DateTime Date { get; set; }
        public string Signed { get; set; }

        public Lead Lead { get; set; }
    }
}
