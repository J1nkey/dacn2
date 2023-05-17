using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.MotorcycleTypes.Commands.CreateMotorycleType;
using MotorcycleWebShop.Application.MotorcycleTypes.Queries.GetMotorcycleTypes;

namespace MotorcycleWebShop.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class MotorcycleTypesController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetMotorcycleTypesQueryResponse>> GetMotorcycleTypes()
        {
            var response = await Mediator.Send(new GetMotorcycleTypesQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateMotorcycleType([FromForm]CreateMotorcycleTypeCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
