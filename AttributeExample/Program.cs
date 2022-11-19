using AttributeExample.ActionFilters;
using AttributeExample.Models;
using AttributeExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(conf =>
{
    conf.Filters.Add<UserInformationAttribute>();
    conf.Filters.Add<BaseLoggerAttribute>();
});

builder.Services.AddLogging(conf =>
{
    conf.ClearProviders();
    conf.AddConsole();
});

    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<User>();


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
