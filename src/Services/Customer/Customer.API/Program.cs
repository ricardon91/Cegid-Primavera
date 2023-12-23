using Customers.API.Extensions;
using Customers.Application;
using Customers.Infrastructure;
using Customers.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

//General config
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers.API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options => options.AddPolicy(name: "CustomerOrigins",
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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers.API v1"));
}

//Migrate SQL Server database
app.MigrateDatabase<CustomerContext>((context, services) =>
{
    var logger = services.GetService<ILogger<CustomerContextSeed>>();
    CustomerContextSeed.SeedAsync(context, logger).Wait();
});

app.UseCors("CustomerOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
