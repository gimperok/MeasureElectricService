using MeasureElectricData.Models;
using MeasureElectricApi.DBService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricApi.DBService.Interfaces
{
    public interface IElectricitySupplyPointRepository
    {
        ElectricitySupplyPoint GetById(int id);
        int Add(ElectricitySupplyPoint elSupPoint, int consumptionObjectId,
                                                    bool isSettlementMeter = false);
    }
}
