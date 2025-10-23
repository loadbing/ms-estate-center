using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class GetPropertyByIdUseCase
    {
        private readonly PropertiesRepository _repository;

        public GetPropertyByIdUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Property?> GetPropertyById(string id)
        {
            return await _repository.GetById(id);
        }
    }
}
