using Microsoft.Extensions.Options;
using Mirror.Service.Catalog.Congifration;
using Mirror.Service.Catalog.Services.CategoryService;
using Microsoft.OpenApi.Models;
using Mirror.Service.Catalog.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);


var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();


builder.Services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(conf =>
{
    return conf.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(Program));


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

