using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGenericString<T> where T : BaseEntityString
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageindex, int pageSize);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        
    }
}