using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;

namespace MeasureElectricApi.DBService.Implementations
{
    public class DeadCurrentTransformer : IDeadCounter <CurrentTransformer>
    {
        private readonly ApplicationContext db;

        public DeadCurrentTransformer(ApplicationContext _db)
        {
            db = _db;
        }

        public List<CurrentTransformer> GetDeadCounters(DateTime? date)
        {
            List<CurrentTransformer>? currentTransformerList = new();

            if (db == null) return currentTransformerList;

            try
            {
                currentTransformerList = db.CurrentTransformers.Where(u => u.VerificationDate < date).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения списка обьектов {nameof(CurrentTransformer)} из бд.\n" +
                                  $"Место: {nameof(DeadCurrentTransformer)}/{nameof(GetDeadCounters)} \n" +
                                  $"Error text:{e.Message}");
            }
            return currentTransformerList ?? new List<CurrentTransformer>();
        }
    }
}
