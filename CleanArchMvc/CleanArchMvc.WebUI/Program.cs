using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

startup.Configure(app); // calling Configure method

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
