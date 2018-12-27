using System;
using System.Collections.Generic;

namespace Leads.Data.Models
{
    public partial class CustomerContactDetail
    {
        public CustomerContactDetail()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string HomeNo { get; set; }
        public string CellNo { get; set; }
        public string WorkNo { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
