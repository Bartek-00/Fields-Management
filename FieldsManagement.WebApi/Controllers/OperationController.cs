using FieldsManagement.Application.Commands.Operations;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Queries.Operations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Operation>> AddOperation(CreateOperation command)
    {
        await mediator.Publish(command);
        return Created(nameof(AddOperation), null);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateOperation(UpdateOperation command)
    {
        await mediator.Publish(command);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOperation([FromQuery] ObjectId id)
    {
        var command = new DeleteOperation(id);
        await mediator.Publish(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<Operation>>> GetOperations()
    {
        var operations = await mediator.Send(new GetOperationsQuery());
        return Ok(operations);
    }

    [HttpGet("{fieldId}")]
    public async Task<ActionResult<List<Operation>>> GetOperationsByFieldId(ObjectId fieldId)
    {
        var operations = await mediator.Send(new GetOperationsByFieldIdQuery(fieldId));
        return Ok(operations);
    }
}