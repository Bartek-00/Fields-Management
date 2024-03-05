using FieldsManagement.Application.Commands;
using FieldsManagement.Application.Commands.Handlers;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Extensions;
using FieldsManagement.Infrastructure.Queries.Handlers;
using FieldsManagement.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()
    );

builder.Services.AddScoped<IRequestHandler<GetAllQuery, List<Fields>>, GetAllQueryHandler>();
builder.Services.AddScoped<INotificationHandler<CreateFields>, CreateFieldsHandler>();

var app = builder.Build();

app.UseSwagger(c => { c.RouteTemplate = "/swagger/{documentName}/swagger.json"; });
app.UseSwaggerUI(o =>
{
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Webrock API v1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }