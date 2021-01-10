var menuDurum = false;
function openNav() {

    if (menuDurum) {
        closeNav()
        menuDurum = false;
    }
    else {
        menuDurum = true;
        document.getElementById("YanMenu").style.width = "250px";
        document.getElementById("YanMenu").style.marginTop = "76px";
        $(".sidenav2").hide();
        $(".sidenav").show();
    }
}
$(document).ready(function () {
    $(".sidenav2").show();
    $(".sidenav").hide();

});

function closeNav() {
    $(".sidenav2").show();
    $(".sidenav").hide();
    document.getElementById("YanMenu").style.width = "35px";
}
function setTitle(isim) {
    document.title = isim;
}

