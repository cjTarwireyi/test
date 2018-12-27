using Leads.Data.Models;
using System;

namespace Leads.Data.IRepository.CustomerDomain
{
    public interface ICustomerAddressRepository : IRepository<CustomerAddress>, IDisposable
    {
    }
}
