using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer.Repository;

namespace MultiCoreApp.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MultiDbContext _db; //Dependcy Injection bu iki satır. 

        private ProductRepository _productRepository;

        private CategoryRepository _categoryRepository; 
        public UnitOfWork(MultiDbContext db)
        {
            _db = db;
        }

        public IProductRepository Product =>_productRepository ??= new ProductRepository(_db);

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_db);
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        
        
        
        public async Task CommintAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
