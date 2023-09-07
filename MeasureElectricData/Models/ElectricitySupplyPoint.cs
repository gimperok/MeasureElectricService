using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class ElectricitySupplyPoint
    {
        /// <summary>
        /// Идентификатор точки поставки электроэнергии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование точки поставки электроэнергии
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Максимальная мощность точки поставки электроэнергии
        /// </summary>
        public double MaxPower { get; set; }

        /// <summary>
        /// Идентификатор объекта потребления
        /// </summary>
        public int ConsumptionObjectId { get; set; }


        /// <summary>
        /// Идентификатор расчетного прибор учета
        /// </summary>
        public int? SettlementMeterId { get; set; }

        /// <summary>
        /// Расчетный прибор учета
        /// </summary>
        public SettlementMeter? SettlementMeter { get; set; }
    }
}
