// Simulerad admin-kontroll - sätt denna till true om användaren är admin
const isAdmin = true; // Ändra till false för att dölja adminfunktioner

// Göm eller visa adminfunktioner beroende på om användaren är admin
document.addEventListener('DOMContentLoaded', () => {
    const adminButtons = document.querySelectorAll('.admin-only'); // Lägg till klassen 'admin-only' på element för admins

    if (isAdmin) {
        adminButtons.forEach(button => button.style.display = 'block');
    } else {
        adminButtons.forEach(button => button.style.display = 'none');
    }
});

const search = document.querySelector('.input-group input'),
    table_rows = document.querySelectorAll('tbody tr'),
    table_headings = document.querySelectorAll('thead th');

// 1. Sökfunktion för HTML-tabellen
search.addEventListener('input', searchTable);

function searchTable() {
    table_rows.forEach((row, i) => {
        let table_data = row.textContent.toLowerCase(),
            search_data = search.value.toLowerCase();

        row.classList.toggle('hide', table_data.indexOf(search_data) < 0);
        row.style.setProperty('--delay', i / 25 + 's');
    });

    document.querySelectorAll('tbody tr:not(.hide)').forEach((visible_row, i) => {
        visible_row.style.backgroundColor = (i % 2 === 0) ? 'transparent' : '#0000000b';
    });
}

// 2. Sortering av tabellen när man klickar på rubrikerna
table_headings.forEach((head, i) => {
    let sort_asc = true;
    head.onclick = () => {
        table_headings.forEach(head => head.classList.remove('active'));
        head.classList.add('active');

        document.querySelectorAll('td').forEach(td => td.classList.remove('active'));
        table_rows.forEach(row => {
            row.querySelectorAll('td')[i].classList.add('active');
        });

        head.classList.toggle('asc', sort_asc);
        sort_asc = head.classList.contains('asc') ? false : true;

        sortTable(i, sort_asc);
    };
});

function sortTable(column, sort_asc) {
    [...table_rows].sort((a, b) => {
        let first_row = a.querySelectorAll('td')[column].textContent.toLowerCase(),
            second_row = b.querySelectorAll('td')[column].textContent.toLowerCase();

        return sort_asc ? (first_row < second_row ? -1 : 1) : (first_row < second_row ? 1 : -1);
    })
        .forEach(sorted_row => document.querySelector('tbody').appendChild(sorted_row));
}

// 3. Uppdatering av kolumner 12-14 baserat på val i kolumner 4-11
function updateColumns12To14(selectedElement) {
    const row = selectedElement.closest('tr'); // Hämta aktuell rad
    const dropdowns = row.querySelectorAll('td:nth-child(n+4):nth-child(-n+11) select');
    const column12 = row.querySelector('.column-12');
    const column13 = row.querySelector('.column-13');
    const column14 = row.querySelector('.column-14');

    let hasNej = false;
    let allJaOrEjRelevant = true;

    dropdowns.forEach(dropdown => {
        if (dropdown.value === "Nej") {
            hasNej = true;
            allJaOrEjRelevant = false;
        } else if (dropdown.value !== "Ej relevant") {
            allJaOrEjRelevant = allJaOrEjRelevant && dropdown.value === "Ja";
        }
    });

    column12.textContent = allJaOrEjRelevant ? "Ja" : hasNej ? "Nej" : "Ja";
    column13.textContent = allJaOrEjRelevant ? "Ja" : hasNej ? "Nej" : "Ja";
    column14.textContent = allJaOrEjRelevant ? "Ja" : hasNej ? "Nej" : "Ja";
}

// 4. Exportera HTML-tabellen till PDF
const pdf_btn = document.querySelector('#toPDF');
const customers_table = document.querySelector('#customers_table');

pdf_btn.addEventListener('click', () => {
    const html_code = `
        <!DOCTYPE html>
        <html>
        <head>
            <link rel="stylesheet" type="text/css" href="style.css">
        </head>
        <body>
            <main class="table" id="customers_table">${customers_table.innerHTML}</main>
        </body>
        </html>
    `;
    const new_window = window.open();
    new_window.document.write(html_code);

    setTimeout(() => {
        new_window.print();
        new_window.close();
    }, 400);
});

// 5. Exportera HTML-tabellen till JSON
const json_btn = document.querySelector('#toJSON');
json_btn.addEventListener('click', () => {
    const json = toJSON(customers_table);
    downloadFile(json, 'json', 'table_data');
});

function toJSON(table) {
    let table_data = [];
    let headers = Array.from(table.querySelectorAll('th')).map(th => th.textContent.trim());

    table.querySelectorAll('tbody tr').forEach(row => {
        let row_data = {};
        row.querySelectorAll('td').forEach((cell, index) => {
            row_data[headers[index]] = cell.textContent.trim();
        });
        table_data.push(row_data);
    });

    return JSON.stringify(table_data, null, 4);
}

// 6. Exportera HTML-tabellen till CSV
const csv_btn = document.querySelector('#toCSV');
csv_btn.addEventListener('click', () => {
    const csv = toCSV(customers_table);
    downloadFile(csv, 'csv', 'table_data');
});

function toCSV(table) {
    let rows = Array.from(table.querySelectorAll('tr')).map(row => {
        return Array.from(row.querySelectorAll('th, td')).map(cell => cell.textContent.trim()).join(',');
    });
    return rows.join('\n');
}

// 7. Exportera HTML-tabellen till Excel
const excel_btn = document.querySelector('#toEXCEL');
excel_btn.addEventListener('click', () => {
    const excel = toExcel(customers_table);
    downloadFile(excel, 'excel', 'table_data');
});

function toExcel(table) {
    let rows = Array.from(table.querySelectorAll('tr')).map(row => {
        return Array.from(row.querySelectorAll('th, td')).map(cell => cell.textContent.trim()).join('\t');
    });
    return rows.join('\n');
}

function downloadFile(data, fileType, fileName) {
    const a = document.createElement('a');
    a.href = `data:text/${fileType};charset=utf-8,${encodeURIComponent(data)}`;
    a.download = `${fileName}.${fileType}`;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
}

// 8. Funktion för att lägga till och ta bort rader
let rowCount = 10; // Börja med 10 rader

function addRow() {
    if (!isAdmin) return; // Avbryt om användaren inte är admin

    rowCount++;
    const tableBody = document.querySelector('tbody');

    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td>${rowCount}</td>
        <td>
            <select name="yrkes-kategori-${rowCount}">
                <option value="" disabled selected>Välj yrkeskategori</option>
                <option value="Sjuksköterska/Barnmorska">Sjuksköterska/Barnmorska</option>
                <option value="Skötare">Skötare</option>
                <option value="Student">Student</option>
                <option value="Tandhygienist">Tandhygienist</option>
                <option value="Tandläkare">Tandläkare</option>
                <option value="Tandsköterska">Tandsköterska</option>
                <option value="Undersköterska/Barnskötare">Undersköterska/Barnskötare</option>
                <option value="Övriga">Övriga</option>
            </select>
        </td>
        <td>
            <select name="omvardnadssituation-${rowCount}">
                <option value="" disabled selected>Välj situation</option>
                <option value="Hjälp med ADL">Hjälp med ADL</option>
                <option value="Behandling och undersökning">Behandling och undersökning</option>
                <option value="Blodtryckskontroll">Blodtryckskontroll</option>
                <option value="Provtagning osv">Provtagning osv</option>
                <option value="PVK-sättning">PVK-sättning</option>
            </select>
        </td>
        ${[...Array(8)].map(() => `
            <td>
                <select>
                    <option value="Ja" selected>Ja</option>
                    <option value="Nej">Nej</option>
                    <option value="Ej relevant">Ej relevant</option>
                </select>
            </td>
        `).join('')}
        <td class="column-12">Ja</td>
        <td class="column-13">Ja</td>
        <td class="column-14">Ja</td>
        <td><textarea placeholder="Lägg till kommentar här..."></textarea></td>
    `;

    tableBody.appendChild(newRow);
}

function removeRow() {
    if (!isAdmin) return; // Avbryt om användaren inte är admin

    const tableBody = document.querySelector('tbody');
    if (rowCount > 1) { // Se till att minst en rad finns kvar
        tableBody.removeChild(tableBody.lastElementChild);
        rowCount--;
    } else {
        alert("Det finns inga rader att ta bort!");
    }
}
