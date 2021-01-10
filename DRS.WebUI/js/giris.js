var mail = document.forms['form1']['tbxEPosta'],
     pass = document.forms['form1']['tbxParola'];
  

var mailHatasi = document.getElementById("mailHatasi"),
    passHatasi = document.getElementById("passHatasi");

var reMail = /[A-Za-z]+\.+[A-Za-z]+@+(dpu.edu.tr|ogr.dpu.edu.tr)/,
      rePass = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/;

    mail.onkeyup = mailDogrulama;
    pass.onkeyup = passDogrulama;
   
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
    if (pass.value === "" || !rePass.test(pass.value)) {
        pass.style.border = "3px solid red";
        passHatasi.textContent = "*Lütfen şifrenizi giriniz.";
        return false;
    }
  
    else {
        pass.style.border = "";
        passHatasi.innerHTML = "";
        return true;
    }
}


var dogrulama = function () {
    if (mailDogrulama() && passDogrulama()) {  

        return true;
    }
    else {
        return false;
    }
}
