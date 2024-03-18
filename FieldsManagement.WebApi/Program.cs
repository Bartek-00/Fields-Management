using FieldsManagement.Application.Commands;
using FieldsManagement.Core.Entities;
using FieldsManagement.Infrastructure.Extensions;
using FieldsManagement.Infrastructure.Queries.Handlers;
using FieldsManagement.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FieldsManagement.Application.Commands.Fields.Handlers;
using FieldsManagement.Application.Commands.Fields;
using FieldsManagement.Application.Commands.Operations;
using FieldsManagement.Application.Commands.Operations.Handlers;
using FieldsManagement.Application.Commands.Users.Handlers;
using FieldsManagement.Application.Commands.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()
    );

builder.Services.AddScoped<INotificationHandler<CreateField>, CreateFieldHandler>();
builder.Services.AddScoped<INotificationHandler<DeleteField>, DeleteFieldHandler>();
builder.Services.AddScoped<INotificationHandler<UpdateField>, UpdateFieldsHandler>();
builder.Services.AddScoped<INotificationHandler<UpdateOperation>, UpdateOperationHandler>();
builder.Services.AddScoped<INotificationHandler<CreateOperation>, CreateOperationHandler>();
builder.Services.AddScoped<INotificationHandler<DeleteOperation>, DeleteOperationHandler>();
builder.Services.AddScoped<INotificationHandler<CreateWorker>, CreateWorkerHandler>();
builder.Services.AddScoped<INotificationHandler<DeleteWorker>, DeleteWorkerHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:3000"));
});

var app = builder.Build();

app.UseCors("AllowOrigin");

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