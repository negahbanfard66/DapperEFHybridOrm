using Dapper;
using DapperEfHybridSample.Core.Entities;
using DapperEfHybridSample.Core.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DapperEfHybridSample.Infrastructure.Repositories
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            string sql = "SELECT * FROM Products";
            return await _dbConnection.QueryAsync<Product>(sql);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        // These methods are unused, as Dapper only handles reading.
        public Task CreateProductAsync(Product product) => Task.CompletedTask;
        public Task UpdateProductAsync(Product product) => Task.CompletedTask;
        public Task DeleteProductAsync(int id) => Task.CompletedTask;
    }
}
