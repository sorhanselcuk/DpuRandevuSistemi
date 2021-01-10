var adminKullanciAdi = document.forms['form1']['tbxKullaniciAdi'],
          pass = document.forms['form1']['tbxParola'];

var mailHatasi = document.getElementById("mailHatasi"),
    passHatasi = document.getElementById("passHatasi");

var reMail = /[A-Za-z]+\.+[A-Za-z]+@+(dpu.edu.tr|ogr.dpu.edu.tr)/,
      rePass = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/;


  adminKullanciAdi.onkeyup = adminKullanciAdiDogrulama;
  pass.onkeyup = passDogrulama;

  function adminKullanciAdiDogrulama() {
      if (!reMail.test(adminKullanciAdi.value)) {
          adminKullanciAdi.style.border = "3px solid red";
          mailHatasi.textContent = "*Lütfen kullancı adınızı giriniz";
          return false;
      }
      else {
          adminKullanciAdi.style.border = "";
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
      if (adminKullanciAdiDogrulama() && passDogrulama()) {

          return true;
      }
      else {
          return false;
      }
  }

