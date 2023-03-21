using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AS400Project.Data;
using AS400Project.Web;

var builder = WebApplication.CreateBuilder(args);
using IHost host = Host.CreateDefaultBuilder(args).Build();
var configuration = host.Services.GetRequiredService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaulatConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("AppSettings.json", true, true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=As400}/{action=Index}/{Id?}"
    );

app.Run();
