using Leads.Data.Models;
using System;

namespace Leads.Data.IRepository.CustomerDomain
{
    public interface ICustomerContactDetailRepository : IRepository<CustomerContactDetail>, IDisposable
    {
        
    }
}
