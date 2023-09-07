using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Трансформатор напряжения
    /// </summary>
    public class VoltageTransformer
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
        /// Тип трансформатора напряжения
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Дата поверки
        /// </summary>
        public DateTime VerificationDate { get; set; }

        /// <summary>
        /// Коэффициент трансформатора напряжения
        /// </summary>
        public double KTN { get; set; }
    }
}
