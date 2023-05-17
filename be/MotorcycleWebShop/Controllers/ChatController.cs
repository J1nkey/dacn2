using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Messages.Commands.CreateMessage;
using MotorcycleWebShop.Application.Messages.Queries.GetConversationOfUser;
using MotorcycleWebShop.Application.Users.Queries.GetAllUsers;

namespace MotorcycleWebShop.Controllers
{
    [Authorize]
    public class ChatController : ApiController
    {
        private readonly ICurrentUserService _userService;

        public ChatController(ICurrentUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUsersAsync()
        {
            var userId = _userService.UserId;
            var response = await Mediator.Send(new GetAllUsersQuery() { CurrentUserId = userId});

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> SaveMessageAsync(CreateMessageCommand request)
        {
            var response = await Mediator.Send(request);
            if (response > 0)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetConversationAsync(int contactId)
        {
            var currentUserId = _userService.UserId;

            var response = Mediator.Send(new GetConversationOfUserQuery
            {
                FromUserId = currentUserId,
                ToUserId = contactId
            });

            return Ok(response);
        }
    }
}
