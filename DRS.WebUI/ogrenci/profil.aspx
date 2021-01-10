<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profil.aspx.cs" Inherits="DRS.WebUI.ogrenci.profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
<title>Öğrenci</title> <!--veritabanından giriş yapan öğrencinin adı soyadı çekilecek -->
<style>
        p{color:black;}
        body {
          background-image: url('../img/arkaplan.jpg');
        }
        
        .sola-kaydir{
        float:left;
        padding:0 10px 10px 30px;
        }

        </style>
        <link rel="shortcut icon" type="image/png" href="../img/logo.png"/>
<link rel="stylesheet" href="../css/profil.css" type="text/css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <script src="https://kit.fontawesome.com/06da762a55.js"></script>

        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js""></script>
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
        <script src="../js/profilScript.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
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
                <div class="">
                    <asp:LinkButton CssClass="profilAd" ID="lnkbtnProfil" runat="server" OnClick="lnkbtnProfil_Click"> <i class="fa fa-user"></i>
                        <asp:Label ID="lblKullaniciAdi" runat="server" Text=""></asp:Label></asp:LinkButton>
                    <asp:LinkButton CssClass="cikisbtn" ID="lnkbtnCikis" runat="server" OnClick="lnkbtnCikis_Click"> <i class="fa fa-sign-out"></i>  Çıkış Yap</asp:LinkButton>

                </div>
            </div>
        </nav>

        <div id="YanMenu" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a class="deneme" href="profil.aspx"><i class="fa fa-home"></i>Anasayfa</a>
            <a class="deneme" href="randevuTalep.aspx"><i class="fa fa-plus"></i>Randevu Talep Et</a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i>Randevular</a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i>Onay Bekleyen Randevular</a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i>Geçmiş Randevular</a>
            <a class="deneme" href="ayarlar.aspx"><i class="fas fa-cogs"></i>Ayarlar</a>



        </div>
        <div id="YanMenu1" class="sidenav2">

            <a class="deneme" href="profil.aspx"><i class="fa fa-home"></i></a>
            <a class="deneme" href="randevuTalep.aspx"><i class="fa fa-plus"></i></a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="ayarlar.aspx"><i class="fas fa-cogs"></i></a>

        </div>
	<div class ="content-wrapper">
        <div class="container" style="margin:80px auto;">
            <div class="row">
                <asp:Button ID="btnDuyurular" runat="server" Text="Duyurular" CssClass="anasayfaButton2" OnClick="btnDuyurular_Click" />
                <asp:Button ID="btnObs" runat="server" Text="OBS" CssClass="fakulteAyarlariButton2" OnClick="btnObs_Click" />
                <asp:Button ID="btnRandevular" runat="server" Text="Randevular"  CssClass="bolumAyarlariButton2" OnClick="btnRandevular_Click"/>
                <asp:Button ID="btnGecmisRandevular" runat="server" Text="Geçmiş Randevular" CssClass="akademisyenAyarlariButton2" OnClick="btnGecmisRandevular_Click" />
                <asp:Button ID="btnOnayBekleyenRandevular" runat="server" Text="Onay Bekleyen Randevular" CssClass="ogrenciAyarlariButton2" OnClick="btnOnayBekleyenRandevular_Click"/>
                <asp:Button ID="btnRandevuTalep" runat="server" Text="Randevu Talep" CssClass="ayarlarButton2" OnClick="btnRandevuTalep_Click" />
            </div>
        </div>
</div>
 
    </form>
</body>
</html>
