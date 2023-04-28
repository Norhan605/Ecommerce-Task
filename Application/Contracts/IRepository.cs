using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRepository<TEntity,TId> where TEntity:class
    {
       Task <TEntity>? GetDetailsAsync(TId id); // Get by Id
        Task <TEntity> CreateAsync(TEntity item);
       Task<bool> UpdateAsync(TEntity item);
        Task<bool> DeleteAsync(TId id);

        Task<int> SaveChangesAsync();

    }
}
