using MeasureElectricApi.DBService.Implementations;
using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ElectricitySupplyPointController : ControllerBase
    {
        private readonly IElectricitySupplyPointRepository electricitySupplyPointRepository;

        public ElectricitySupplyPointController(IElectricitySupplyPointRepository _repository)
        {
            electricitySupplyPointRepository = _repository;
        }

        /// <summary>
        /// Получить точку поставки электроэнергии по ее id
        /// </summary>
        /// <param name="id">Идентификатор точки поставки электроэнергии</param>
        /// <returns>Объект точки поставки электроэнергии</returns>
        [HttpGet]
        public ElectricitySupplyPoint GetElectricitySupplyPointById(int id)
        {
            return electricitySupplyPointRepository.GetById(id);
        }

        /// <summary>
        /// Добавить точку поставки электроэнергии
        /// </summary>
        /// <param name="elSupPoint">Объект точки поставки электроэнергии</param>
        /// <param name="consumptionObjectId">Идентификатор объекта потребления</param>
        /// <param name="isSettlementMeter">Наличие расчетного прибора</param>
        /// <returns>Идентификатор добавленной точки поставки электроэнергии</returns>
        [HttpPost]
        public int Add(ElectricitySupplyPoint elSupPoint, int consumptionObjectId, bool isSettlementMeter = false)
        {
            return electricitySupplyPointRepository.Add(elSupPoint, consumptionObjectId, isSettlementMeter);
        }
    }
}
