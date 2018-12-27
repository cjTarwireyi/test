using System;
using System.Collections.Generic;
using System.Text;

namespace ObtainLeads.Domain.Models
{
  public  class Deduction
    {
        public int Id { get; set; }
        //TODO
        public int? DeductionTypeId { get; set; }
        public decimal? Amount { get; set; }

        //public DeductionType DeductionType { get; set; }
       // public Lead Lead { get; set; }
    }
}
