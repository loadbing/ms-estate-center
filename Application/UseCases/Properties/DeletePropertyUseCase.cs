using ms_estate_center.Adapter.Out.Mongodb.Properties;

namespace ms_estate_center.Application.UseCases.Properties
{
    public class DeletePropertyUseCase
    {
        private readonly PropertiesRepository _repository;

        public DeletePropertyUseCase(PropertiesRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteProperty(string id)
        {
            await _repository.Delete(id);
        }
    }
}
