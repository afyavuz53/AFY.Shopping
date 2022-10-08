using Afy.Shopping.DAL.Abstract;
using Afy.Shopping.Model.Entities;
using Afy.Shopping.Model.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.DAL.Concrete
{
    internal class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IOptions<ShoppingDatabaseSettings> shoppingDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            shoppingDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                shoppingDatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<Product>(
                shoppingDatabaseSettings.Value.ProductsCollectionName);
        }
        public async Task<ICollection<Product>> GetAsync() =>
        await _productCollection.Find(_ => true).ToListAsync();
        public async Task<ICollection<Product>> GetAsync(Expression<Func<Product, bool>> filter) =>
        await _productCollection.Find(filter).ToListAsync();

        public async Task<Product?> GetAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product newProduct) =>
            await _productCollection.InsertOneAsync(newProduct);

        public async Task UpdateAsync(string id, Product updatedProduct) =>
            await _productCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        public async Task RemoveAsync(string id) =>
            await _productCollection.DeleteOneAsync(x => x.Id == id);
    }
}
