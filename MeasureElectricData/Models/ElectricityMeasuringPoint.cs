using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricData.Models
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class ElectricityMeasuringPoint
    {
        /// <summary>
        /// Идентификатор точки измерения электроэнергии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование точки измерения электроэнергии
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Счетчик электрической энергии
        /// </summary>
        public ElectricalEnergyCounter EnergyCounter { get; set; }

        /// <summary>
        /// Трансформатор тока
        /// </summary>
        public CurrentTransformer CurrentTransformer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VoltageTransformer VoltageTransformer { get; set; }

        /// <summary>
        /// Трансформатор напряжения
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        public ConsumptionObject ConsumptionObject { get; set; }

        public List<SettlementMeter> SettlementMeters { get; set; } = new();
    }
}
