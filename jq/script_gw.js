function change_visibility(id, hid) {
    let show_this = document.getElementById(id)
    show_this.style.visibility = "hidden";
    let hid_this = document.getElementById(hid)
    hid_this.style.visibility = "visible";
}

function refresh_sel_ajax(selid) {
    let urlphp = null;
    switch(selid) {
        case "sel_gd_add":
            urlphp = "db_files/db_refresh_goods.php";
            break;
        case "sel_wh_add":
            urlphp = "db_files/db_refresh_warehouses.php";
            break;
        case "sel_gd_upd":
            urlphp = "db_files/db_refresh_goods.php";
            break;
        case "sel_wh_upd":
            urlphp = "db_files/db_refresh_warehouses.php";
            break;
    }
    $.ajax({
        url: urlphp,
        method: "POST",
        dataType: "json",
        success: function(result){
            refresh_selector(selid, "name", result);
        }                            
    });
}

function refresh_selector(sel_id, mode, data){
    let sel = document.getElementById(sel_id);
    while (sel.children.length != 0) {
        sel.removeChild(sel.firstChild);
    }
    for (let i = 0; i < data.length; i++) {
        let opt_sel = document.createElement("option");
        if (mode == "name") {
            opt_sel.innerText = data[i]["name"];
        }
        else if (mode == "id") {
            opt_sel.innerText = data[i]["id"];
        }
        sel.appendChild(opt_sel);
    }
    sel.selectedIndex = 0;
}

function ajax(mode) {
    var name = null;
    var sel_id = null;
    var sel_ng = null;
    var sel_nw = null;
    switch(mode) {
        case "1":
            sel_ng = $('#sel_gd_add option:selected').text();
            sel_nw = $('#sel_wh_add option:selected').text();
            break;
        case "2":
            sel_id = $('#sel_upd option:selected').text();
            sel_ng = $('#sel_gd_upd option:selected').text();
            sel_nw = $('#sel_wh_upd option:selected').text();
            break;
        case "3":
            sel_id = $('#sel_del option:selected').text();
            break;
    }
    $.ajax({
        url: "db_files/db_g_w.php",
        method: "POST",
        data: {
            mode: mode,
            sel_id: sel_id,
            sel_ng: sel_ng,
            sel_nw: sel_nw
        },
        dataType: "json",
        success: function(result){
            refresh_data("main_table", result);
        },             
        error: function(jqXHR) {
            console.log(jqXHR.responseText);
        }
    }); 
}

function refresh_data(table_id, data){
    refresh_selector("sel_upd", "id", data);
    refresh_selector("sel_del", "id", data);
    let table = document.getElementById(table_id);
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

