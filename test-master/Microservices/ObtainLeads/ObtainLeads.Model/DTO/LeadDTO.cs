using System;
using System.Collections.Generic;
using System.Text;

namespace ObtainLeads.Model.DTO
{
    public class LeadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sent { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
