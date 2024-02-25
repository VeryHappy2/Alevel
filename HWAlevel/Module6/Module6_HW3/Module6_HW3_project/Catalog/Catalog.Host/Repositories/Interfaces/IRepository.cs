using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW6.Repositories.Abstractions
{
    public interface IRepository<T> 
    {
        Task<int?> AddAsync(T entity);
        Task<int?> UpdateAsync(int id, T entity);
        Task<string> DeleteAsync(int id);
    }
}
