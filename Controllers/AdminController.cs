using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WEBAPP_VIS_Patientsakerhet_Matning.Controllers
{
    public class AdminController : Controller
    {
        // Action för att hantera administratörer
        public IActionResult ManageAdmins()
        {
            // Sätt titeln för att aktivera korrekt menyobjekt
            ViewData["Title"] = "Manage Admins";

            // Placeholder: aktuell lista över administratörer
            var adminList = new List<string> { "admin1@example.com", "admin2@example.com" };

            return View("AdminPanel", adminList);
        }

        [HttpPost]
        public IActionResult AddAdmin(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                // Lägg till logik för att lägga till administratör
                // T.ex. spara till databas eller en lista
            }
            return RedirectToAction("ManageAdmins");
        }

        [HttpPost]
        public IActionResult RemoveAdmin(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                // Lägg till logik för att ta bort administratör
                // T.ex. ta bort från databas eller en lista
            }
            return RedirectToAction("ManageAdmins");
        }

        // Action för att hantera yrkeskategorier
        public IActionResult ManageProfessions()
        {
            // Sätt titeln för att aktivera korrekt menyobjekt
            ViewData["Title"] = "Manage Professions";

            // Placeholder: aktuell lista över yrkeskategorier
            var professionList = new List<string> { "Sjuksköterska", "Barnmorska", "Läkare", "Tandläkare" };

            return View("ManageProfessions", professionList);
        }

        [HttpPost]
        public IActionResult AddProfession(string professionName)
        {
            if (!string.IsNullOrEmpty(professionName))
            {
                // Lägg till logik för att lägga till yrke
                // T.ex. spara till databas eller en lista
            }
            return RedirectToAction("ManageProfessions");
        }

        [HttpPost]
        public IActionResult RemoveProfession(string professionName)
        {
            if (!string.IsNullOrEmpty(professionName))
            {
                // Lägg till logik för att ta bort yrke
                // T.ex. ta bort från databas eller en lista
            }
            return RedirectToAction("ManageProfessions");
        }
    }
}
