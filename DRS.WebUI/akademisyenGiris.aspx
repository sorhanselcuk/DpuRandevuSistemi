﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="akademisyenGiris.aspx.cs" Inherits="DRS.WebUI.akademisyenGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/png" href="logo.png"/>
        <meta charset="UTF-8" />
        <link rel="stylesheet" type="text/css" href="css/giris.css" />
       <link rel="stylesheet" type="text/css" href="css/popup.css" />
          <script src="./js/popup.js"></script>
                <title>Akademisyen Girişi</title>
</head>
<body>
    <form id="form1" runat="server"    onMouseOver =" dogrulama()" >
        <div class="baslik">
                    <img src="img/logo.png" class="sola-kaydir" />
                    <p><strong><h1>KÜTAHYA DUMLUPINAR ÜNİVERSİTESİ</h1></strong></p>
                    <p ><h2 class = "p3" >AKADEMİSYEN GİRİŞİ</h2></p>
                    </div>
                    <p class = "p1"> E-posta:</p>
        <asp:TextBox ID="tbxEPosta" runat="server" CssClass="input"></asp:TextBox>
        <br />
          <div  id = "mailHatasi" class = "mailHatasi"></div>
                    <br />
                    <p class = "p2">Şifre:</p>
        <asp:TextBox ID="tbxParola" runat="server" TextMode="Password" CssClass="input2"></asp:TextBox>
        <br />
              <div  id = "passHatasi" class = "passHatasi"></div>
        <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap"  CssClass="btn1" OnClick="btnGirisYap_Click"/>
    </form>
     <div class ="popup" id="popup">
      <div class ="inner" id ="box">
         <span class="close">&times;</span>
        <p id="text"></p>
          </div>
      </div>

      <script src="./js/giris.js"></script>
      <script src="./js/popup.js"></script>
</body>
</html>
