using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class ValidatePropertyExistenceUseCase
    {
        private readonly PropertiesRepository _repository;

        public ValidatePropertyExistenceUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidatePropertyExistence(string name, string code)
        {
            Property? propertyFoundByName = await _repository.GetByName(name);
            Property? propertyFoundByCode = await _repository.GetByCode(code);

            if (propertyFoundByName != null || propertyFoundByCode != null)
                throw new ArgumentException("The property you are trying to create already exists");
        }
    }
}
