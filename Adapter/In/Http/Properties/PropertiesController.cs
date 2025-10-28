using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_estate_center.Application.UseCases.Properties;
using ms_estate_center.Domain.Entities;

namespace ms_estate_center.Adapter.In.Http.Properties
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly CreatePropertiesUseCase _createPropertiesUseCase;
        private readonly GetAllPropertiesUseCase _getAllPropertiesUseCase;
        private readonly GetPropertyByIdUseCase _getPropertyByIdUseCase;
        private readonly UpdatePropertyUseCase _updatePropertyUseCase;
        private readonly DeletePropertyUseCase _deletePropertyUseCase;

        public PropertiesController(
            CreatePropertiesUseCase createPropertiesUseCase,
            GetAllPropertiesUseCase getAllPropertiesUseCase,
            GetPropertyByIdUseCase getPropertyByIdUseCase, 
            UpdatePropertyUseCase updatePropertyUseCase, 
            DeletePropertyUseCase deletePropertyUseCase
            )
        {
            _createPropertiesUseCase = createPropertiesUseCase;
            _getAllPropertiesUseCase = getAllPropertiesUseCase;
            _getPropertyByIdUseCase = getPropertyByIdUseCase;
            _updatePropertyUseCase = updatePropertyUseCase;
            _deletePropertyUseCase = deletePropertyUseCase;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            await _createPropertiesUseCase.CreateProperty(property);
            return CreatedAtAction(nameof(GetById), new { id = property.Id }, new { id = property.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _getAllPropertiesUseCase.GetAllProperties();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var property = await _getPropertyByIdUseCase.GetPropertyById(id);
            return property is null ? NotFound() : Ok(property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Property property)
        {
            await _updatePropertyUseCase.UpdateProperty(id, property);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _deletePropertyUseCase.DeleteProperty(id);
            return Ok(id);
        }
    }
}
