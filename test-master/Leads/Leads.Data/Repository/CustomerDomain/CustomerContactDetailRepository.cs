using Leads.Data.IRepository.CustomerDomain;
using Leads.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leads.Data.Repository.CustomerDomain
{
    public class CustomerContactDetailRepository : ICustomerContactDetailRepository, IDisposable
    {
        public Task Add(CustomerContactDetail model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CustomerContactDetail model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerContactDetail>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerContactDetail> Get(int id)
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
