using System;
using System.Collections.Generic;

namespace Leads.Data.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployerAddress { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
