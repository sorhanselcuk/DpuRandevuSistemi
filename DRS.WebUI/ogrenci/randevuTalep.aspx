<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="randevuTalep.aspx.cs" Inherits="DRS.WebUI.ogrenci.randevuTalep" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">
    <meta charset="UTF-8" />
    <title>Öğrenci</title>
    <!--veritabanından giriş yapan öğrencinin adı soyadı çekilecek -->

    <link rel="shortcut icon" type="image/png" href="../img/logo.png" />
    <link rel="stylesheet" href="../css/profil.css" type="text/css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script> -->

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>

    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../js/sweetalert/sweetalert/sweetalert.css" />
    <link href="../css/randevu.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/popup.css" />
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
    <form id="form1" runat="server"    onMouseOver =" konuDogrulama()" >     
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
            <a class="deneme" href="randevuTalep.aspx"><i class="fa fa-plus"></i>Randevu Talep Et</a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i>Randevular</a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i>Onay Bekleyen Randevular</a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i>Geçmiş Randevular</a>
            



        </div>
        <div id="YanMenu1" class="sidenav2">

            <a class="deneme" href="profil.aspx"><i class="fa fa-home"></i></a>
            <a class="deneme" href="randevuTalep.aspx"><i class="fa fa-plus"></i></a>
            <a class="deneme" href="randevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="onayBekleyenRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            <a class="deneme" href="gecmisRandevular.aspx"><i class="fas fa-calendar-week"></i></a>
            

        </div>

        <div>
               <p class = "pakademisyenTarihEkleFakulte" >Fakülte:</p>
            
            <ajaxToolkit:ComboBox ID="cbxFakulteler" CssClass="inputakademisyenTarihEkleFakulte" runat="server" AutoPostBack="True" OnTextChanged="cbxFakulteler_TextChanged"></ajaxToolkit:ComboBox>

                <p class = "pakademisyenTarihEkleBolum">Bölüm:</p>

            <ajaxToolkit:ComboBox ID="cbxBolumler" CssClass="inputakademisyenTarihEkleBolum" runat="server" AutoPostBack="true" OnTextChanged="cbxBolumler_TextChanged"></ajaxToolkit:ComboBox>
            
            <p class="pogrenciRandevularAkademisyen2">Akademisyen:</p> 
            <ajaxToolkit:ComboBox ID="cbxAkademisyenler" CssClass="inputogrenciRandevularAkademisyen2" runat="server" AutoPostBack="True" OnTextChanged="cbxAkademisyenler_TextChanged"></ajaxToolkit:ComboBox>
            
            <p class="pogrenciRandevularTarih2">Tarih:</p> 
            <ajaxToolkit:ComboBox ID="cbxTarihler" CssClass="inputogrenciRandevularTarih2" runat="server" AutoPostBack="True" OnTextChanged="cbxTarihler_TextChanged"></ajaxToolkit:ComboBox>
            
            <p class="pogrenciRandevularSaatler2">Saatler:</p>
            <ajaxToolkit:ComboBox ID="cbxSaatler" CssClass="inputogrenciRandevularSaat2" runat="server" AutoPostBack="True"></ajaxToolkit:ComboBox>

                <p class="Konu" >Konu :</p>
            <asp:TextBox CssClass="TextBoxKonu" ID="tbxKonu" runat="server" MaxLength="50"></asp:TextBox>  
            <div  id = "konuHatasi" class = "konuHatasi"></div>
            <asp:Button ID="btnOlustur" CssClass="ogrenciRandevuButton3" runat="server" Text="Randevu Talep Et" OnClick="btnOlustur_Click" />
              </div>       

    </form>
         <div class ="popup" id="popup">
      <div class ="inner" id ="box">
         <span class="close">&times;</span>
        <p id="text"></p>
          </div>
      </div>
        <script src="../js/popup.js"></script>
        <script src="../js/ogrenci/randevuTalep.js"></script>
</body>
</html>
