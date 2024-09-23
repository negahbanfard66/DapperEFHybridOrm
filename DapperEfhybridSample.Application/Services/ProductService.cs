using DapperEfHybridSample.Core.Entities;
using DapperEfHybridSample.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DapperEfhybridSample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProductService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string repositoryKey)
        {
            var repository = _serviceProvider.GetRequiredKeyedService<IProductRepository>(repositoryKey);
            return await repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(string repositoryKey, int id)
        {
            var repository = _serviceProvider.GetRequiredKeyedService<IProductRepository>(repositoryKey);
            return await repository.GetProductByIdAsync(id);
        }

        public async Task CreateProductAsync(string repositoryKey, Product product)
        {
            var repository = _serviceProvider.GetRequiredKeyedService<IProductRepository>(repositoryKey);
            await repository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(string repositoryKey, Product product)
        {
            var repository = _serviceProvider.GetRequiredKeyedService<IProductRepository>(repositoryKey);
            await repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(string repositoryKey, int id)
        {
            var repository = _serviceProvider.GetRequiredKeyedService<IProductRepository>(repositoryKey);
            await repository.DeleteProductAsync(id);
        }
    }
}
