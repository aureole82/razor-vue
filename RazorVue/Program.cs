using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorVue.Data;

var builder = WebApplication.CreateBuilder(args);

#region Configure services.

// Add services to the container.
var services = builder.Services;

builder.Services
    .AddDbContext<EditorDbContext>(options =>
        options
            .UseSqlServer(builder.Configuration.GetConnectionString("EditorDbContext"))
            .EnableSensitiveDataLogging()
    );

services.AddRazorPages();

#endregion Configure services.

#region Configure HTTP request pipeline.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

#endregion Configure HTTP request pipeline.

app.Run();