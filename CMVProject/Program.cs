using CMVProject.Controllers;
using CMVProject.DataBase;
using CMVProject.Units;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<CMVContext>();
builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<ProductController>();
builder.Services.AddScoped<UnitOfWork>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.s
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();