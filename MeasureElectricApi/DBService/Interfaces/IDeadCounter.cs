namespace MeasureElectricApi.DBService.Interfaces
{
    public interface IDeadCounter<T> where T : class
    {
        List<T> GetDeadCounters(DateTime? date);
    }
}
