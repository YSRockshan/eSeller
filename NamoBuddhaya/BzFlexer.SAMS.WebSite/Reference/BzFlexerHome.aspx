<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerHome.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerHome" %>


<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="../BoostUnit/bootstrap/bootstrap-3.3.7-dist/css/HomeSlides.css" rel="stylesheet" />
    <script src="../BoostUnit/bootstrap/bootstrap-3.3.7-dist/js/bootstrap.js"></script>
    <script src="../BoostUnit/bootstrap/bootstrap-3.3.7-dist/js/slider.js"></script>



</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <div class="w3-content w3-section" style="height: 450px">
        <img class="mySlides" src="../BoostUnit/images/slider/abt.png" style="max-height: 100%; max-width: 100%">
        <img class="mySlides" src="../BoostUnit/images/slider/WelcomeLogin.png" style="max-height: 100%; max-width: 100%">
        <img class="mySlides" src="../BoostUnit/images/slider/fz.png" style="max-height: 100%; max-width: 100%">
        <img class="mySlides" src="../BoostUnit/images/slider/home.png" style="max-height: 100%; max-width: 100%">
        <img class="mySlides" src="../BoostUnit/images/slider/product.png" style="max-height: 100%; max-width: 100%">
        <img class="mySlides" src="../BoostUnit/images/slider/y.png" style="max-height: 100%; max-width: 100%">
    </div>

    <script>
        var myIndex = 0;
        carousel();

        function carousel() {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            myIndex++;
            if (myIndex > x.length) { myIndex = 1 }
            x[myIndex - 1].style.display = "block";
            setTimeout(carousel, 2000); // Change image every 2 seconds
        }
    </script>

    <%--    <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item active">
      <img src="../BoostUnit/images/home/portfolio/02-full.jpg" alt="Los Angeles">
    </div>

    <div class="item">
        <img src="../BoostUnit/images/home/portfolio/03-full.jpg" alt="Chicago">
    </div>

    <div class="item">
    <img src="../BoostUnit/images/home/portfolio/05-thumbnail.jpg"  alt="New York"/>
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>--%>
</asp:Content>
