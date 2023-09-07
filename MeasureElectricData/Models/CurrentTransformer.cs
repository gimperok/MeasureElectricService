using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformer
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
        /// Тип точки измерения электроэнергии
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Дата поверки
        /// </summary>
        public DateTime VerificationDate { get; set; }

        /// <summary>
        /// Коэффициент трансформации тока
        /// </summary>
        public double KTT { get; set; }
    }
}
