using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechCareerShoppingList.Back.Application.CQRS.Queries;

namespace TechCareerShoppingList.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ShoppingListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingLists()
        {
            var result = await _mediator.Send(new GetAllShoppingListQueryRequest());
            return Ok(result);
        }
    }
}
