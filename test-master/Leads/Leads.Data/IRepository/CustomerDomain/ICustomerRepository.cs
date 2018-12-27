using Leads.Data.Models;
using System;

namespace Leads.Data.IRepository.CustomerDomain
{
    public interface ICustomerRepository : IRepository<Customer>, IDisposable
    {
        
    }
}
