using System;
using System.Collections.Generic;
using System.IO;
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
        public FileStreamResult Get(int id)
        {
            var repaires = new List<WriteOffModule.Models.Repair>()
            {
                new WriteOffModule.Models.Repair() { Detail = "Автолампа А 12-5 одноконтактная", Party = "", Price = 0.50m, Unit = "шт", Reason = "Использована"},
                new WriteOffModule.Models.Repair() { Detail = "Автолампа А 12-5 без цоколя", Party = "", Price = 0.25m, Unit = "шт", Reason = "Использована на авто" },
                new WriteOffModule.Models.Repair() { Detail = "Блок контрольных ламп УАЗ Хантер правый (43.3803) 3151-20-3803010", Party = "", Price = 13.28m, Unit = "шт", Reason = "Использована" },
                new WriteOffModule.Models.Repair() { Detail = "Втулка маятника", Party = "", Price = 0.03m, Unit = "шт", Reason = "Использована" },
                new WriteOffModule.Models.Repair() { Detail = "Гидротолкатель (406-409дв) 8шт 406-1007045-51", Party = "", Price = 66.50m, Unit = "компл", Reason = "Использована" },
                new WriteOffModule.Models.Repair() { Detail = "Колодка тормоза зад.длин.", Party = "", Price = 29.67m, Unit = "шт", Reason = "Использована" },
                new WriteOffModule.Models.Repair() { Detail = "Лампа Н4 LL, 12V, 60/55 W", Party = "", Price = 15.50m, Unit = "шт", Reason = "Использована" },
                new WriteOffModule.Models.Repair() { Detail = "Лента щетки стеклоочистителя ГАЗ-3302/2108 3302-5205900", Party = "", Price = 3.20m, Unit = "шт", Reason = "Использована" },
            };

            var file = StateRepository.GetWorkOffCertificate(repaires, DateTime.Now);
            var typeFile = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            FileStreamResult result = new FileStreamResult(new MemoryStream(file), typeFile)
            {
                FileDownloadName = "Work-Off" + string.Format("{0: yyyy-MMMM-d}", DateTime.Now) + ".xlsx"
            };
            return result;
        }

        // POST: api/Vehicle
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        }
    }
}
