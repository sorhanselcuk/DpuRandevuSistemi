<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DRS.WebUI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/png" href="logo.png" />
    <meta charset="UTF-8" />

    <script src="https://kit.fontawesome.com/06da762a55.js"></script>
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <title>Akademisyen-Öğrenci Randevu Sistemi </title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="yazi">
  <img src="img/logo.png" class="sola-kaydir" />
  <div class="baslik"><p><strong><h1>KÜTAHYA DUMLUPINAR ÜNİVERSİTESİ</h1></strong></p>
    <p1><h2>AKADEMİSYEN-ÖĞRENCİ RANDEVU SİSTEMİ</h2></p1></div>
  
  </div>
        
 
  
  <p class="btn3"><a href="kayitOl.aspx" >Kayıt Ol</a></p>

    </form>
    <button class="btn1" onclick="location.href='akademisyenGiris.aspx'"><i class="fas fa-graduation-cap" style="float:left;"></i>Akademisyen Girişi</button>
 
     <button class="btn2" onclick="window.location.href='ogrenciGiris.aspx'"><i class="fas fa-user" style="float:left;"></i>Öğrenci Girişi</button>
    <script type="text/javascript">
        function OgrenciGiris() {
            window.location.href = 'ogrenciGiris.aspx';
        }
</script>
</body>

</html>
