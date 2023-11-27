using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TrincaChurras.API;
using TrincaChurras.Application;
using TrincaChurras.Infra.Data.Contexts;
using TrincaChurras.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyInjector.Register(builder.Services);

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingEntities());
});
builder.Services.AddSingleton(config.CreateMapper());

//builder.Services.AddDbContext<TrincaChurrasContext>(options =>
//                 options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
//                     b => b.MigrationsAssembly("Catalogames.API")));

builder.Services.AddDbContext<TrincaChurrasContext>(options => 
                options.UseCosmos(builder.Configuration["CosmosDb:ConnectionString"], databaseName: "DbChurrasco"));

builder.Services.AddEventStore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
