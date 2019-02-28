using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairsManager.Dal.Models;
using RepairsManager.WebAPI.Models;
using RepairsManager.WriteOffModule.Services;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly RepairsManagerContext context;
        private readonly IMapper mapper;

        public VehicleController(RepairsManagerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Vehicle
        [HttpGet]
        public IEnumerable<VehicleEndpointModel> Get()
        {
            var vehicles = context.Vehicle.Include(x => x.Model).ThenInclude(y => y.Mark);
            var result = mapper.Map<IEnumerable<VehicleEndpointModel>>(vehicles);
            return result;
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}", Name = "GetVehicle")]
        public void Get(int id)
        {
            
        }

        // POST: api/Vehicle
        [HttpPost]
        public int Post([FromBody] VehicleEndpointModel value)
        {
            var entity = mapper.Map<Vehicle>(value);
            context.Vehicle.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = context.Vehicle.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
