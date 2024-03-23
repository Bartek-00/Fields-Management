using FieldsManagement.Application.Commands.Operations;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Queries.Operations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Operation>> AddOperation(CreateOperation command)
    {
        await mediator.Publish(command);
        return Created(nameof(AddOperation), null);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateOperation(UpdateOperation command)
    {
        await mediator.Publish(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteOperation(Guid id)
    {
        var command = new DeleteOperation(id);
        await mediator.Publish(command);
        return NoContent();
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Operation>>> GetOperations()
    {
        var operations = await mediator.Send(new GetOperationsQuery());
        return Ok(operations);
    }

    [HttpGet("{fieldId}")]
    [Authorize]
    public async Task<ActionResult<List<Operation>>> GetOperationsByFieldId(Guid fieldId)
    {
        var operations = await mediator.Send(new GetOperationsByFieldIdQuery(fieldId));
        return Ok(operations);
    }
}