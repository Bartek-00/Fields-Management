using Amazon.Runtime.Internal;
using FieldsManagement.Application.Commands;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;

namespace FieldsManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FieldsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateFields command)
    {
        await mediator.Publish(command);
        return Created(nameof(Add), null);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateFields command)
    {
        await mediator.Publish(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteFields(id);
        await mediator.Publish(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fields = await mediator.Send(new GetAllQuery());
        return Ok(fields);
    }

    [HttpGet("Village/{VillageName}")]
    public async Task<IActionResult> GetByVillage([FromRoute] string VillageName)
    {
        var fields = await mediator.Send(new GetByVillageQuery(VillageName));
        return Ok(fields);
    }
}