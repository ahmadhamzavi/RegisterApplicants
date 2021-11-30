using ApplicationProcess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProcess.Domain.Interfaces
{
    public interface IRepository<TEntity,TPrimaryKey> where TEntity:BaseEntity<TPrimaryKey>
    {
        public Task<TPrimaryKey> CreateAsync(TEntity entity);
        public Task<TEntity> GetAsync(TPrimaryKey Id);
        public Task<List<TEntity>> GetAllAsync();
        public Task<bool> UpdateAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);

    }
}
