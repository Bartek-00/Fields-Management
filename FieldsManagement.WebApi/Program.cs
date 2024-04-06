using FieldsManagement.Application.Commands;
using FieldsManagement.Application.Commands.Fields;
using FieldsManagement.Application.Commands.Fields.Handlers;
using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Application.Commands.Login.Handler;
using FieldsManagement.Application.Commands.Operations;
using FieldsManagement.Application.Commands.Operations.Handlers;
using FieldsManagement.Application.Commands.Users;
using FieldsManagement.Application.Commands.Users.Handlers;
using FieldsManagement.Infrastructure.Extensions;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Include a security scheme for bearer token authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
});
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
builder.Services.AddScoped<INotificationHandler<SignIn>, SignInHandler>();
builder.Services.AddScoped<INotificationHandler<SignUp>, SignUpHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000", "https://localhost:7138", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }