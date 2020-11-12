function changeVisibility(id, hid) {
    let showThis = document.getElementById(id)
    showThis.style.visibility = "hidden";
    let hideThis = document.getElementById(hid)
    hideThis.style.visibility = "visible";
}

function refresSelAJAX(selID) {
    let url = null;
    switch(selID) {
        case "sel_gd_add":
            url = "db_files/db_refresh_goods.php";
            break;
        case "sel_wh_add":
            url = "db_files/db_refresh_warehouses.php";
            break;
        case "sel_gd_upd":
            url = "db_files/db_refresh_goods.php";
            break;
        case "sel_wh_upd":
            url = "db_files/db_refresh_warehouses.php";
            break;
    }
    $.ajax({
        url: url,
        method: "POST",
        dataType: "json",
        success: function(result){
            refreshSelect(selID, "name", result);
        }                            
    });
}

function refreshSelect(selID, mode, data){
    let sel = document.getElementById(selID);
    while (sel.children.length != 0) {
        sel.removeChild(sel.firstChild);
    }
    for (let i = 0; i < data.length; i++) {
        let optSel = document.createElement("option");
        if (mode == "name") {
            optSel.innerText = data[i]["name"];
        }
        else if (mode == "id") {
            optSel.innerText = data[i]["id"];
        }
        sel.appendChild(optSel);
    }
    sel.selectedIndex = 0;
}

function ajax(mode) {
    var name = null;
    var selID = null;
    var selNameG = null;
    var selNameW = null;
    switch(mode) {
        case "1":
            selNameG = $('#sel_gd_add option:selected').text();
            selNameW = $('#sel_wh_add option:selected').text();
            break;
        case "2":
            selID = $('#sel_upd option:selected').text();
            selNameG = $('#sel_gd_upd option:selected').text();
            selNameW = $('#sel_wh_upd option:selected').text();
            break;
        case "3":
            selID = $('#sel_del option:selected').text();
            break;
    }
    $.ajax({
        url: "db_files/db_g_w.php",
        method: "POST",
        data: {
            mode: mode,
            selID: selID,
            selNameG: selNameG,
            selNameW: selNameW
        },
        dataType: "json",
        success: function(result){
            refreshData("main_table", result);
        }
    }); 
}

function refreshData(tableID, data){
    refreshSelect("sel_upd", "id", data);
    refreshSelect("sel_del", "id", data);
    let table = document.getElementById(tableID);
    table.replaceChild(document.createElement("tbody"), table.children[0]);
    let body = table.children[0];
    let tr = document.createElement("tr");
    let td = document.createElement("th");
    td.innerText = "ИД"
    tr.appendChild(td)
    td = document.createElement("th");
    td.innerText = "Товар"
    tr.appendChild(td)
    td = document.createElement("th");
    td.innerText = "Склад"
    tr.appendChild(td)
    body.appendChild(tr);
    for (let i = 0; i < data.length; i++) {
        let el = data[i]
        tr = document.createElement("tr")
        td = document.createElement("td")
        td.innerText = el["id"]
        tr.appendChild(td);
        td = document.createElement("td")
        td.innerText = el["gn"]
        tr.appendChild(td)
        td = document.createElement("td")
        td.innerText = el["wn"]
        tr.appendChild(td)
        body.appendChild(tr)
    }
}

