using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class GetAllPropertiesUseCase
    {
        private readonly PropertiesRepository _repository;

        public GetAllPropertiesUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Property>> GetAllProperties()
        {
            return await _repository.GetAll();
        }
    }
}
