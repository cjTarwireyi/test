using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class LeadContactDetail
    {
        public int Id { get; set; }
        public int LeadsId { get; set; }
        public string HomeNo { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }

        public Lead Leads { get; set; }
    }
}
