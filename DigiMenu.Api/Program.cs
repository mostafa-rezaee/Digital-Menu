using Common.Application;
using Common.Application.Utilities.File.Services;
using Common.NetCore;
using Common.NetCore.Utilities;
using Common.Query;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Api.Infrastructure.JWT;
using DigiMenu.Config;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(option => {
    option.InvalidModelStateResponseFactory = (context => {

        var result = new ApiResult()
        {
            IsSuccess = false,
            MetaData = new()
            {
                StatusCode = ResponseStatusCode.BadRequest,
                Message = ModelState.GetModelStateErrors(context.ModelState)
            }
        };

        return new BadRequestObjectResult(result);
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cs = builder.Configuration.GetConnectionString("DigiMenuConnectionString");
builder.Services.RegisterDigiMenuDependency(cs);
builder.Services.RegisterApiDependency();
CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
