using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Configuration;
using Pon.Site.Net.Api.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddDbContext<PonSiteApiContext>(options =>
{
    var accountEndpoint = builder.Configuration.GetValue<string>("CosmosDb:EndpointUri");
    var accountKey = builder.Configuration.GetValue<string>("CosmosDb:PrimaryKey");
    options.UseCosmos(accountEndpoint, accountKey, databaseName: "ToDoList");
    options.UseLazyLoadingProxies();
    options.LogTo(Console.WriteLine, LogLevel.Debug);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
