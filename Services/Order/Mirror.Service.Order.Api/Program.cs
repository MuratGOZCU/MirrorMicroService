using Mirror.Service.Order.Data.Context;
using Mirror.Service.Order.Manager.Instrafactor;
using Mirror.Service.Order.Manager.Service;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDbContext<MirrorDbContext>(op =>
{
    op.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
});

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

