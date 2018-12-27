using System;
using System.Collections.Generic;

namespace ObtainLeads.Domain.Models
{
    public partial class EmployerContactDetail
    {
        public int Id { get; set; }
        public int? EmployerId { get; set; }
        public string WorkNo { get; set; }
        public string Email { get; set; }

        public Employer Employer { get; set; }
    }
}
