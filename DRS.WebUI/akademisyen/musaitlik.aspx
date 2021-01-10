<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="musaitlik.aspx.cs" Inherits="DRS.WebUI.akademisyen.musaitliklik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Akademisyen</title>
    <!--veritabanından giriş yapan öğrencinin adı soyadı çekilecek -->

    <link rel="shortcut icon" type="image/png" href="../img/logo.png" />
    <link rel="stylesheet" href="../css/profil.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/popup.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script> -->

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>

    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../js/sweetalert/sweetalert/sweetalert.css" />
    <link href="../css/randevu.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/06da762a55.js"></script>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="../js/profilScript.js" type="text/javascript"></script>
    <script src="../js/randevu.js"></script>
    <script src="../js/sweetalert/sweetalert/sweetalert-dev.js"></script>
    <script src="../js/sweetalert/sweetalert/sweetalert.min.js"></script>
    <script src="../js/Alert.js"></script>
    <script src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary st fixed-top" style="background-color: darkslateblue !important;">
            <a class="navbar-brand" href="#">
                <img class="logo" src="../img/logo.png" alt="logo" onclick="openNav()" />
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarColor02">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="javascript:void(0)">Kütahya Dumlupınar Üniversitesi <span class="sr-only">(current)</span></a>
                    </li>

                </ul>
                 <div class="p2">
                    <asp:LinkButton CssClass="profilAd" ID="lnkbtnProfil" runat="server" OnClick="lnkbtnProfil_Click">
                        <i class="fa fa-user"></i>
                        <asp:Label ID="lblKullaniciAdi" runat="server" Text=""></asp:Label>
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="cikisbtn" ID="lnkBtnCikisYap" runat="server" OnClick="lnkBtnCikisYap_Click"> <i class="fa fa-sign-out"></i>  Çıkış Yap</asp:LinkButton>

                </div>
            </div>
        </nav>

         <div id="YanMenu" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a class="deneme" href="profil.aspx"><i class="fa fa-home"></i>Anasayfa</a>
            <a class="deneme" href="musaitlik.aspx"><i class="fa fa-plus"></i>Müsaitlik Ekle</a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i>Randevular</a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i>Onay Bekleyen Randevular</a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i>Geçmiş Randevular</a>
            <a class="deneme" href="ayarlar.aspx"><i class="fas fa-cogs"></i>Ayarlar</a>



        </div>
        <div id="YanMenu1" class="sidenav2">

            <a class="deneme" href="profil.aspx"><i class="fa fa-home"></i></a>
             <a class="deneme" href="musaitlik.aspx"><i class="fa fa-plus"></i></a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="ayarlar.aspx"><i class="fas fa-cogs"></i></a>

        </div>
        
	<div class ="content-wrapper">
        <div class="container" style="margin:80px auto;">
            <div class="row">
              <div>
                <p class ="pakademisyenTarihEkleDuzenle">Tarih Ekle:</p>
                  <ajaxToolkit:ComboBox ID="cbxTarihler" runat="server" CssClass="inputakademisyenTarihEkleDuzenle"></ajaxToolkit:ComboBox>
                <p class ="pakademisyenSaatEkleDuzenle">Saat Ekle:</p>
                  <ajaxToolkit:ComboBox ID="cbxSaatler" runat="server" CssClass="inputakademisyenSaatEkleDuzenle"></ajaxToolkit:ComboBox>
                  <asp:Button ID="btnEkle" runat="server" Text="Ekle" CssClass="RandevularEkleButton2" OnClick="btnEkle_Click" />
               
                  <br/>

              </div >
                
                

            </div>
        </div>
</div>
    </form>
      
    <div class ="popup" id="popup">
      <div class ="inner" id ="box">
         <span class="close">&times;</span>
        <p id="text"></p>
          </div>
      </div>
        <script src="../js/popup.js"></script>
</body>
</html>
