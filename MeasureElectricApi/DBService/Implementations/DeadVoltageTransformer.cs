using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;

namespace MeasureElectricApi.DBService.Implementations
{
    public class DeadVoltageTransformer : IDeadCounter<VoltageTransformer>
    {
        private readonly ApplicationContext db;

        public DeadVoltageTransformer(ApplicationContext _db)
        {
            db = _db;
        }

        public List<VoltageTransformer> GetDeadCounters(DateTime? date)
        {
            List<VoltageTransformer>? voltageTransformerList = new();

            if (db == null) return voltageTransformerList;

            try
            {
                voltageTransformerList = db.VoltageTransformers.Where(u => u.VerificationDate < date).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения списка обьектов {nameof(VoltageTransformer)} из бд.\n" +
                                  $"Место: {nameof(DeadVoltageTransformer)}/{nameof(GetDeadCounters)} \n" +
                                  $"Error text:{e.Message}");
            }
            return voltageTransformerList ?? new List<VoltageTransformer>();
        }
    }
}
