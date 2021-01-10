
function OnayFakulteSil() {
    var button = document.getElementById("btnIslem");
    swal({
        title: "Secili fakülte silenecektir.",
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
function OnayBolumSil() {
    var button = document.getElementById("btnIslem");
    swal({
        title: "Secili bölüm silenecektir.",
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
