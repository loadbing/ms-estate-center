using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class CreatePropertiesUseCase
    {
        private readonly PropertiesRepository _repository;
        private readonly ValidatePropertyExistenceUseCase _validatePropertyExistenceUseCase;


        public CreatePropertiesUseCase(PropertiesRepository repository, ValidatePropertyExistenceUseCase validatePropertyExistenceUseCase)
        {
            _repository = repository;
            _validatePropertyExistenceUseCase = validatePropertyExistenceUseCase;
        }

        public async Task CreateProperty(Property property)
        {
            if (string.IsNullOrWhiteSpace(property.Name))
                throw new ArgumentException("The property name is required.");
            
            if (string.IsNullOrWhiteSpace(property.Code))
                throw new ArgumentException("The property code is required.");

            await _validatePropertyExistenceUseCase.ValidatePropertyExistence(property.Name, property.Code);
                
            await _repository.Create(property);
        }
    }
}
