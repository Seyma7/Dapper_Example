using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example
{
    interface IEducationLayer<TEntity,TKey>where TEntity:class
    {
        List<TEntity> GetAll();
        bool Save(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
