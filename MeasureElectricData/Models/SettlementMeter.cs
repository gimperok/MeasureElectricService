using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Расчетный прибор учета
    /// </summary>
    public class SettlementMeter
    {
        /// <summary>
        /// Идентификатор расчетного прибора учета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список точек поставок электроэнергии
        /// </summary>
        public List<ElectricitySupplyPoint>? ElectricitySupplyPointList { get; set; }
        public List<ElectricityMeasuringPoint>? ElectricityMeasuringPointList { get; set; }
    }
}
