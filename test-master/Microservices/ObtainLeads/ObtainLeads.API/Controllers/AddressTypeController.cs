
using Microsoft.AspNetCore.Mvc;
using ObtainLeads.Business.AddressTypeLogic;
using ObtainLeads.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObtainLeads.API.Controllers
{
    [Route("api/addressType")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private IAddressTypeLogic _addressTypeLogic;

        public AddressTypeController(IAddressTypeLogic addressTypeLogic)
        {
            _addressTypeLogic = addressTypeLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressType>>> Get()
        {
            return Ok(await _addressTypeLogic.Get());
        }

        [HttpGet("{1}")]
        public async Task<ActionResult<AddressType>> Find(int id)
        {
            return Ok(await _addressTypeLogic.Find(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddressType model)
        {
            await _addressTypeLogic.Add(model);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AddressType model)
        {
            await _addressTypeLogic.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressTypeLogic.Delete(id);
            return Ok();
        }
    }
}
