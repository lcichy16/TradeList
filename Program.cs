using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TradeList.Data;
using TradeList.Models;

var builder = WebApplication.CreateBuilder(args);

// Pobieramy connection string z konfiguracji (np. appsettings.json lub user-secrets)
var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");

// Dodajemy DbContext z SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Konfiguracja Identity - Zarz¹dzanie u¿ytkownikami, has³ami itp.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Opcjonalnie wymuszenie potwierdzenia konta
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();  // Dodajemy obs³ugê tokenów, np. do resetowania hase³

// Konfiguracja autoryzacji za pomoc¹ Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; // Ustawienie Google jako domyœlnego schematu autentykacji
})
.AddCookie()  // Cookie Auth dla ciasteczek
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// U¿ywanie middleware do autentykacji i autoryzacji
app.UseAuthentication();  // W³¹cza middleware do autentykacji
app.UseAuthorization();   // W³¹cza middleware do autoryzacji

// Mapowanie tras MVC (kontrolery i widoki)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uruchomienie aplikacji
app.Run();
