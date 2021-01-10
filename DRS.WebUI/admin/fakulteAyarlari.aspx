<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fakulteAyarlari.aspx.cs" Inherits="DRS.WebUI.admin.fakulteAyarlari" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Admin</title>

    <link rel="shortcut icon" type="image/png" href="../img/logo.png" />
    <link rel="stylesheet" href="../css/profil.css" type="text/css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>



    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>

    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../js/sweetalert/sweetalert/sweetalert.css" />
    <link href="../css/randevu.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/06da762a55.js"></script>

        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
       <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
        <script src="../js/profilScript.js" type="text/javascript"></script>
	 <script src="../js/randevu.js" ></script>
    <script src="../js/sweetalert/sweetalert/sweetalert-dev.js" ></script>
   <script src="../js/sweetalert/sweetalert/sweetalert.min.js" ></script>
   <script src="../js/Alert.js" ></script>
    <script src="../js/admin.js" ></script>
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
                    <asp:LinkButton CssClass="profilAd" ID="lnkBtnProfil" runat="server" OnClick="lnkBtnProfil_Click"> <i class="fa fa-user"></i>Admin</asp:LinkButton>
                    <asp:LinkButton CssClass="cikisbtn" ID="lnkBtnCikis" runat="server" OnClick="lnkBtnCikis_Click"> <i class="fa fa-sign-out"></i>  Çıkış Yap</asp:LinkButton>

                </div>
            </div>
        </nav>

        <div id="YanMenu" class="sidenav">
            <a href="javascript:void(0)" class="openbtn" onclick="openNav()">&times;</a>
            <a class="deneme" href="admin.aspx"><i class="fa fa-home"></i>  Anasayfa</a>
            <a class="deneme" href="fakulteAyarlari.aspx"><i class="fas fa-cogs"></i> Fakülte Ayarları</a>
		    <a class="deneme" href="bolumAyarlari.aspx"><i class="fas fa-cogs"></i> Bölüm Ayarları</a>
           



        </div>
        
        <div id="YanMenu1" class="sidenav2">

            <a class="deneme" href="admin.aspx"><i class="fa fa-home"></i></a>
            <a class="deneme" href="fakulteAyarlari.aspx"><i class="fas fa-cogs"></i></a>
		    <a class="deneme" href="bolumAyarlari.aspx"><i class="fas fa-cogs"></i></a>
           
        </div>
<div class ="content-wrapper">
        <div class="container" style="margin:80px auto;">
            <div class="row">
                <asp:Button ID="btnIslem" runat="server" Text="" Width="0" Height="0" BorderWidth="0" OnClick="btnIslem_Click" />
        
                <div class ="fakulteAyarlarıTablo ">
                    
                    <asp:Table ID="FakulteTablosu" runat="server" CssClass=" table table-striped table-hover mt-4"> 
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell Scope="Column">#</asp:TableHeaderCell>
                            <asp:TableHeaderCell Scope="Column">Fakülte Ad</asp:TableHeaderCell>
                            <asp:TableHeaderCell Scope="Column">İşlem</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
                <p class = "pUnvan">Fakülte Adı:</p>
                
                <asp:TextBox ID="tbxFakulteAd" CssClass="inputUnvan" runat="server"></asp:TextBox>
                <asp:Button ID="btnFakulteEkle" OnClick="btnFakulteEkle_Click" CssClass="fakulteAyarlariButton" runat="server" Text="Ekle" />
                 
 </div>

 </div>
 </div>
        
	
 
    </form>
</body>
</html>
