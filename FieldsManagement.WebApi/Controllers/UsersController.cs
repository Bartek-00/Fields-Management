using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Application.DTO;
using FieldsManagement.Application.Security;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator mediator, ITokenStorage tokenStorage) : ControllerBase
{
    [Authorize(Policy = "is-admin")]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<UserDto>> Get(Guid userId)
    {
        var user = await mediator.Send(new GetUser { UserId = userId });
        return Ok(user);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<User>> Get()
    {
        if (string.IsNullOrWhiteSpace(User.Identity?.Name))
        {
            return NotFound();
        }

        var userId = Guid.Parse(User.Identity?.Name);
        var user = await mediator.Send(new GetUser { UserId = userId });

        return user;
    }

    [HttpGet]
    [SwaggerOperation("Get list of all the users")]
    [Authorize(Policy = "is-admin")]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get([FromQuery] GetUsers query)
        => Ok(await mediator.Send(query));

    [HttpPost]
    [SwaggerOperation("Create the user account")]
    public async Task<ActionResult> Post(SignUp command)
    {
        command = command with { UserId = Guid.NewGuid() };
        await mediator.Publish(command);
        return CreatedAtAction(nameof(Get), new { command.UserId }, null);
    }

    [HttpPost("sign-in")]
    [SwaggerOperation("Sign in the user and return the JSON Web Token")]
    public async Task<ActionResult<JwtDto>> Post(SignIn command)
    {
        await mediator.Publish(command);
        var jwt = tokenStorage.Get();
        return jwt;
    }
}