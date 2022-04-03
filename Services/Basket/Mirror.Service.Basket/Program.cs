using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Mirror.Service.Basket.Redis;
using Mirror.Service.Basket.Services;
using Mirror.Service.Basket.Settings;

var builder = WebApplication.CreateBuilder(args);


var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddSingleton<IBasketService, BasketService>();
builder.Services.Configure<RedisSetting>(configuration.GetSection("Redis"));

builder.Services.AddSingleton<IRedisSetting>(conf =>
{
    return conf.GetRequiredService<IOptions<IRedisSetting>>().Value;
});

builder.Services.AddSingleton<RedisManager>(sp =>
{
    var rdsSetting = sp.GetRequiredService<IOptions<RedisSetting>>().Value;
    var redis = new RedisManager(rdsSetting.Host, rdsSetting.Port);
    redis.Connect();
    return redis;
});



//builder.Services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

//builder.Services.AddSingleton<IDatabaseSettings>(conf =>
//{
//    return conf.GetRequiredService<IOptions<DatabaseSettings>>().Value;
//});

// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorPages();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

