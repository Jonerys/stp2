function change_visibility(id, hid) {
    let show_this = document.getElementById(id)
    show_this.style.visibility = "hidden";
    let hid_this = document.getElementById(hid)
    hid_this.style.visibility = "visible";
}

function ajax(mode, tid = null, sid = null) {
    var objXMLHttpRequest = new XMLHttpRequest();
    objXMLHttpRequest.onreadystatechange = function() {
    if(objXMLHttpRequest.readyState === 4) {
        if(objXMLHttpRequest.status === 200) {
            update_table(document.getElementById('main_table'), objXMLHttpRequest.responseText)
            update_lists(['sel_upd', 'sel_del'], objXMLHttpRequest.responseText)
        } else {
            alert('Error Code: ' +  objXMLHttpRequest.status);
            alert('Error Message: ' + objXMLHttpRequest.statusText);
        }
    }
    }
	var getstr = "?mode=" + mode;
	if (tid != null) {
		var name = document.getElementById(tid).value;
		getstr += "&name=" + name;
	} 
	if (sid != null) {
		var ind = document.getElementById(sid).selectedIndex;
		var sel = document.getElementById(sid).options[ind].value;
		getstr += "&sel_id=" + sel;
	}
    objXMLHttpRequest.open("GET", "db_get_data.php" + getstr);
    objXMLHttpRequest.send();
}


function update_lists(lids, response) {
    let data = JSON.parse(response)
    for (let i = 0; i < lids.length; i++) {
        let lid = lids[i]
        let sel = document.getElementById(lid)
        while (sel.children.length != 0) {
            sel.removeChild(sel.firstChild)
        }
        for (let j = 0; j < data.length; j++) {
            let opt = document.createElement("option")
            opt.innerText = data[j]["id"]
            sel.appendChild(opt)
        }
    }
}

function update_table(table, response) {
    var x = document.createElement("tbody");
    table.replaceChild(x, table.children[0]);
    var body = table.children[0];
    var data = JSON.parse(response)
    var tr = document.createElement("tr");
    var td = document.createElement("th");
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