using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Identity.Login;
using MotorcycleWebShop.Application.Identity.Register;

namespace MotorcycleWebShop.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RegisterResponseDto>> Register(RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginCommand command)
        {
            var response = await Mediator.Send(command);
            if (response == null)
            {
                return BadRequest();
            }

            if (response.IsSuccess == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
