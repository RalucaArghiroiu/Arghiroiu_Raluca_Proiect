using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Arghiroiu_Raluca_Proiect.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
    {
        options.Conventions.AuthorizeFolder("/Organizations");
        options.Conventions.AuthorizeFolder("/Fleets");
        options.Conventions.AuthorizeFolder("/Vehicles");
        options.Conventions.AuthorizeFolder("/VehicleDocuments");
        options.Conventions.AuthorizeFolder("/Users");
        options.Conventions.AuthorizeFolder("/Invoices");
        options.Conventions.AuthorizeFolder("/Bookings");
    });

builder.Services.AddDbContext<Arghiroiu_Raluca_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Arghiroiu_Raluca_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Arghiroiu_Raluca_ProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Arghiroiu_Raluca_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Arghiroiu_Raluca_ProiectContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
