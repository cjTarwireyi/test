using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObtainLeads.Domain.Models;

namespace ObtainLeads.Repository.LeadRepo.Impl
{
    public class LeadRepository : ILeadRepository, IDisposable
    {
        #region Properties
        private ObtainLeadsContext _obtainLeadsContext;
        private bool _disposed = false;

        #endregion Properties

        #region Constructor

        public LeadRepository(ObtainLeadsContext obtainLeadsContext)
        {
            _obtainLeadsContext = obtainLeadsContext;
        }
        #endregion Constructor
        #region CRUD
        public async Task Add(Lead entity)
        {
            await _obtainLeadsContext.Lead.AddAsync(entity);

        }

        public async Task Delete(int id)
        {
            var addressType = await _obtainLeadsContext.Lead.FindAsync(id);
            _obtainLeadsContext.Remove(addressType);
           
        }


        public async Task<bool> Exist(int id)
        {
            return await _obtainLeadsContext.Lead.AnyAsync(a => a.Id == id);
        }

        public async Task<Lead> Find(int id)
        {
            return await _obtainLeadsContext.Lead.FindAsync(id);
        }

        public async Task<IEnumerable<Lead>> Get()
        {
            return await _obtainLeadsContext.Lead.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _obtainLeadsContext.SaveChangesAsync();
        }

        public void Update(Lead entity)
        {
            _obtainLeadsContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Implement IDisposable.
        /// Do not make this method virtual.
        /// A Derived class should not be able to override this method.
        /// Reference Microsoft Docs.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            /*
             * This object will be cleaned up by the dispose method.
             * Therefore, you should call GC.SupressFinalize to take this object off the finalization queue
             * and prevent finalization code for this object from executing a second time.
             * Reference Microsoft Docs.
             */
            GC.SuppressFinalize(this);
        }
        #region Protected

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly or indirectly by a user's code.
        /// Managed and unmanaged resourses can be disposed.
        /// If disposing equals false, the method has been called by the runtime from inside the finalizer and 
        /// you should not reference other objects.
        /// Only unmanaged resources can be disposed
        /// </summary>
        /// <param name="disposing">If disposing equals true, dispose all managed and unmananged resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _obtainLeadsContext.Dispose();
                }
            }
        }

        #endregion Protected

        #endregion CRUD

    }
}
