using MongoDB.Driver;
using OrderApi.Models;
using OrderApi.Repositories.Interfaces;
using System.Linq.Expressions;

namespace OrderApi.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        protected abstract string collectionName { get; set; }
        private readonly IMongoCollection<T> collection;

        public BaseRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
