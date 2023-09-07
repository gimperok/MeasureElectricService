using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Сущность сопоставления точек измерения электроэнергии с расчетными приборами учета
    /// </summary>
    public class ElMesPointsSettMeters
    {
        /// <summary>
        /// Идентификатор точки измерения электроэнергии
        /// </summary>
        public int ElectricityMeasuringPointId { get; set; }

        /// <summary>
        /// Точка измерения электроэнергии
        /// </summary>
        public ElectricityMeasuringPoint ElectricityMeasuringPoint { get; set; }


        /// <summary>
        /// Идентификатор прибора учета
        /// </summary>
        public int? SettlementMeterId { get; set; }

        /// <summary>
        /// Прибор учета
        /// </summary>
        public SettlementMeter? SettlementMeter { get; set; }
    }
}
