using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class SubCompany
    {
        /// <summary>
        /// Идентификатор дочерней организации
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название дочерней организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес дочерней организации
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Список объектов потребления
        /// </summary>
        public List<ConsumptionObject>? ConsumptionObjects { get; set; } = new List<ConsumptionObject>();

        /// <summary>
        /// Идентификатор главной организации
        /// </summary>
        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
