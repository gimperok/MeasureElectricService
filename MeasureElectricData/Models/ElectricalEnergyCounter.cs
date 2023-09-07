using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Счетчик электрической энергии
    /// </summary>
    public class ElectricalEnergyCounter
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
        /// Тип счетчика электрической энергии
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Дата поверки
        /// </summary>
        public DateTime VerificationDate { get; set; }
    }
}
