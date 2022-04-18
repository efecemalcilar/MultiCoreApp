using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.Service.Services
{
    public class CustomerService : Service<Customer> ,ICustomerService
    {
        public CustomerService()
        {
            
        }
        
        
    }
    

    
}
