using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Slides.Commands.CreateSlide;
using MotorcycleWebShop.Application.Slides.Queries.GetSlides;

namespace MotorcycleWebShop.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class SlidesController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetSlidesQueryResponse>> GetSlides()
        {
            var response = await Mediator.Send(new GetSlidesQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> CreateSlide([FromForm]CreateSlideCommand request)
        {
            var response = await Mediator.Send(request);
            if (response > 0)
            {
                return Ok(response);
            }

            return BadRequest();
        }
    }
}
