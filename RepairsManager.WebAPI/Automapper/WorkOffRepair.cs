using System;
using RepairsManager.WriteOffModule.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EntityModels = RepairsManager.Dal.Models;

namespace RepairsManager.WebAPI.Automapper
{
    public class WorkOffRepairMapper
    {
        private readonly EntityModels.RepairsManagerContext _dbContext;

        public WorkOffRepairMapper(EntityModels.RepairsManagerContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IEnumerable<Repair> GetRepairs(DateTime forDate)
        {
            var data = _dbContext.Repair.Where(x => x.RepairDate.Month == forDate.Month)
                .Include(x => x.RepairPart)
                .ThenInclude(x => x.Material)
                .ThenInclude(x => x.Party)
                .Include(x => x.RepairPart)
                .ThenInclude(x => x.Material)
                .ThenInclude(x => x.Unit)
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                .ThenInclude(x => x.Mark).ToList();
            var result = new List<Repair>();

            foreach (var item in data)
            {
                foreach (var detail in item.RepairPart)
                {
                    var row = new Repair()
                    {
                        Detail = detail.Material.Name,
                        Party = $"партия {detail.Material.Party.Number} от {detail.Material.Party.Receipt.ToString("dd.MM.yyyy hh:mm:ss")}",
                        Price = detail.Material.Party.Price,
                        Reason = $"Использована для ремонта автомобиля {item.Vehicle.Model.Mark.Name} № {item.Vehicle.RegNumber}",
                        Unit = detail.Material.Unit.Name,
                        Amount = detail.Amount
                    };
                    result.Add(row);
                }
            }

            return result;
        }
    }
}
