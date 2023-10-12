using ProyectoEF;
using webapi.Middlewares;
using webapi.Services;
using static webapi.Services.HelloworldService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<TareasContext>("Data Source=GERMAN;Initial Catalog=TareasDb;user id=sa; password=1234;TrustServerCertificate=True");

// builder.Services.AddSingleton
//builder.Services.AddScoped<IHelloWorldService, HelloworldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloworldService());

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // ¿Qué son los middlewares? 11 / 22
    // Cada uno de estos son los middlewares
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

// app.UseWelcomePage();

// app.UseTimeMiddleware();

// Trae la hora
// http://localhost:5183?time

// Trae todo el get mas la hora
// http://localhost:5183/weatherforecast?time

// Cada middleware va a pasar por los request, si trae el parametro time lo trae

app.MapControllers();

app.Run();

// Consumiendo API desde Postman 6/22
// http://localhost:5183/WeatherForecast