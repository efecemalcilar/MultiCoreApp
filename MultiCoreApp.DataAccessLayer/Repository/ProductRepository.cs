using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository //IProductRepository den implementasyon gerçekleşir.O yuzden Mirasi Repository den alacaz.
    {
        private MultiDbContext multiDbContext{get=>_db as MultiDbContext;} //Multicontex den nesne türettim bana getirecek şekilde _db yaptım

        public ProductRepository(MultiDbContext db) : base(db) //constructer için Db parametresi alıyorum Ve bunu base imde  db eşleştiriyorum.
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(Guid proId)
        {
            var product = _db.Products.Include(s=>s.Category).FirstOrDefaultAsync(s=>s.Id == proId);
            // Product tablomun içine categoryleride enjekte ettim.

            return (await product)!;
        }

        
    }
}
