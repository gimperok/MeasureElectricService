using MeasureElectricApi.DBService.Interfaces;
using MeasureElectricData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasureElectricApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyReporsitory companyRepository;

        public CompanyController(ICompanyReporsitory _repository)
        {
            companyRepository = _repository;
        }

        /// <summary>
        /// Получить организацию по ее id
        /// </summary>
        /// <param name="id">Идентификатор организации</param>
        /// <returns>Объект организации</returns>
        [HttpGet]
        public Company GetCompanyById(int id)
        {
            return companyRepository.GetById(id);
        }

        /// <summary>
        /// Добавить организацию
        /// </summary>
        /// <param name="company">Обьект организации</param>
        [HttpPost]
        public int AddCompany(Company company)
        {
            if (!ModelState.IsValid)
                return int.MinValue;
            return companyRepository.Add(company);
        }
    }
}
