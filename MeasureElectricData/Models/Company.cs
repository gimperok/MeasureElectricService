using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Company
    {
        /// <summary>
        ///Идентификатор организации
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Список дочерних организаций
        /// </summary>
        public List<SubCompany>? SubCompanies { get; set; } = new List<SubCompany>();
    }
}