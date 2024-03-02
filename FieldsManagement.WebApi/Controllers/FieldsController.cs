using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreRock.Shared.CQRS.Handlers;
using FieldsManagement.Application.Commands;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FieldsController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public FieldsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateFields command)
    {
        await _dispatcher.SendAsync(command);
        return Created();
    }
}