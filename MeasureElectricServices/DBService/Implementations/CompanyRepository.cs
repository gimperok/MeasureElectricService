using MeasureElectricApi;
using MeasureElectricData.Models;
using MeasureElectricServices.DBService.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricServices.DBService.Implementations
{
    public class CompanyRepository : ICompanyReporsitory
    {
        private readonly ApplicationContext db;

        public CompanyRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public Company GetById(int id)
        {
            Company? companyFromDb = new();

            if (db == null) return companyFromDb;

            try
            {
                companyFromDb = db.Companies.FirstOrDefault(u => u.Id == id);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(Company)} с id: '{id}' из бд.\n" +
                                  $"Место: {nameof(CompanyRepository)}/{nameof(GetById)} \n" +
                                  $"Error text:{e.Message}");
            }
            return companyFromDb ?? new Company();
        }


        public int Add(Company entity)
        {
            if (db == null) return int.MinValue;

            try
            {
                Company companyDb = new();

                companyDb.Name = entity.Name;
                companyDb.Adress = entity.Adress;

                db.Companies.Add(companyDb);
                db.SaveChanges();

                int companyIdFromBd = companyDb.Id;
                return companyIdFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи обьекта в бд.\n" +
                                  $"Место: {nameof(CompanyRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return int.MinValue;
            }
        }
    }
}