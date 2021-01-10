
var popup = document.getElementById("popup"),
          span = document.getElementsByClassName("close")[0],
          box = document.getElementById("box"),
          text = document.getElementById("text");
          
     function SameDataAlert() {

         popup.style.display = "block";
         text.textContent = "Böyle bir kayıt zaten mevcut.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function SameDataAlert2() {
   
         popup.style.display = "block";
         text.textContent = "Eksik bilgiler girmişsiniz.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }

     function girisAlerti() {
         popup.style.display = "block";
         text.textContent = "E-posta veya şifre geçersiz. ";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function rendevuTalepAlerti() {

         popup.style.display = "block";
         text.textContent = "Eksik bilgiler girmişsiniz.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function basariliTalepAlerti() {

         popup.style.display = "block";
         box.style.border = "10px solid #0c510f";
         text.style.color = "#0c510f";
         text.textContent = "Talep başarılı bir şekilde gerçekleştirilmiştir.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function musaitlikAlerti() {

         popup.style.display = "block";
         box.style.border = "10px solid #0c510f";
         text.style.color = "#0c510f";
         text.textContent = "Başarılı bir şekilde eklendi.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }

     function musaitlikHataAlerti() {
         popup.style.display = "block";
         text.textContent = "Tarih veya saat boş bırakmışsınız.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function randevuSilmeHatasi() {

         popup.style.display = "block";
         text.textContent = "Randevuyu silinemedi.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     function adminAlert() {

         popup.style.display = "block";
         text.textContent = "Kullancı adı veya şifre geçersiz.";
         span.onclick = function () {
             popup.style.display = "none";
         }
     }
     
