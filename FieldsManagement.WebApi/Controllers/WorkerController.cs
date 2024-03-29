using FieldsManagement.Application.Commands.Users;
using FieldsManagement.Infrastructure.Queries.Workers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkerController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> Add(CreateWorker command)
    {
        await mediator.Publish(command);
        return Created(nameof(Add), null);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteWorker(id);
        await mediator.Publish(command);
        return NoContent();
    }

    [HttpGet]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> GetAll()
    {
        var workers = await mediator.Send(new GetAllWarkersQuery());
        return Ok(workers);
    }
}