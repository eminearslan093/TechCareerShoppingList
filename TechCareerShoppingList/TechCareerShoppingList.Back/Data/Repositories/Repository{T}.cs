using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Context;
using TechCareerShoppingList.Back.Tools;

namespace TechCareerShoppingList.Back.Data.Repositories
{
    //Generic Repository Pattern, “genel” yapıyı oluşturmamızı sağlıyor.<T>
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DBContext _dBContext;
        private static readonly AsyncLock _Locker;


        static Repository()
        {
            _Locker = new AsyncLock(); 

        }
        public Repository(DBContext dBContext)
        {
            _dBContext = dBContext;

        }

        public override bool Equals(object? obj)
        {
            return obj is Repository<T> repository &&
                   EqualityComparer<DBContext>.Default.Equals(_dBContext, repository._dBContext);
        }

        public override int GetHashCode()
        {
            var hashCode = HashCode.Combine(_dBContext);
            return hashCode;
        }

        public async Task CreateAsync(T entity)
        {
            using (await _Locker.LockAsync())
            {
                await _dBContext.Set<T>().AddAsync(entity);
                await _dBContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            using (await _Locker.LockAsync())
            {
                //asNoTtracking ile entity yi izlemiyoruz.
                //Veri tabanındaki değişikliklerle ilgilenmiyoruz.
                //bude bize performans sağlıyor.Get işlemlerinde kullanılır.

                var data = await _dBContext.Set<T>().AsNoTracking().ToListAsync();
                return data;
            }
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using (await _Locker.LockAsync())
            {
                return await _dBContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            using (await _Locker.LockAsync())
            {
                return await _dBContext.Set<T>().FindAsync(id);

            }
        }
        public async Task RemoveAsync(T entity)
        {
            using (await _Locker.LockAsync())
            {
                _dBContext.Set<T>().Remove(entity);
                await _dBContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (await _Locker.LockAsync())
            {
                _dBContext.Set<T>().Update(entity);
                await _dBContext.SaveChangesAsync();
            }
        }
    }
}
