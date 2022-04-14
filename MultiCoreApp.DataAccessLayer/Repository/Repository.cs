using MultiCoreApp.Core.IntRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T:class //Oluşturmuş oldugum sanal yapıyı buraya getiriyorum.
    {
        /*private MultiDbContext _context = new MultiDbContext(); */// Sistem artık buna kızıyor.

        private readonly MultiDbContext _db;

        private readonly DbSet<T> _dbSet; // DbSet T ye _dbset dedim.

        public Repository(MultiDbContext db, DbSet<T> dbSet) //ctorf+tab MultiDbContex den context nesnesini çağırıyorum. context sınıfından ne geliyorsa onu _db ye atıyorum.
        {
            _db = db;
            _dbSet = dbSet;
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
             //Asenkron çalıştığım için 1. kural async public sonrasına yazmak

            /* return await _db.Set<T>().ToListAsync();*/    // Her senkron methoda karşılık asenkron bir method daha var.
             //database e gidip ilgili sınıfa gidiyorum sonra database den liste halinde istiyorum veriyi.
            
             return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //return (await _db.Set<T>().FindAsync(id))!; Eski hali
            return (await _dbSet.FindAsync(id))!;
        }

        public Task<IQueryable<T>> QListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
