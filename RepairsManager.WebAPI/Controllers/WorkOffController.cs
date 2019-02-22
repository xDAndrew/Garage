using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RepairsManager.WriteOffModule.Models;
using RepairsManager.WriteOffModule.Services;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOffController : ControllerBase
    {
        // GET: api/WorkOff
        [HttpGet]
        public State Get()
        {
            return StateRepository.State;
        }

        // GET: api/WorkOff/5
        [HttpGet("{date}", Name = "GetDocument")]
        [Route("GetDocument")]
        public FileStreamResult Get(DateTime date)
        {

            var repaires = new List<Repair>()
            {
                new Repair() { Detail = "Автолампа А 12-5 одноконтактная", Party = "", Price = 0.50m, Unit = "шт", Reason = "Использована"},
                new Repair() { Detail = "Автолампа А 12-5 без цоколя", Party = "", Price = 0.25m, Unit = "шт", Reason = "Использована на авто" },
                new Repair() { Detail = "Блок контрольных ламп УАЗ Хантер правый (43.3803) 3151-20-3803010", Party = "", Price = 13.28m, Unit = "шт", Reason = "Использована" },
                new Repair() { Detail = "Втулка маятника", Party = "", Price = 0.03m, Unit = "шт", Reason = "Использована" },
                new Repair() { Detail = "Гидротолкатель (406-409дв) 8шт 406-1007045-51", Party = "", Price = 66.50m, Unit = "компл", Reason = "Использована" },
                new Repair() { Detail = "Колодка тормоза зад.длин.", Party = "", Price = 29.67m, Unit = "шт", Reason = "Использована" },
                new Repair() { Detail = "Лампа Н4 LL, 12V, 60/55 W", Party = "", Price = 15.50m, Unit = "шт", Reason = "Использована" },
                new Repair() { Detail = "Лента щетки стеклоочистителя ГАЗ-3302/2108 3302-5205900", Party = "", Price = 3.20m, Unit = "шт", Reason = "Использована" },
            };

            var file = StateRepository.GetWorkOffCertificate(repaires, date);
            var typeFile = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            FileStreamResult result = new FileStreamResult(new MemoryStream(file), typeFile)
            {
                FileDownloadName = $"Акт списания №{date.Month}/{date.Year}.xlsx"
            };
            return result;
        }

        // PUT: api/WorkOff
        [HttpPut]
        public void Put([FromBody] State value)
        {
            StateRepository.State = value;
        }
    }
}
