var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Definiera en lista med admin-användarnamn eller identifierare (statisk lista)
var adminList = new List<string> { "AdminUser1", "AdminUser2" }; // Lägg till admin-användarnamn här
builder.Services.AddSingleton(adminList);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Middleware för att sätta en "IsAdmin"-flagga om användaren finns i adminList
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.Name ?? ""; // Användaridentifierare, exempelvis IP eller cookie kan användas här
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
