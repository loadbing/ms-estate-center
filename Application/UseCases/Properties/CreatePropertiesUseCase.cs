using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class CreatePropertiesUseCase
    {
        private readonly PropertiesRepository _repository;

        public CreatePropertiesUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProperty(Domain.Entities.Property property)
        {
            if (string.IsNullOrWhiteSpace(property.Name))
                throw new ArgumentException("El nombre de la propiedad es obligatorio.");

            await _repository.Create(property);
        }
    }
}
