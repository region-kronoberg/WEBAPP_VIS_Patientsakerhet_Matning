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
            var professionList = new List<string> { "Sjuksköterska/Barnmorska", "Läkare", "Tandläkare", "Undersköterska/Barnskötare" };

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

        // Action för att hantera byggnader
        public IActionResult ManageBuildings()
        {
            // Sätt titeln för att aktivera korrekt menyobjekt
            ViewData["Title"] = "Manage Buildings";

            // Placeholder: aktuell lista över byggnader
            var buildingList = new List<string> { "Central Lasarettet Växjö" };

            return View("ManageBuildings", buildingList);
        }

        [HttpPost]
        public IActionResult AddBuilding(string buildingName)
        {
            if (!string.IsNullOrEmpty(buildingName))
            {
                // Lägg till logik för att lägga till byggnad
                // T.ex. spara till databas eller en lista
            }
            return RedirectToAction("ManageBuildings");
        }

        [HttpPost]
        public IActionResult RemoveBuilding(string buildingName)
        {
            if (!string.IsNullOrEmpty(buildingName))
            {
                // Lägg till logik för att ta bort byggnad
                // T.ex. ta bort från databas eller en lista
            }
            return RedirectToAction("ManageBuildings");
        }

        // Action för att hantera avdelningar
        public IActionResult ManageDepartments()
        {
            // Sätt titeln för att aktivera korrekt menyobjekt
            ViewData["Title"] = "Manage Departments";

            // Placeholder: aktuell lista över avdelningar
            var departmentList = new List<string>
{
    "Akutgeriatrisk avdelning 13",
    "Akutmottagningen Växjö",
    "Akutvårdsavdelningen",
    "Ambulansen",
    "Barn- och ungdomsavdelning 11 barn Växjö",
    "Barnmottagningen",
    "Diabetesmottagningen",
    "Endokrinmottagningen",
    "Endoskopienheten Växjö",
    "Gynekologmottagningen Växjö",
    "Hjärtmottagningen Växjö",
    "Hudmottagningen Växjö",
    "Infektionsavdelning 17",
    "Intensivvårdsavdelningen Växjö",
    "Kirurgavdelning 33",
    "Kirurgavdelning 34",
    "Kirurgmottagningen Växjö",
    "Klinisk fysiologinheten Växjö",
    "Klinisk patologi och cytologi",
    "Kliniskt kemiska laboratoriet Växjö",
    "Kvinnokliniken förlossning och slutenvård",
    "Kvinnokliniken Gynavdelning 8",
    "Kvinnokliniken Öppenvård",
    "Lasarettsrehab Växjö",
    "Lung_allergimottagningen",
    "Mag-tarmmottagningen med dagsjukvård",
    "Mammografi CLV",
    "Medicinavdelning 1 HIA",
    "Medicinavdelning 3 Växjö",
    "Medicinavdelning 4 Växjö",
    "Medicinavdelning 5 Växjö",
    "Medicinmottagningen Växjö",
    "Medicinskt fysik",
    "Medicinska dagvården o Hematologi Växjö",
    "Neonatalavdelning 10",
    "Neurolog-storkemottagningen med dagsjukvård",
    "Njurmedicinmottagningen",
    "Onkologavdelning 40",
    "Onkologklinikens dagsjukvård Växjö",
    "Operation Växjö",
    "Ortopedavdelning 19",
    "Ortopedavdelning 29",
    "Ortopedmottagningen Växjö",
    "Pre- och postoperativa avdelningen Växjö",
    "Reumatologmottagningen",
    "Röntgenenheten Växjö",
    "SHV Bemanning Växjö",
    "Smärtenheten Växjö",
    "Strålbehandlingsenheten",
    "Tandvårdsenheten",
    "Urologmottagningen Växjö",
    "Ögonmottagningen Växjö",
    "Öron- näsa- och halsmottagningen Växjö"
};


            return View("ManageDepartments", departmentList);
        }

        [HttpPost]
        public IActionResult AddDepartment(string departmentName)
        {
            if (!string.IsNullOrEmpty(departmentName))
            {
                // Lägg till logik för att lägga till avdelning
                // T.ex. spara till databas eller en lista
            }
            return RedirectToAction("ManageDepartments");
        }

        [HttpPost]
        public IActionResult RemoveDepartment(string departmentName)
        {
            if (!string.IsNullOrEmpty(departmentName))
            {
                // Lägg till logik för att ta bort avdelning
                // T.ex. ta bort från databas eller en lista
            }
            return RedirectToAction("ManageDepartments");
        }
    }
}
