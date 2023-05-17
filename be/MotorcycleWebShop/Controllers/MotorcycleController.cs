using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Common.Models;
using MotorcycleWebShop.Application.Motorcycles.Commands.CreateMotorcycle;
using MotorcycleWebShop.Application.Motorcycles.Commands.DeleteMotorcycle;
using MotorcycleWebShop.Application.Motorcycles.Commands.UpdateMotorcycleDetail;
using MotorcycleWebShop.Application.Motorcycles.Queries.GetAllMotorcycles;

namespace MotorcycleWebShop.Controllers
{
    public class MotorcycleController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<MotorcycleBriefItemDto>>> GetAllMotorcycleBriefPaging(int pageNumber = 1, int pageSize = 10)
        {
            return await Mediator.Send(new GetAllMotorcycleBriefQuery(pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMotorcycleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(int id, UpdateMotorcycleDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMotorcycleCommand(id));

            return NoContent();
        }
    }
}
