using Microsoft.OpenApi.Models;
using Sales.API.Extensions;
using Sales.Application;
using Sales.Infrastructure;
using Sales.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

//General config
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales.API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options => options.AddPolicy(name: "SalesOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales.API v1"));
}

//Migrate SQL Server database
app.MigrateDatabase<SalesContext>((context, services) =>
{
    var logger = services.GetService<ILogger<SalesContextSeed>>();
    SalesContextSeed.SeedAsync(context, logger).Wait();
});

app.UseCors("SalesOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
