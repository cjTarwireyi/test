using Microsoft.Extensions.DependencyInjection;
using ObtainLeads.Business.AddressTypeLogic;
using ObtainLeads.Business.AddressTypeLogic.Impl;
using ObtainLeads.Business.LeadLogic.Impl;
using ObtainLeads.Domain.Models;
using ObtainLeads.Repository.AddressTypeRepo;
using ObtainLeads.Repository.AddressTypeRepo.Impl;
using ObtainLeads.Repository.LeadRepo;
using ObtainLeads.Repository.LeadRepo.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtainLeads.API.Config.DI
{
    public static class DIConfig
    {
        public static void RegisterDI(IServiceCollection services)
        {
            RegisterAPI(services);                                  // Register API layer DI's
            RegisterBusiness(services);                             // Register Business layer DI's
            RegisterDomain(services);                               // Register Domain layer DI's
            RegisterModel(services);                                // Register Models DI's
            RegisterRepository(services);                           // Register Repository DI's
            RegisterMapper(services);
        }

        /// <summary>
        /// Register all dependency injections related to the API layer project.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        private static void RegisterAPI(IServiceCollection services)
        {
        }

        /// <summary>
        /// Register all dependency injections related to the Business layer project
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        private static void RegisterBusiness(IServiceCollection services)
        {
            services.AddScoped<IAddressTypeLogic, AddressTypeLogic>();
            services.AddScoped<ILeadLogic, LeadLogic>();
        }

        /// <summary>
        /// Register all dependency injections related to the Domain layer project.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        private static void RegisterDomain(IServiceCollection services)
        {
            services.AddScoped<ObtainLeadsContext, ObtainLeadsContext>();
        }

        /// <summary>
        /// Register all dependency injections related to the Model Layer project
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        private static void RegisterModel(IServiceCollection services)
        {

        }

        /// <summary>
        /// Register all dependency injections related to the Repository layer project
        /// </summary>
        /// <param name="repositories">Specifies the contract for a collection of service descriptors</param>
        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
            services.AddScoped<ILeadRepository,LeadRepository>();
        }

        private static void RegisterMapper(IServiceCollection services)
        {
          // services.AddAutoMapper();
        }
    }
}
