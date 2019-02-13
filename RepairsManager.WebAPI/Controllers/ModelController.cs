using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairsManager.Dal.Context;
using RepairsManager.WebAPI.Models;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly RepairsManagerContext context;
        private readonly IMapper mapper;
        public ModelController(RepairsManagerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        // GET: api/Model
        [HttpGet]
        public IEnumerable<ModelVehicleEndpoint> Get()
        {
            return mapper.Map<IEnumerable<ModelVehicleEndpoint>>(context.VehicleModel);
        }

        // GET: api/Model/5
        [HttpGet("{id}", Name = "GetModel")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Model
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Model/5
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
