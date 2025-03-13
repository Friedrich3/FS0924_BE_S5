using FS0924_BE_S5.Data;
using FS0924_BE_S5.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentEmail.MailKitSmtp;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//QUI E' DOVE ANDRANNOI VARI SERVIZI TRA CUI QUELLO PER CONNETTERE DBCONTEXT CON TUTTA L'APP
builder.Services.AddDbContext<PraticaBES5>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
//AGGIUNTO SERVIZIO EMAILS
builder.Services.AddFluentEmail(builder.Configuration.GetSection("MailSettings").GetValue<string>("FromDefault"))
    .AddRazorRenderer().AddMailKitSender(new SmtpClientOptions()
    {
        Server = builder.Configuration.GetSection("MailSettings").GetValue<string>("Server"),
        Port = builder.Configuration.GetSection("MailSettings").GetValue<int>("Port"),
        User = builder.Configuration.GetSection("MailSettings").GetValue<string>("Username"),
        Password = builder.Configuration.GetSection("MailSettings").GetValue<string>("Password"),
        UseSsl = builder.Configuration.GetSection("MailSettings").GetValue<bool>("UseSSL"),
        RequiresAuthentication = builder.Configuration.GetSection("MailSettings").GetValue<bool>("RequiresAuthentication"),
    });

//DOPO LA DICHIARAZIONE DEL DBCONTEXT SI AGGIUNGONO TUTTI I SERVIZI NECESSARI
builder.Services.AddScoped<LibroServices>();
builder.Services.AddScoped<OrdineServices>();
builder.Services.AddScoped<EmailServices>();

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
