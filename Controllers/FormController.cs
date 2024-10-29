using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WEBAPP_VIS_Patientsakerhet_Matning.Controllers;

    public class FormController : Controller
    {
        public IActionResult Index()
        {
            // För testning: ange isAdmin direkt till true för att ge admin-åtkomst utan begränsningar
            bool isAdmin = true;

            // Lägg till adminstatus i ViewData för att styra adminflikens synlighet i vyn
            ViewData["IsAdmin"] = isAdmin;

            return View();
        }
    }

