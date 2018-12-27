using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObtainLeads.Domain.Models
{
  public  class LeadObligation
    {
        public int Id  { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }
        public int LeadId { get; set; }
        [ForeignKey("ObligationId")]
        public  DebitObligation DebitObligation { get; set; }
        public int ObligationId { get; set; }

    }
}
