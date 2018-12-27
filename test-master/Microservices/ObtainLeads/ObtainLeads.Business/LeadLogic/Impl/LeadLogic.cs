using AutoMapper;
using ObtainLeads.Business.AddressTypeLogic;
using ObtainLeads.Domain.Models;
using ObtainLeads.Model.DTO;
using ObtainLeads.Repository.LeadRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
 
 
namespace ObtainLeads.Business.LeadLogic.Impl
{
    public class LeadLogic : ILeadLogic
    {
        #region Properties

        private ILeadRepository _repo;
        //private IMapper

        #endregion Properties

        #region Constructor

        public LeadLogic(ILeadRepository repo)
        {
            _repo = repo;
        }

        #endregion Constructor
        public async Task Add(LeadDTO model)
        {
            try
            {
                var dbModel = Mapper.Map<Lead>(model);
                dbModel.InsertedDate = DateTime.Now;
                dbModel.UpdatedDate = DateTime.Now;
                await _repo.Add(dbModel);
                await _repo.SaveAsync();
            }
            catch(Exception e)
            {
                throw;
            }
          
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeadDTO> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeadDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(LeadDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
