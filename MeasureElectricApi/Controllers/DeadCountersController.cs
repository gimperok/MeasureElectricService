using MeasureElectricApi.DBService.Implementations;
using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeadCountersController : ControllerBase
    {
        private readonly IDeadCounter<ElectricalEnergyCounter> energyCounterRepository;
        private readonly IDeadCounter<VoltageTransformer> voltTransformRepository;
        private readonly IDeadCounter<CurrentTransformer> curTransformRepository;

        public DeadCountersController(IDeadCounter<ElectricalEnergyCounter> _repositoryEn, IDeadCounter<VoltageTransformer> _repositoryVolt,
                                                                                            IDeadCounter<CurrentTransformer> _repositoryCur)
        {
            energyCounterRepository = _repositoryEn;
            voltTransformRepository = _repositoryVolt;
            curTransformRepository = _repositoryCur;
        }


        /// <summary>
        /// Получить cчетчики электрической энергии с вышедшим сроком поверки
        /// </summary>
        /// <param name="date">Предельная дата</param>
        /// <returns>Список счетчиков электрической энергии с вышедшим сроком поверки</returns>
        [HttpGet]
        public List<ElectricalEnergyCounter> GetDeadElectricalEnergyCounters(DateTime date)
        {
            return energyCounterRepository.GetDeadCounters(date);
        }

        /// <summary>
        /// Получить трансформатор напряжения с вышедшим сроком поверки
        /// </summary>
        /// <param name="date">Предельная дата</param>
        /// <returns>Список трансформаторов напряжения с вышедшим сроком поверки</returns>
        [HttpGet]
        public List<VoltageTransformer> GetDeadVoltageTransformerCounters(DateTime date)
        {
            return voltTransformRepository.GetDeadCounters(date);
        }

        /// <summary>
        /// Получить список трансформаторов тока с вышедшим сроком поверки
        /// </summary>
        /// <param name="date">Предельная дата</param>
        /// <returns>Список трансформаторов тока с вышедшим сроком поверки</returns>
        [HttpGet]
        public List<CurrentTransformer> GetDeadCurrentTransformerCounters(DateTime date)
        {
            return curTransformRepository.GetDeadCounters(date);
        }
    }
}
