using MeasureElectricApi;
using MeasureElectricData.Models;
using MeasureElectricServices.DBService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricServices.DBService.Implementations
{
    public class ElectricityMeasuringPointRepository : IElectricityMeasuringPointRepository
    {
        private readonly ApplicationContext db;

        public ElectricityMeasuringPointRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public ElectricityMeasuringPoint GetById(int id)
        {
            ElectricityMeasuringPoint? electricityMeasuringPointFromDb = new();

            if (db == null) return electricityMeasuringPointFromDb;

            try
            {
                electricityMeasuringPointFromDb = db.ElectricityMeasuringPoints.FirstOrDefault(u => u.Id == id);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(ElectricityMeasuringPoint)} с id: '{id}' из бд.\n" +
                                  $"Место: {nameof(ElectricityMeasuringPointRepository)}/{nameof(GetById)} \n" +
                                  $"Error text:{e.Message}");
            }
            return electricityMeasuringPointFromDb ?? new ElectricityMeasuringPoint();
        }


        public int Add(ElectricityMeasuringPoint entity, int consumptionObjectId,
                                                    string typeCounter, DateTime verDateCounter,
                                                    string typeCurTransform, DateTime verDateCurTransform, double ktt,
                                                    string typeVoltTransform, DateTime verDateVoltTransform, double ktn)
        {
            if (db == null) return int.MinValue;

            try
            {
                ElectricityMeasuringPoint electricityMeasuringPointDb = new();
                    electricityMeasuringPointDb.Name = entity.Name;
                    electricityMeasuringPointDb.ConsumptionObjectId = consumptionObjectId;
                db.ElectricityMeasuringPoints.Add(electricityMeasuringPointDb);

                ElectricalEnergyCounter electricalEnergyCounterDb = new();
                    electricalEnergyCounterDb.Type = typeCounter;
                    electricalEnergyCounterDb.VerificationDate = verDateCounter;
                db.ElectricalEnergyCounters.Add(electricalEnergyCounterDb);

                CurrentTransformer currentTransformer = new();                    
                    currentTransformer.Type = typeCurTransform;
                    currentTransformer.VerificationDate = verDateCurTransform;
                    currentTransformer.KTT = ktt;
                db.CurrentTransformers.Add(currentTransformer);

                VoltageTransformer voltageTransformer = new();
                    voltageTransformer.Type = typeVoltTransform;
                    voltageTransformer.VerificationDate = verDateVoltTransform;
                    voltageTransformer.KTN = ktn;
                db.VoltageTransformers.Add(voltageTransformer);
                 
                db.SaveChanges();

                int electricityMeasuringPointIdFromBd = electricityMeasuringPointDb.Id;
                return electricityMeasuringPointIdFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи обьекта в бд.\n" +
                                  $"Место: {nameof(ElectricityMeasuringPointRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return int.MinValue;
            }
        }
    }
}
