🏥 WEBAPP_VIS_Patientsakerhet_Matning
En ASP.NET Core MVC-applikation för att förbättra patientsäkerhetsmätningar.
Applikationen ger administratörer möjlighet att hantera administratörsanvändare och yrkeskategorier, vilket underlättar rapportering och analys av följsamhet till hygienrutiner.

📑 Innehåll
🚀 Funktioner
🔧 Installation
📖 Användning
📂 Struktur
💡 Förbättringar och framtida arbete
✍️ Författare
🚀 Funktioner
Adminpanel: En central sida för administratörer att hantera andra administratörer och yrkeskategorier.
Yrkeskategorier: Administratörer kan lägga till och ta bort yrken som dynamiskt uppdateras i dropdown-menyn på huvudsidan.
Hantera administratörer: Lägga till och ta bort administratörsanvändare från systemet.
Enhetlig design: Samma sidopanel och navigering för alla adminsidor för enkel navigering.
🔧 Installation
Förutsättningar
.NET 6.0 SDK
En editor, som Visual Studio eller Visual Studio Code
Steg för installation
Klona projektet

bash
Kopiera kod
git clone https://github.com/yourusername/WEBAPP_VIS_Patientsakerhet_Matning.git
cd WEBAPP_VIS_Patientsakerhet_Matning
Öppna projektet i din editor och kontrollera appsettings.json för eventuella miljöinställningar som databaskonfigurationer.

Bygg och kör projektet

bash
Kopiera kod
dotnet build
dotnet run
Öppna applikationen på https://localhost:5001 eller http://localhost:5000.

📖 Användning
Navigera till Adminpanelen
Gå till adminpanelen där administratörer kan hantera andra användare och yrkeskategorier.

Hantera administratörer

Under Manage Admins kan du lägga till eller ta bort administratörer.
Fyll i e-post och klicka Add Admin för att lägga till, eller Remove för att ta bort.
Hantera yrkeskategorier

Under Manage Professions kan du lägga till och ta bort yrken som visas i dropdown-menyn på huvudsidan för patientsäkerhetsmätningar.
📂 Struktur
Projektet är uppbyggt enligt ASP.NET Core MVC-arkitektur med controllers, views och models.

Controllers

FormController.cs - Hanterar huvudsidan för patientsäkerhetsmätningar.
AdminController.cs - Hanterar administratörsspecifika funktioner, som att lägga till och ta bort administratörer och yrken.
Views

Views/Form/Index.cshtml - Huvudsidan för patientsäkerhetsmätningar.
Views/Admin/AdminPanel.cshtml - Adminpanelen.
Views/Admin/ManageProfessions.cshtml - Sidan för hantering av yrken.
CSS och styling

wwwroot/css/admin-style.css - Styling för adminpanelen.
💡 Förbättringar och framtida arbete
Autentisering och roller: Lägg till autentisering för att hantera olika användarrollers åtkomst.
Database Support: Koppla upp systemet mot en databas för permanent lagring av administratörer och yrkeskategorier.
Logging och Error Handling: Förbättra systemets tillförlitlighet genom loggning och bättre felhantering.
✍️ Författare
Projektet är utvecklat av