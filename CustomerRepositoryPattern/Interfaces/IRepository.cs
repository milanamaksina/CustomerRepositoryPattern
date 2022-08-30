using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepositoryPattern.Interfaces
{
    public interface IRepository<TEntity>
    {
        public int Create(TEntity entity);
        public TEntity Read(int entityId);
        public void Update(TEntity entity);
        public void Delete(int entityId);
    }
}
