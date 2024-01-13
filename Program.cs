using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OCR_FE.Data;
using OCR_FE.Services; // Make sure to include this namespace
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext to the services
builder.Services.AddDbContext<OCRDatabseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("OCRDatabase")));

// Register your IChatGPTService here
builder.Services.AddHttpClient<IChatGPTService, ChatGPTService>();

var app = builder.Build();

// Ensure the database is created (For development purposes)
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<OCRDatabseContext>();
        dbContext.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "index.html" }
});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
