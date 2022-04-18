using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {

        private MultiDbContext multiDbContext {get=> _db as MultiDbContext;}

        public CustomerRepository(MultiDbContext db) : base(db)
        {

        }

        public async Task<Customer> GetWithCustomerByNameAsync(Guid cusId)
        {
            var customer = _db.Customers.Include(s => s.Customer).FirstOrDefaultAsync(s => s.Id == cusId);

            return (await customer)!;
        }





    }
}
