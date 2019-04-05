using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RepairsManager.WebAPI.Automapper;
using RepairsManager.WriteOffModule.Models;
using RepairsManager.WriteOffModule.Services;

namespace RepairsManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOffController : ControllerBase
    {
        public readonly WorkOffRepairMapper mapper;

        public WorkOffController(WorkOffRepairMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: api/WorkOff
        [HttpGet]
        public State Get()
        {
            return StateRepository.State;
        }

        // GET: api/WorkOff/5
        [HttpGet]
        [Route("GetDocument/{date}")]
        public FileStreamResult Get(DateTime date)
        {
            var repaires = mapper.GetRepairs(date);

            var file = StateRepository.GetWorkOffCertificate(repaires, date);
            var typeFile = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            FileStreamResult result = new FileStreamResult(new MemoryStream(file), typeFile)
            {
                FileDownloadName = $"{date.Month}/{date.Year}.xlsx"
            };
            return result;
        }

        [HttpGet]
        [Route("SetMaterials")]
        public void SetMaterials()
        {
            var file = System.IO.File.ReadAllBytes(@"11.18.xlsx");
            var items = StateRepository.SetMaterials(file);
        }

        // PUT: api/WorkOff
        [HttpPut]
        public void Put([FromBody] State value)
        {
            StateRepository.State = value;
        }
    }
}
