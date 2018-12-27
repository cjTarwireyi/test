using Leads.Data.IRepository.CustomerDomain;
using Leads.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leads.Data.Repository.CustomerDomain
{
    public class CustomerAddressRepository : ICustomerAddressRepository, IDisposable
    {
        public Task Add(CustomerAddress model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CustomerAddress model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAddress>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddress> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
