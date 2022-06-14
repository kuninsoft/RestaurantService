using RestaurantService.Models;
using RestaurantService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddTransient(typeof(IRepository<Dish>), typeof(Repository<Dish>));
// builder.Services.AddTransient<IRepository<Restaurant>, Repository<Restaurant>>();
// builder.Services.AddTransient<IRepository<RestaurantDish>, Repository<RestaurantDish>>();
// builder.Services.AddTransient<IRepository<Rating>, Repository<Rating>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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