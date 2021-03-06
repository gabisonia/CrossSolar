using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Repository
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task<int> InsertAsync(T entity);

        Task UpdateAsync(T entity);
    }
}