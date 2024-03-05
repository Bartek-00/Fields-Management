using Amazon.Runtime.Internal;
using FieldsManagement.Application.Commands;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fields = await mediator.Send(new GetAllQuery());
        Debug.WriteLine(fields.Count);
        return Ok(fields);
    }
}