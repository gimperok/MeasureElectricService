using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConsumptionObjectController : ControllerBase
    {
        private readonly IBaseRepository<ConsumptionObject> consumptionObjectRepository;

        public ConsumptionObjectController(IBaseRepository<ConsumptionObject> _repository)
        {
            consumptionObjectRepository = _repository;
        }

        /// <summary>
        /// Получить объект потребления по его id
        /// </summary>
        /// <param name="id">Идентификатор объекта потребления</param>
        /// <returns>Объект потребления</returns>
        [HttpGet]
        public ConsumptionObject GetConsumptionObjectById(int id)
        {
            return consumptionObjectRepository.GetById(id);
        }

        /// <summary>
        /// Добавить объект потребления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "name" : "ООО Комп1",
        ///        "adress" : "г.Москва"
        ///     }
        ///
        /// </remarks>
        /// <param name="consumptionObject">Обьект потребления</param>
        /// <param name="subCompanyId">Идентификатор дочерней организации</param>
        [HttpPost]
        public int AddConsumptionObject(ConsumptionObject consumptionObject, int subCompanyId)
        {
            if (!ModelState.IsValid)
                return int.MinValue;
            return consumptionObjectRepository.Add(consumptionObject, subCompanyId);
        }
    }
}
