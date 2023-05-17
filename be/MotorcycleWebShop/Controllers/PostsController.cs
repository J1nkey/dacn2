using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.Common.Models;
using MotorcycleWebShop.Application.Manufacturers.Queries.GetAllManufacturersPaging;
using MotorcycleWebShop.Application.Posts.Commands.CreatePost;
using MotorcycleWebShop.Application.Posts.Commands.DeletePost;
using MotorcycleWebShop.Application.Posts.Commands.UpdatePost;
using MotorcycleWebShop.Application.Posts.Queries.GetBriefPost;
using MotorcycleWebShop.Application.Posts.Queries.GetBriefPostByManufacturerIdPaging;
using MotorcycleWebShop.Application.Posts.Queries.GetFilterData;
using MotorcycleWebShop.Application.Posts.Queries.GetPostById;

namespace MotorcycleWebShop.Controllers
{
    public class PostsController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public PostsController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PaginatedList<MotorcycleWebShop.Application.Posts.Queries.GetBriefPost.BriefPostDto>>> GetBriefPostPaging(int pageNumber = 1, int pageSize = 10)
        {
            var posts = await Mediator.Send(new GetBriefPostQuery { PageNumber = pageNumber, PageSize = pageSize });
            return posts;
        }

        [HttpGet("[action]")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetBriefPostByManufacturerIdPagingQueryResponse>> GetBriefPostByManufacturerIdPaging([FromQuery]int manufactuerId, int pageNumber = 1, int pageSize = 10)
        {
            var posts = await Mediator.Send(new GetBriefPostByManufacturerIdPagingQuery
            {
                ManufacturerId = manufactuerId,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            return posts;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetPostByIdQueryResponse>> GetPostById([FromQuery]GetPostByIdQuery request)
        {
            var response = await Mediator.Send(request);
            return response;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create(CreatePostCommand command)
        {
            command.UserId = _currentUserService.UserId;
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}/[action]")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(int id, UpdatePostCommand command)
        {
            if (id != command.PostId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePostCommand { PostId = id });
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPosts()
        {
            var posts = await Mediator.Send(new GetBriefPostQuery());
            var filter = await Mediator.Send(new GetFilterDataQuery());

            return Ok(posts);
        }
    }
}
