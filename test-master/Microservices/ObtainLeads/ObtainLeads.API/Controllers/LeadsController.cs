using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObtainLeads.Model.DTO;
using ObtainLeads.Business.AddressTypeLogic;

namespace ObtainLeads.API.Controllers
{
    [Route("api/leads")]
    [ApiController]
    public class LeadsController :ControllerBase
    {
         private ILeadLogic _logic;
        public LeadsController(ILeadLogic logic)
        {
            _logic = logic;
        }
        public IActionResult GetLeads()
        {
            var rec = new { id = 1, name = "cj" };
            return Ok(rec);
        }
        [HttpPost]
        public IActionResult Post([FromBody] LeadDTO newLead)
        {
            if (newLead == null)
            {
                return BadRequest();
            }
            _logic.Add(newLead);
            return Ok(true);
        }
    }
}
