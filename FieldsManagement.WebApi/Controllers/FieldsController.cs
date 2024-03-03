using Microsoft.AspNetCore.Mvc;
using CoreRock.Shared.CQRS.Handlers;
using FieldsManagement.Application.Commands;

namespace FieldsManagement.WebApi.Controllers;

[Route("api/v1/[controller]")]
public class FieldsController : Controller
{
    private readonly IDispatcher _dispatcher;

    public FieldsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(CreateFields command)
    {
        await _dispatcher.SendAsync(command);
        return Created();
    }
}