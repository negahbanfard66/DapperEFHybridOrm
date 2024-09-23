using DapperEfHybridSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEfHybridSample.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(string repositoryKey);
        Task<Product> GetProductByIdAsync(string repositoryKey,int id);
        Task CreateProductAsync(string repositoryKey,Product product);
        Task UpdateProductAsync(string repositoryKey,Product product);
        Task DeleteProductAsync(string repositoryKey,int id);
    }
}
