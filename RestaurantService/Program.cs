using RestaurantService.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers()
                .AddNewtonsoftJson(options => 
                    options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<MainContext>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();