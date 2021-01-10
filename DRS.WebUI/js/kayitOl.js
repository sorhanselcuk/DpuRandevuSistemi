
var isim = document.getElementById('tbxAd'),
     soyad = document.getElementById('tbxSoyad'),
     mail =  document.getElementById('tbxEPosta'),
     pass =  document.getElementById('tbxParola'),
     ogrNo =  document.getElementById('tbxOgrNo');

var isimHatasi = document.getElementById("isimHatasi"),
    soyadHatasi = document.getElementById("soyadHatasi"),
    mailHatasi = document.getElementById("mailHatasi"),
    passHatasi = document.getElementById("passHatasi"),
    ogrNoHatasi = document.getElementById("ogrNoHatasi");

var reIsim = /[A-Za-zçşğüöıÇÖÜĞŞIİ]+/,
    reMail = /[A-Za-z]+\.+[A-Za-z]+@+(dpu.edu.tr|ogr.dpu.edu.tr)/,
    rePass = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/,
    reOgrNo = /[0-9]/;

     isim.onkeyup = isimDogrulama;
     soyad.onkeyup = soyadDogrulama;
     mail.onkeyup = mailDogrulama;
     pass.onkeyup = passDogrulama;
     reOgrNo.onkeyup = ogrNoDogrulama;
   
function isimDogrulama() {
    if (isim.value === "") {
        isim.style.border = "3px solid red";
        isimHatasi.textContent = "*Lütfen adınızı giriniz.";
        return false;
    }
    if (isim.value.length < 3) {
        isim.style.border = "3px solid red";
        isimHatasi.textContent = "*İsim en az 3 harftan oluşmalı.";
        return false;
    }
    if (!reIsim.test(isim.value) || (/[0-9]/).test(isim.value)) {
        isim.style.border = "3px solid red";
        isimHatasi.textContent = "*İsim sadece harflardan olmalı.";
        return false;
    }

    else {
        isim.style.border = "";
        isimHatasi.innerHTML = "";
        return true;
    }
}

function soyadDogrulama() {
    if (soyad.value === "") {
        soyad.style.border = "3px solid red";
        soyadHatasi.textContent = "*Lütfen soyadınızı giriniz.";
        return false;
    }
    if (soyad.value.length < 3) {
        soyad.style.border = "3px solid red";
        soyadHatasi.textContent = "*Soyad en az 3 harftan oluşmalı.";
        return false;
    }
    if (!reIsim.test(soyad.value) || (/[0-9]/).test(soyad.value)) {
        soyad.style.border = "3px solid red";
        soyadHatasi.textContent = "*Soyad sadece harflardan olamlı.";
        return false;
    }

    else {
        soyad.style.border = "";
        soyadHatasi.innerHTML = "";
        return true;
    }
}

function mailDogrulama() {
    if (!reMail.test(mail.value)) {
        mail.style.border = "3px solid red";
        mailHatasi.textContent = "*Lütfen kurumsal mailinizi giriniz";
        return false;
    }
    else {
        mail.style.border = "";
        mailHatasi.innerHTML = "";
        return true;
    }
}

function passDogrulama() {
    if (pass.value === "") {
        pass.style.border = "3px solid red";
        passHatasi.textContent = "*Lütfen şifrenizi giriniz.";
        return false;
    }
    if (!rePass.test(pass.value)) {
        pass.style.border = "3px solid red";
        passHatasi.textContent = "*En az bir sayı ve bir büyük ve küçük harf ve en az 8 veya daha fazla karakter içermelidir";
        return false;
    }
    else {
        pass.style.border = "";
        passHatasi.innerHTML = "";
        return true;
    }

}
function ogrNoDogrulama() {
    if (ogrNo.value === "") {
        ogrNo.style.border = "3px solid red";
        ogrNoHatasi.textContent = "*Lütfen öğrenci numaranızı giriniz.";
        return false;
    }
 
    if (!reOgrNo.test(ogrNo.value)) {
        ogrNo.style.border = "3px solid red";
        ogrNoHatasi.textContent = "*Öğrenci numrası sadece rakamlardan oluşmalı.";
        return false;
    }
    if (ogrNo.value.length < 12) {
        ogrNo.style.border = "3px solid red";
        ogrNoHatasi.textContent = "*Öğrenci numarsaı 12 rakamdan oluşmalı";
        return false;
    }

    else {
        ogrNo.style.border = "";
        ogrNoHatasi.innerHTML = "";
        return true;
    }
}

  
 var dogrulama = function () {
     if ( isimDogrulama() && soyadDogrulama() && mailDogrulama() && ogrNoDogrulama() && passDogrulama()) {
        return true;
    }
    else {
        return false;
    }
 }

