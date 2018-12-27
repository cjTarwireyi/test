using ObtainLeads.Domain.Models;
using ObtainLeads.Repository.AddressTypeRepo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObtainLeads.Business.AddressTypeLogic.Impl
{
    public class AddressTypeLogic : IAddressTypeLogic
    {
        #region Properties

        private IAddressTypeRepository _addressTypeRepository;

        #endregion Properties

        #region Constructor

        public AddressTypeLogic(IAddressTypeRepository addressTypeRepository)
        {
            _addressTypeRepository = addressTypeRepository;
        }

        #endregion Constructor

        #region Methods
        #region Public

        public async Task<IEnumerable<AddressType>> Get()
        {
            var results = await _addressTypeRepository.Get();
            return results;
        }

        public async Task<AddressType> Find(int id)
        {
            var result = await _addressTypeRepository.Find(id);
            return result;
        }

        public async Task Add(AddressType model)
        {
            try
            {
                await _addressTypeRepository.Add(model);
                await _addressTypeRepository.SaveAsync();
            } catch(Exception e)
            {
                throw e;
            }
        }

        public async Task Update(AddressType model)
        {
            try
            {
                if (!await _addressTypeRepository.Exist(model.Id))
                    throw new Exception("Record Doesn't Exist!");

                _addressTypeRepository.Update(model);
                await _addressTypeRepository.SaveAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (!await _addressTypeRepository.Exist(id))
                    throw new Exception("Record Doesn't Exist");

                await _addressTypeRepository.Delete(id);
                await _addressTypeRepository.SaveAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Public
        #endregion Methods
    }
}
