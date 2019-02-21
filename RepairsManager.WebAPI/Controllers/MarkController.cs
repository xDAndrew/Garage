using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly RepairsManagerContext context;
        private readonly IMapper mapper;

        public MarkController(RepairsManagerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Mark
        [HttpGet]
        public IEnumerable<MarkEndpointModel> Get()
        {
            //return null;
            return mapper.Map<IEnumerable<MarkEndpointModel>>(context.VehicleMark);
        }

        // GET: api/Mark/5
        [HttpGet("{id}", Name = "GetMark")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mark
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mark/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
