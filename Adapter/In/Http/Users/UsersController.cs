using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_estate_center.Application.UseCases.Users;
using ms_estate_center.Domain.Entities;

namespace ms_estate_center.Adapter.In.Http.Users
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ValidateUserUseCase _validateUserUseCase;

        public UsersController(ValidateUserUseCase validateUserUseCase)
        {
            _validateUserUseCase = validateUserUseCase;
        }


        [HttpPost]
        public async Task<IActionResult> Validate([FromBody] UserBody userBody)
        {
            User userData = await _validateUserUseCase.ValidateUser(userBody.Email, userBody.Password);
            return Ok(new  {Username = userData.Email, Nickname = userData.Name});
        }
    }
}
