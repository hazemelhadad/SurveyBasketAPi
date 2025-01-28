

using Microsoft.AspNetCore.Identity.Data;
using SurveyBaskets.BLL.Interface;

namespace SurveyBaskets.PL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthServices _authServices) : ControllerBase
    {
        private readonly IAuthServices authServices = _authServices;

        [HttpPost("")]
        public async Task<IActionResult>Login(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var result = await authServices.GetTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);
            return result is null ? BadRequest("Invalid Email/Password") : Ok(result);
        }

    }
}
