<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kayitOl.aspx.cs" Inherits="DRS.WebUI.kayitOl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/png" href="logo.png" />
    <meta charset="UTF-8" />
    <title>Kayıt Ol</title>
    <link rel="stylesheet" type="text/css" href="css/kayit.css" />
    <link rel="stylesheet" type="text/css" href="css/popup.css" />
      <script src="./js/popup.js"></script>
      
</head>
<body>
    <form id="form1" runat="server"    onMouseOver  =" dogrulama()" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="kayit">
            <img src="img/logo.png" class="sola-kaydir" />
            <p><strong>
                <h1 class="p1">KAYIT OL</h1>
            </strong></p>
        </div>
        <p class="p2">İsim   :</p>
      
        <asp:TextBox ID="tbxAd" CssClass="input" runat="server" placeholder="İsminizi giriniz." ></asp:TextBox>
        <br />
          <div  id = "isimHatasi" class = "isimHatasi"></div>
        <br />
        <p class="p3">Soyad   :</p>
        <asp:TextBox ID="tbxSoyad" CssClass="input2" runat="server" placeholder="Soyadınızı giriniz." ></asp:TextBox>
        <br />
         <div  id = "soyadHatasi" class = "soyadHatasi"></div>
        <br />
        <p class="p4">E-posta:</p>
        <asp:TextBox ID="tbxEPosta" CssClass="input3" TextMode="Email" runat="server" name="mail" ></asp:TextBox>
        
        <br />
        <div  id = "mailHatasi" class = "mailHatasi"></div>
        <br />
        
        <p class="p5">Fakulte:</p> 
        
        <ajaxToolkit:ComboBox ID="cbxFakulteler" CssClass="input4" runat="server" Width="120px" AutoPostBack="True" OnTextChanged="cbxFakulteler_TextChanged">
        </ajaxToolkit:ComboBox>
       
        <br />
          <div  id = "fakulteHatasi" class = "fakulteHatasi"></div>
        <br />
        <p class="p6">Bölüm   :</p>
        
        <ajaxToolkit:ComboBox ID="cbxBolumler" CssClass="input5" runat="server" Width="120px" AutoPostBack="True"></ajaxToolkit:ComboBox>
            
        <br />
          <div  id = "bolumHatasi" class = "bolumHatasi"></div>
        <br />
        <p class="p10">Öğrenci no:</p>
        <asp:TextBox ID="tbxOgrNo" CssClass="input6" runat="server"></asp:TextBox>
        <br />
        <div  id = "ogrNoHatasi" class = "ogrNoHatasi"></div>
        <br />
        <p class="p7">Şifre:</p>
        
        <asp:TextBox ID="tbxParola" CssClass="input9" TextMode="Password" runat="server"></asp:TextBox>
        <br />
         <div  id = "passHatasi" class = "passHatasi"></div>
        <br />
        <asp:RadioButton ID="radioBtnAkademisyen" CssClass="input7" runat="server" OnCheckedChanged="radioBtnAkademisyen_CheckedChanged" AutoPostBack="True"  />
        
        <p class="p8">Akademisyen</p>
        <br />
        <br />
        <asp:RadioButton ID="radioBtnOgrenci"  CssClass="input8" runat="server" OnCheckedChanged="radioBtnOgrenci_CheckedChanged" AutoPostBack="True"   />
        <p class="p9">Öğrenci</p>
        <br />
        <br />
       
        <asp:Button ID="btnKayitOl" CssClass="btn1" OnClick="btnKayitOl_Click" runat="server" Text="Kayıt Ol"   /> <br />
    </form>
    <div class ="popup" id="popup">
      <div class ="inner" id ="box">
         <span class="close">&times;</span>
        <p id="text"></p>
          </div>
      </div>

      <script src="./js/kayitOl.js"></script>
      <script src="./js/popup.js"></script>
      <script src="./js/jquery/jquery-3.4.1.min.js"></script>
     
    
</body>
</html>
