using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElectricApi.DBService.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        int Add(T entity, int ownEntityId);
    }
}
