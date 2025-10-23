using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class UpdatePropertyUseCase
    {
        private readonly PropertiesRepository _repository;

        public UpdatePropertyUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateProperty(string id, Domain.Entities.Property property)
        {
            await _repository.Update(id, property);
        }
    }
}
