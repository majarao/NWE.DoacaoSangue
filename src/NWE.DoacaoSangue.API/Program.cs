using NWE.DoacaoSangue.API.Middlewares;
using NWE.DoacaoSangue.Application;
using NWE.DoacaoSangue.Domain;
using NWE.DoacaoSangue.Infra;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services
    .AddDomain()
    .AddInfra(builder.Configuration)
    .AddApplication();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.UseExceptionMiddleware();

app.Run();
