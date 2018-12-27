using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObtainLeads.Domain.Models;

namespace ObtainLeads.Repository.AddressTypeRepo.Impl
{
    public class AddressTypeRepository : IAddressTypeRepository
    {
        #region Properties

        private ObtainLeadsContext _obtainLeadsContext;
        private bool _disposed = false;

        #endregion Properties

        #region Constructor

        public AddressTypeRepository(ObtainLeadsContext obtainLeadsContext)
        {
            _obtainLeadsContext = obtainLeadsContext;
        }

        #endregion Constructor

        #region Methods
        #region Public
        
        public async Task<System.Collections.Generic.IEnumerable<AddressType>> Get()
        {
            return await _obtainLeadsContext.AddressType.ToListAsync();
        }

        public async Task<AddressType> Find(int id)
        {
            return await _obtainLeadsContext.AddressType.FindAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            var result = await _obtainLeadsContext.AddressType.AnyAsync(t => t.Id == id);
            return result;
        }

        public async Task Add(AddressType addressType)
        {
            await _obtainLeadsContext.AddressType.AddAsync(addressType);
        }

        public void Update(AddressType addressType)
        {
            _obtainLeadsContext.Entry(addressType).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            AddressType addressType = await _obtainLeadsContext.AddressType.FindAsync(id);
            _obtainLeadsContext.AddressType.Remove(addressType);
        }

        public async Task SaveAsync()
        {
            await _obtainLeadsContext.SaveChangesAsync();
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


        #endregion Public

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
            if(!_disposed)
            {
                if (disposing)
                {
                    _obtainLeadsContext.Dispose();
                }
            }
        }

        #endregion Protected
        #endregion Methods
    }
}
