using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObtainLeads.Domain.Models
{
    public partial class LeadDeduction
    {
        public int Id { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }
        public int? LeadId { get; set; }
        [ForeignKey("DeductionId")]
        public Deduction Deduction { get; set; }
        public int? DeductionId { get; set; }
       
    }
}
