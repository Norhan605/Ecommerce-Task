using Application.Contracts;
using InfaStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaStructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        public Context Context { get; }
        private readonly DbSet<TEntity> _dbSet;
        public Repository(Context context)
        {
            Context= context;
            _dbSet= context.Set<TEntity>();
        }

        public async Task<TEntity?> GetDetailsAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> CreateAsync(TEntity item)
        {
            return (await _dbSet.AddAsync(item)).Entity;
        }
        public async Task<TEntity> CreateOnDbAsync(TEntity item)
        {
            var data=await CreateAsync(item);
            await SaveChangesAsync();
            return data;
        }
        public async Task<bool> DeleteAsync(TId id)
        {
            var item= await _dbSet.FindAsync(id);
            if(item != null)
            {
                _dbSet.Remove(item);
                await SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

      
        public async Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbSet.Update(item);
            if(entity != null)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
