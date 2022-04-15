﻿using MultiCoreApp.Core.IntRepository;
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

        protected readonly MultiDbContext _db;

        private readonly DbSet<T> _dbSet; // DbSet T ye _dbset dedim.

        public Repository(MultiDbContext db) //ctorf+tab MultiDbContex den context nesnesini çağırıyorum. context sınıfından ne geliyorsa onu _db ye atıyorum.
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async  Task AddAsync(T entity) //Geri dönüş değeri beklemiyoruz. Task yerine normalini yazcak olsam void yazmak zorundayım, o yuzden return yok
        {
             await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.FirstOrDefaultAsync(predicate))!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
             //Asenkron çalıştığım için 1. kural async public sonrasına yazmak

            /* return await _db.Set<T>().ToListAsync();*/    // Her senkron methoda karşılık asenkron bir method daha var.
             //database e gidip ilgili sınıfa gidiyorum sonra database den liste halinde istiyorum veriyi.
            
             return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            //return (await _db.Set<T>().FindAsync(id))!; Eski hali
            return (await _dbSet.FindAsync(id))!;
        }

        public async Task<IQueryable<T>> QListAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.SingleOrDefaultAsync(predicate))!; // await Bu sorgunun sonucu gerçekleeşene kadar bekle demek
        }

        public T Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
