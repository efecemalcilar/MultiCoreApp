﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService         //Service de ki product nesnesi üzerinden miras alacak IProductService üzerinden implementasyonu alacak.
    {
        public ProductService(IUnitOfWork unit, IRepository<Product> repo) : base(unit, repo)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(Guid proId)
        {
            return await _unit.Product.GetWithCategoryByIdAsync(proId);
        }
    }
}
