using Application.Contracts;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.FilterCategories;
using FluentValidation;
using InfaStructure;
using InfaStructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
{
   // options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
}
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(FilterCategoriesQuery).Assembly); });
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(UpdateCategoryCommand).Assembly); });
builder.Services.AddValidatorsFromAssembly((typeof(FilterCategoriesQuery).Assembly));
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
