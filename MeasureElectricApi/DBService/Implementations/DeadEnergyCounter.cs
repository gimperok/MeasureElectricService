using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;

namespace MeasureElectricApi.DBService.Implementations
{
    public class DeadEnergyCounter : IDeadCounter<ElectricalEnergyCounter>
    {
        private readonly ApplicationContext db;

        public DeadEnergyCounter(ApplicationContext _db)
        {
            db = _db;
        }

        public List<ElectricalEnergyCounter> GetDeadCounters(DateTime? date)
        {
            List<ElectricalEnergyCounter>? electricalEnergyCounterList = new();

            if (db == null) return electricalEnergyCounterList;

            try
            {
                electricalEnergyCounterList = db.ElectricalEnergyCounters.Where(u => u.VerificationDate < date).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения списка обьектов {nameof(ElectricalEnergyCounter)} из бд.\n" +
                                  $"Место: {nameof(DeadVoltageTransformer)}/{nameof(GetDeadCounters)} \n" +
                                  $"Error text:{e.Message}");
            }
            return electricalEnergyCounterList ?? new List<ElectricalEnergyCounter>();
        }
    }
}
