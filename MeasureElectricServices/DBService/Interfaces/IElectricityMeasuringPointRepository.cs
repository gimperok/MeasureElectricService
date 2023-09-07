using MeasureElectricData.Models;
using MeasureElectricServices.DBService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricServices.DBService.Interfaces
{
    public interface IElectricityMeasuringPointRepository
    {
        ElectricityMeasuringPoint GetById(int id);
        int Add(ElectricityMeasuringPoint elPoint, int consumptionObjectId,
                                                    string typeCounter, DateTime verDateCounter,
                                                    string typeCurTransform, DateTime verDateCurTransform, double ktt,
                                                    string typeVoltTransform, DateTime verDateVoltTransform, double ktn);
    }
}
