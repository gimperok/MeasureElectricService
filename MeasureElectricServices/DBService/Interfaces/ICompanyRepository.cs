using MeasureElectricData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricServices.DBService.Interfaces
{
    public interface ICompanyReporsitory
    {
        Company GetById(int id);
        int Add(Company company);
    }
}
