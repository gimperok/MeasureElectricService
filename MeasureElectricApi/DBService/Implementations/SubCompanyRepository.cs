using MeasureElectricApi;
using MeasureElectricData.Models;
using MeasureElectricApi.DBService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeasureElectricApi.DBService.Implementations
{
    public class SubCompanyRepository : IBaseRepository<SubCompany>
    {
        private readonly ApplicationContext db;

        public SubCompanyRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public SubCompany GetById(int id)
        {
            SubCompany? subCompanyFromDb = new();

            if (db == null) return subCompanyFromDb;

            try
            {
                subCompanyFromDb = db.SubCompanies.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(SubCompany)} с id: '{id}' из бд.\n" +
                                  $"Место: {nameof(SubCompanyRepository)}/{nameof(GetById)} \n" +
                                  $"Error text:{e.Message}");
            }
            return subCompanyFromDb ?? new SubCompany();
        }


        public int Add(SubCompany entity, int companyId)
        {
            if (db == null) return int.MinValue;

            try
            {
                SubCompany subCompanyDb = new();

                subCompanyDb.Name = entity.Name;
                subCompanyDb.Adress = entity.Adress;
                subCompanyDb.CompanyId = companyId;

                db.SubCompanies.Add(subCompanyDb);
                db.SaveChanges();

                int subCompanyIdFromBd = subCompanyDb.Id;
                return subCompanyIdFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи обьекта в бд.\n" +
                                  $"Место: {nameof(SubCompanyRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return int.MinValue;
            }
        }
    }
}
