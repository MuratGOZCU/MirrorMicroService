using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Mirror.Service.Discount.Services;
using Mirror.Service.Discount.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IDiscountService, DiscountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}
app.UseStaticFiles();



app.MapRazorPages();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();