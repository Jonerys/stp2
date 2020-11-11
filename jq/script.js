function change_visibility(id, hid) {
    let show_this = document.getElementById(id)
    show_this.style.visibility = "hidden";
    let hid_this = document.getElementById(hid)
    hid_this.style.visibility = "visible";
    switch(hid){
        case 'add':
            reset(1);
            break;
        case 'update':
            reset(2);
            break;
        case 'delete':
            reset(3);
            break;
        default:
            break;
    }
}


function ajax(mode) {
    var name = null;
    var sel_id = null;
    switch(mode) {
        case "1":
            name = $('#txt').val();
            break;
        case "2":
            name = $('#txt2').val();
            sel_id = $('#sel_upd option:selected').text();
            break;
        case "3":
            sel_id = $('#sel_del option:selected').text();
            break;
    }
    if ($.trim(name) != '' || mode == 3) {
        $.ajax({
            url: "db_get_data.php",
            method: "POST",
            data: {
                mode: mode,
                name: name,
                sel_id: sel_id
            },
            dataType: "json",
            success: function(result){
                refresh_data("main_table", "sel_upd", "sel_del", result);
            }                            
        });
    } 
}

function refresh_data(table_id, sel1_id, sel2_id, data){
    let sel1 = document.getElementById(sel1_id);
    let sel2 = document.getElementById(sel2_id);
    while (sel1.children.length != 0) {
        sel1.removeChild(sel1.firstChild);
        sel2.removeChild(sel2.firstChild);
    }
    for (let i = 0; i < data.length; i++) {
        let opt_sel1 = document.createElement("option");
        let opt_sel2 = document.createElement("option");
        opt_sel1.innerText = data[i]["id"];
        opt_sel2.innerText = data[i]["id"];
        sel1.appendChild(opt_sel1);
        sel2.appendChild(opt_sel2);
    }
    sel1.selectedIndex = 0;
    sel2.selectedIndex = 0;
    let table = document.getElementById(table_id);
    table.replaceChild(document.createElement("tbody"), table.children[0]);
    let body = table.children[0];
    let tr = document.createElement("tr");
    let td = document.createElement("th");
    td.innerText = "ИД"
    tr.appendChild(td)
    td = document.createElement("th");
    td.innerText = "Название"
    tr.appendChild(td)
    body.appendChild(tr);
    for (let i = 0; i < data.length; i++) {
        let el = data[i]
        tr = document.createElement("tr")
        td = document.createElement("td")
        td.innerText = el["id"]
        tr.appendChild(td);
        td = document.createElement("td")
        td.innerText = el["name"]
        tr.appendChild(td)
        body.appendChild(tr)
    }
}

