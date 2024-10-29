var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Definiera en lista med admin-anv�ndarnamn eller identifierare (statisk lista)
var adminList = new List<string> { "AdminUser1", "AdminUser2" }; // L�gg till admin-anv�ndarnamn h�r
builder.Services.AddSingleton(adminList);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Middleware f�r att s�tta en "IsAdmin"-flagga om anv�ndaren finns i adminList
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.Name ?? ""; // Anv�ndaridentifierare, exempelvis IP eller cookie kan anv�ndas h�r
    if (adminList.Contains(username))
    {
        context.Items["IsAdmin"] = true; // Lagra adminstatus i requesten
    }
    await next.Invoke();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Form}/{action=Index}/{id?}");

app.Run();
