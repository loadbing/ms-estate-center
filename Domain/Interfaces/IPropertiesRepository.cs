using ms_estate_center.Domain.Entities;

namespace ms_estate_center.Domain.Interfaces
{
    public interface IPropertiesRepository
    {
        Task<List<Property>> GetAllAsync();
        Task<Property> GetByIdAsync(string id);
        Task CreateAsync(Property property);
        Task UpdateAsync(string id, Property property);
        Task DeleteAsync(string id);
    }
}
