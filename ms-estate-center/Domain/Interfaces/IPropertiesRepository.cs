using ms_estate_center.Domain.Entities;

namespace ms_estate_center.Domain.Interfaces
{
    public interface IPropertiesRepository
    {
        Task<List<Property>> GetAll();
        Task<Property> GetById(string id);
        Task<Property> GetByCode(string code);
        Task<Property> GetByName(string name);
        Task Create(Property property);
        Task Update(string id, Property property);
        Task Delete(string id);
    }
}
