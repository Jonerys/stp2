function change_visibility(id, hid) {
    let show_this = document.getElementById(id)
    show_this.style.visibility = "hidden";
    let hid_this = document.getElementById(hid)
    hid_this.style.visibility = "visible";
}