using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepositoryPattern.Interfaces
{
    public interface IRepository<TEntity>
    {
        int Create(TEntity entity);
        TEntity Read(int entityId);
        void Update(TEntity entity);
        void Delete(int entityId);
    }
}
