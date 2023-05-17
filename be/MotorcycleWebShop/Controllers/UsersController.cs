using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Users.Commands.RegisterAsProvider;
using MotorcycleWebShop.Application.Users.Queries.GetUserProfile;

namespace MotorcycleWebShop.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> RegisterAsProvider(int id, RegisterAsProviderCommand command)
        {
            if (id != command.UserId)
            {
                return BadRequest();
            }

            var providerId = await Mediator.Send(command);
            return Ok(providerId);
        }

        [HttpGet("/users/{id}")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserProfileDto>> Profile(int id)
        {
            var response = await Mediator.Send(new GetUserProfileQuery { UserId = id });
            return response;
        }
    }
}
