using DapperEfHybridSample.Core.Entities;
using DapperEfHybridSample.Core.Interfaces;
using DapperEfHybridSample.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEfHybridSample.Infrastructure.Repositories
{
    public class EfCoreProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public EfCoreProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync() => throw new NotImplementedException();
        public Task<Product> GetProductByIdAsync(int id) => throw new NotImplementedException();
    }
}
