using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    public class ConsumptionObject
    {
        /// <summary>
        /// Идентификатор объекта потребления
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование объекта потребления
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адресс объекта потребления
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Список точек измерения электроэнергии
        /// </summary>
        public List<ElectricityMeasuringPoint>? ElectricityMeasuringPoints { get; set; } = new List<ElectricityMeasuringPoint>();

        /// <summary>
        /// Список точек поставок электроэнергии
        /// </summary>
        public List<ElectricitySupplyPoint>? ElectricitySupplyPoints { get; set; } = new List<ElectricitySupplyPoint>();

        /// <summary>
        /// Идентификатор дочерней организации
        /// </summary>
        public int SubCompanyId { get; set; }

        public SubCompany SubCompany { get; set; }
    }
}