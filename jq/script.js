function changeVisibility(sid, hid) {
    let showThis = document.getElementById(sid)
    showThis.style.visibility = "hidden";
    let hideThis = document.getElementById(hid)
    hideThis.style.visibility = "visible";
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


function ajax(mode, url) {
    var name = null;
    var selID = null;
    switch(mode) {
        case "1":
            name = $('#txt').val();
            break;
        case "2":
            name = $('#txt2').val();
            selID = $('#sel_upd option:selected').text();
            break;
        case "3":
            selID = $('#sel_del option:selected').text();
            break;
    }
    if ($.trim(name) != '' || mode == 3) {
        $.ajax({
            url: url,
            method: "POST",
            data: {
                mode: mode,
                name: name,
                selID: selID
            },
            dataType: "json",
            success: function(result){
                refreshData("main_table", "sel_upd", "sel_del", result);
            }
        });
    } 
}

function refreshData(tableID, sel1ID, sel2ID, data){
    let sel1 = document.getElementById(sel1ID);
    let sel2 = document.getElementById(sel2ID);
    while (sel1.children.length != 0) {
        sel1.removeChild(sel1.firstChild);
        sel2.removeChild(sel2.firstChild);
    }
    for (let i = 0; i < data.length; i++) {
        let optSel1 = document.createElement("option");
        let optSel2 = document.createElement("option");
        optSel1.innerText = data[i]["id"];
        optSel2.innerText = data[i]["id"];
        sel1.appendChild(optSel1);
        sel2.appendChild(optSel2);
    }
    sel1.selectedIndex = 0;
    sel2.selectedIndex = 0;
    let table = document.getElementById(tableID);
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

