using System.Net;

using ChainMetrics.Domain.Exceptions;
using ChainMetrics.Infra.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();
builder.Services.AddDbContextConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder.Configuration["Cors:PolicyName"] ??
    throw new AppException("Cors: PolicyName is null!", HttpStatusCode.InternalServerError));

app.UseAuthorization();

app.MapControllers();

app.Run();
