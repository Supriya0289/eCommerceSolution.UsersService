using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using AutoMapper;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastruction();
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
//fluent validation
builder.Services.AddFluentValidationAutoValidation();


//build web application
var app = builder.Build();
//exceptional Handling
app.UseExceptionaHandlingMiddleware();
//Routing
app.UseRouting();
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller
app.MapControllers();

app.Run();
