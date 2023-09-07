using MeasureElectricApi;
using MeasureElectricData.Models;
using MeasureElectricApi.DBService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricApi.DBService.Implementations
{
    public class ElectricitySupplyPointRepository : IElectricitySupplyPointRepository
    {
        private readonly ApplicationContext db;

        public ElectricitySupplyPointRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public ElectricitySupplyPoint GetById(int id)
        {
            ElectricitySupplyPoint? electricitySupplyPointFromDb = new();

            if (db == null) return electricitySupplyPointFromDb;

            try
            {
                electricitySupplyPointFromDb = db.ElectricitySupplyPoints.FirstOrDefault(u => u.Id == id);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(ElectricitySupplyPoint)} с id: '{id}' из бд.\n" +
                                  $"Место: {nameof(ElectricitySupplyPointRepository)}/{nameof(GetById)} \n" +
                                  $"Error text:{e.Message}");
            }
            return electricitySupplyPointFromDb ?? new ElectricitySupplyPoint();
        }


        public int Add(ElectricitySupplyPoint entity, int consumptionObjectId, bool isSettlementMeter = false)
        {
            if (db == null) return int.MinValue;

            try
            {
                ElectricitySupplyPoint electricitySupplyPointDb = new();
                electricitySupplyPointDb.Name = entity.Name;
                electricitySupplyPointDb.ConsumptionObjectId = consumptionObjectId;

                if (isSettlementMeter)
                {
                    SettlementMeter settlementMeter = new();
                    db.SettlementMeters.Add(settlementMeter);

                    electricitySupplyPointDb.SettlementMeterId = settlementMeter.Id;
                }
                else
                    electricitySupplyPointDb.SettlementMeterId = null;

                db.ElectricitySupplyPoints.Add(electricitySupplyPointDb);

                db.SaveChanges();

                int electricitySupplyPointIdFromBd = electricitySupplyPointDb.Id;
                return electricitySupplyPointIdFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи обьекта в бд.\n" +
                                  $"Место: {nameof(ElectricitySupplyPointRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return int.MinValue;
            }
        }
    }
    
}
