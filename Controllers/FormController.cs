using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WEBAPP_VIS_Patientsakerhet_Matning.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            // För testning: ange isAdmin direkt till true för att ge admin-åtkomst utan begränsningar
            bool isAdmin = true;

            // Om du vill använda en verklig kontroll för adminstatus, ersätt med något i stil med:
            // bool isAdmin = User.Identity != null && User.Identity.IsAuthenticated && User.IsInRole("Admin");

            // Lägg till adminstatus i ViewData för att styra adminflikens synlighet i vyn
            ViewData["IsAdmin"] = isAdmin;

            // Sätt en titel för att markera aktuell sida i layouten
            ViewData["Title"] = "Homepage";

            return View();
        }
    }
}
