using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WEBAPP_VIS_Patientsakerhet_Matning.Controllers;

public class AdminController : Controller
{
    public IActionResult ManageAdmins()
    {
        // Hämtar aktuell lista över admins (för tillfället en placeholder)
        var adminList = new List<string> { "admin1@example.com", "admin2@example.com" };
        return View("AdminPanel", adminList);
    }

    [HttpPost]
    public IActionResult AddAdmin(string username)
    {
        if (!string.IsNullOrEmpty(username))
        {
            // Lägg till logik för att lägga till administratör 123
        }
        return RedirectToAction("ManageAdmins");
    }

    [HttpPost]
    public IActionResult RemoveAdmin(string username)
    {
        if (!string.IsNullOrEmpty(username))
        {
            // Lägg till logik för att ta bort administratör
        }
        return RedirectToAction("ManageAdmins");
    }

    // Ny action för att hantera yrkeskategorier
    public IActionResult ManageProfessions()
    {
        // Placeholder-lista för yrken, kan bytas ut mot databaskoppling i framtiden
        var professionList = new List<string> { "Sjuksköterska", "Barnmorska", "Läkare", "Tandläkare" };
        return View("ManageProfessions", professionList);
    }

    [HttpPost]
    public IActionResult AddProfession(string professionName)
    {
        if (!string.IsNullOrEmpty(professionName))
        {
            // Lägg till logik för att lägga till yrke
        }
        return RedirectToAction("ManageProfessions");
    }

    [HttpPost]
    public IActionResult RemoveProfession(string professionName)
    {
        if (!string.IsNullOrEmpty(professionName))
        {
            // Lägg till logik för att ta bort yrke
        }
        return RedirectToAction("ManageProfessions");
    }
}
