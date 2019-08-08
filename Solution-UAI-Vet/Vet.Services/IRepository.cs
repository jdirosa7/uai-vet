using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Services
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> GetByFilters(TEntity entity);
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
