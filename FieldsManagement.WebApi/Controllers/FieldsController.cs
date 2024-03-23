using FieldsManagement.Application.Commands;
using FieldsManagement.Application.Commands.Fields;
using FieldsManagement.Infrastructure.Queries;
using FieldsManagement.Infrastructure.Queries.Fields;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FieldsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> Add(CreateField command)
    {
        await mediator.Publish(command);
        return Created(nameof(Add), null);
    }

    [HttpPut]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> Update(UpdateField command)
    {
        await mediator.Publish(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "is-admin")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteField(id);
        await mediator.Publish(command);
        return NoContent();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var fields = await mediator.Send(new GetAllFieldsQuery());
        return Ok(fields);
    }

    [HttpGet("Village/{VillageName}")]
    [Authorize]
    public async Task<IActionResult> GetByVillage([FromRoute] string VillageName)
    {
        var fields = await mediator.Send(new GetFieldsByVillageQuery(VillageName));
        return Ok(fields);
    }

    [HttpGet("action")]
    [Authorize]
    public async Task<IActionResult> GetByAction()
    {
        var fields = await mediator.Send(new GetAllFieldsWithOperationQuery());
        return Ok(fields);
    }
}