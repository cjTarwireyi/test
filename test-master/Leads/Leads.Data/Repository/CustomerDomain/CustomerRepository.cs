using Leads.Data.IRepository.CustomerDomain;
using Leads.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leads.Data.Repository.CustomerDomain
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        #region Properties

        private LeadsDemo_v1Context _leadsDemoDbContext;

        #endregion Properties

        #region Constructor

        public CustomerRepository(LeadsDemo_v1Context leadsDemoDbContext)
        {
            _leadsDemoDbContext = leadsDemoDbContext;
        }

        #endregion Constructor

        #region Methods

        #region Public Methods

        public async Task Add(Customer model)
        {
            await _leadsDemoDbContext.Customer.AddAsync(model);
        }

        public async Task Delete(Customer model)
        {
            //var customer = _leadsDemoDbContext.Find
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _leadsDemoDbContext.Customer.ToListAsync();
        }

        public Task<Customer> Get(int id)
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

        #endregion Public Methods

        #region Private Methods



        #endregion Private Methods

        #endregion Methods
    }
}
