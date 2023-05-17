using Microsoft.AspNetCore.Mvc;
using MotorcycleWebShop.Application.Navigation.Commands.CreateNavigationBarItem;
using MotorcycleWebShop.Application.Navigation.Queries.GetHierarchyNavbarItems;

namespace MotorcycleWebShop.Controllers
{
    [Route("/api/navigation/[action]")]
    public class NavigationBarItemsController : ApiController
    {
        [HttpGet()]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetHierarchyNavbarItems()
        {
            var response = await Mediator.Send(new GetHierarchyNavbarItemsQuery());

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> CreateNavbarItem(CreateNavigationBarItemCommand request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}
