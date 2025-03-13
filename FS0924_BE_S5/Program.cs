using FS0924_BE_S5.Data;
using FS0924_BE_S5.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//QUI E' DOVE ANDRANNOI VARI SERVIZI TRA CUI QUELLO PER CONNETTERE DBCONTEXT CON TUTTA L'APP
builder.Services.AddDbContext<PraticaBES5>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//DOPO LA DICHIARAZIONE DEL DBCONTEXT SI AGGIUNGONO TUTTI I SERVIZI NECESSARI
builder.Services.AddScoped<LibroServices>();
builder.Services.AddScoped<OrdineServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
