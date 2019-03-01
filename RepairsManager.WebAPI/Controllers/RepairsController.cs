using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly RepairsManagerContext context;
        private readonly IMapper mapper;

        public RepairsController(RepairsManagerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Repairs
        [HttpGet]
        public IEnumerable<RepairEndpointModel> Get()
        {
            var entities = context.Repair
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                .ThenInclude(x => x.Mark)
                .ToList();
            var result = mapper.Map<IEnumerable<RepairEndpointModel>>(entities);
            return result;
        }

        // GET: api/Repairs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Repairs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Repairs/5
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
