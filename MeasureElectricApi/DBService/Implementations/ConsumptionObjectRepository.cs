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
    public class ConsumptionObjectRepository : IBaseRepository<ConsumptionObject>
    {
        private readonly ApplicationContext db;

        public ConsumptionObjectRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public ConsumptionObject GetById(int id)
        {
            ConsumptionObject? consumptionObjectFromDb = new();

            if (db == null) return consumptionObjectFromDb;

            try
            {
                consumptionObjectFromDb = db.ConsumptionObjects.FirstOrDefault(u => u.Id == id);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(ConsumptionObject)} с id: '{id}' из бд.\n" +
                                  $"Место: {nameof(ConsumptionObjectRepository)}/{nameof(GetById)} \n" +
                                  $"Error text:{e.Message}");
            }
            return consumptionObjectFromDb ?? new ConsumptionObject();
        }


        public int Add(ConsumptionObject entity, int subCompanyId)
        {
            if (db == null) return int.MinValue;

            try
            {
                ConsumptionObject consumptionObjectDb = new();

                consumptionObjectDb.Name = entity.Name;
                consumptionObjectDb.Adress = entity.Adress;
                consumptionObjectDb.SubCompanyId = subCompanyId;

                db.ConsumptionObjects.Add(consumptionObjectDb);
                db.SaveChanges();

                int consumptionObjectIdFromBd = consumptionObjectDb.Id;
                return consumptionObjectIdFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи обьекта в бд.\n" +
                                  $"Место: {nameof(ConsumptionObjectRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return int.MinValue;
            }
        }
    }
}
