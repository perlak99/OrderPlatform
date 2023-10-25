using MongoDB.Driver;
using OrderApi.Models.Entities;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        protected override string collectionName { get; set; } = CollectionNames.Orders;

        public OrderRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
