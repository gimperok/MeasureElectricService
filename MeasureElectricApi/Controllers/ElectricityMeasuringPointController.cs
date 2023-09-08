using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ElectricityMeasuringPointController : ControllerBase
    {
        private readonly IElectricityMeasuringPointRepository electricityMeasuringPointRepository;

        public ElectricityMeasuringPointController(IElectricityMeasuringPointRepository _repository)
        {
            electricityMeasuringPointRepository = _repository;
        }

        /// <summary>
        /// Получить точку измерения электроэнергии по ее id
        /// </summary>
        /// <param name="id">Идентификатор точки измерения электроэнергии</param>
        /// <returns>Объект точки измерения электроэнергии</returns>
        [HttpGet]
        public ElectricityMeasuringPoint GetElectricityMeasuringPointById(int id)
        {
            return electricityMeasuringPointRepository.GetById(id);
        }




        /// <summary>
        /// Добавить точку измерения электроэнергии
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "name" : "Точка1",
        ///     }
        ///
        /// </remarks>
        /// <param name="electricityMeasuringPoint">Объект точки измерения электроэнергии</param>
        /// <param name="consumptionObjectId">Идентификатор объекта потребления</param>
        /// <param name="typeCounter">11</param>
        /// <param name="verDateCounter">22</param>
        /// <param name="typeCurTransform"></param>
        /// <param name="verDateCurTransform"></param>
        /// <param name="ktt"></param>
        /// <param name="typeVoltTransform"></param>
        /// <param name="verDateVoltTransform"></param>
        /// <param name="ktn"></param>
        /// <returns>Идентификатор добавленной точки измерения электроэнергии</returns>
        [HttpPost]
        public int AddElectricityMeasuringPoint(ElectricityMeasuringPoint electricityMeasuringPoint, int consumptionObjectId,
                                                    string typeCounter, DateTime verDateCounter,
                                                    string typeCurTransform, DateTime verDateCurTransform, double ktt,
                                                    string typeVoltTransform, DateTime verDateVoltTransform, double ktn)
        {
            if (!ModelState.IsValid)
                return int.MinValue;
            return electricityMeasuringPointRepository.Add(electricityMeasuringPoint, consumptionObjectId,
                                                                                         typeCounter, verDateCounter,
                                                                                         typeCurTransform, verDateCurTransform, ktt,
                                                                                         typeVoltTransform, verDateVoltTransform, ktn);
        }
    }
}
