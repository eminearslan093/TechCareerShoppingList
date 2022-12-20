using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechCareerShoppingList.Back.Application.CQRS.Commands;
using TechCareerShoppingList.Back.Application.CQRS.Handlers;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Tools.JwtTools;

namespace TechCareerShoppingList.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CreateUserCommandRequest request)
        {
            var control = await _mediator.Send(request);
            if (true)
            {

            }
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {


            try
            {
                var userDto = await _mediator.Send(request);
                if (userDto.IsExist)
                {
                    var token = JwtTokenGenerator.GenerateToken(userDto);
                    return Created("", token);
                }
                else
                {
                    return BadRequest("Username veya password hatalı");
                }

            }
            catch (Exception )
            {

                return BadRequest("Username veya password hatalı");
            }
        }
    }
}
