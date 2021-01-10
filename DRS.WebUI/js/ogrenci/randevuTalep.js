var konu = document.forms['form1']['tbxKonu'];

var konuHatasi = document.getElementById("konuHatasi");

konu.onkeyup = konuDogrulama;

function konuDogrulama() {
    if (konu.value === "") {
        konu.style.border = "3px solid red";
        konuHatasi.textContent = "*Lütfen konuyu giriniz.";
        konu.focus();
        return false;
    }

    else {
        konu.style.border = "";
        konuHatasi.innerHTML = "";
        return true;
    }
}

