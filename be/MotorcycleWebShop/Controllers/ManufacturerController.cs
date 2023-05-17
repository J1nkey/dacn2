using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Common.Models;
using MotorcycleWebShop.Application.Manufacturers.Commands.CreateManufacturer;
using MotorcycleWebShop.Application.Manufacturers.Commands.DeleteManufacturerById;
using MotorcycleWebShop.Application.Manufacturers.Commands.UpdateManufacturer;
using MotorcycleWebShop.Application.Manufacturers.Queries.GetAllManufacturersPaging;
using MotorcycleWebShop.Application.Manufacturers.Queries.GetManufacturerBriefPaging;

namespace MotorcycleWebShop.Controllers
{
    public class ManufacturerController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ManufacturerItemDto>>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            return await Mediator.Send(new GetAllManufacturersPagingQuery(pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateManufacturerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteManufacturerByIdCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(int id, UpdateManufacturerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PaginatedList<ManufacturerBriefDto>>> GetManufacturerBriefPaging(
            [FromQuery]GetManufacturerBriefPagingQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
