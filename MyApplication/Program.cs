using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

#region Db Context
builder.Services.AddDbContext<MyApplicationContext>(Options =>
{ Options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source =.;Initial Catalog=MyApplication_DB;Integrated Security=true"));});

#endregion
app.MapStaticAssets();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
