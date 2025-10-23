using MongoDB.Driver;
using ms_estate_center.Domain.Entities;
using ms_estate_center.Domain.Interfaces;

namespace ms_estate_center.Adapter.Out.Mongodb.Properties
{
    public class PropertiesRepository: IPropertiesRepository
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertiesRepository(IMongoDatabase database)
        {
            _properties = database.GetCollection<Property>("properties");
        }

        public async Task<List<Property>> GetAll() =>
            await _properties.Find(_ => true).ToListAsync();

        public async Task<Property> GetById(string id) =>
            await _properties.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task Create(Property property) =>
            await _properties.InsertOneAsync(property);

        public async Task Update(string id, Property property) =>
            await _properties.ReplaceOneAsync(p => p.Id == id, property);

        public async Task Delete(string id) =>
            await _properties.DeleteOneAsync(p => p.Id == id);
    }
}
