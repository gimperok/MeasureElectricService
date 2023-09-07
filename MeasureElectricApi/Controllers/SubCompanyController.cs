using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCompanyController : ControllerBase
    {
        private readonly IBaseRepository<SubCompany> subCompanyRepository;

        public SubCompanyController(IBaseRepository<SubCompany> _repository)
        {
            subCompanyRepository = _repository;
        }

        /// <summary>
        /// Получить дочернюю организацию по ее id
        /// </summary>
        /// <param name="id">Идентификатор дочерней организации</param>
        /// <returns>Объект дочерней организации</returns>
        [HttpGet]
        public SubCompany GetSubCompanyById(int id)
        {
            return subCompanyRepository.GetById(id);
        }

        /// <summary>
        /// Добавить дочернюю организацию
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
        /// <param name="subCompany">Обьект дочерней организации</param>
        /// <param name="companyId">Идентификатор главной организации</param>
        [HttpPost]
        public int AddSubCompany(SubCompany subCompany, int companyId)
        {
            if (!ModelState.IsValid)
                return int.MinValue;
            return subCompanyRepository.Add(subCompany, companyId);
        }
    }
}
