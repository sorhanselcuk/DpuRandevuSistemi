var durum = false;

function IptalEt() {
    var button = document.getElementById("btnIslem");
    swal({
        title: "Secili randevu iptal edilecektir.",
        text: "Reddedilmesi için onay veriniz.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Kabul Et",
        cancelButtonText: "Vazgeç",
        closeOnConfirm: false,
        html: true
    },
        function () {
            Alert_Success("İşlem Tamamlandı !");
            button.click();
        });
}
function KabulEt() {
    var button = document.getElementById("btnIslem");
    swal({
        title: "Secili randevu kabul edilecektir.",
        text: "Kabul edilmesi için onay veriniz.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Kabul Et",
        cancelButtonText: "Vazgeç",
        closeOnConfirm: false,
        html: true
    },
        function () {
            Alert_Success("İşlem Tamamlandı !");
            button.click();
        });
}
function randevuDetay() {
    $('#randevuDetay').modal('show');
}