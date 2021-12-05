<%@ Page Title="" Language="C#" MasterPageFile="~/Home/BizFlexer.Master" AutoEventWireup="true" CodeBehind="BizFlexerHome.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Home.BizFlexerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootstrap core CSS -->
   <%-- <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>--%>

    <!-- Custom styles for this template -->
    <link href="../BoostUnit/bootstrap/bootstrap-3.3.7-dist/css/agency.min.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="masthead" style="background-image:url('../BoostUnit/images/home/header-bg.jpg')" />
      <div class="container">
        <div class="intro-text">
          <div class="intro-lead-in">Welcome To eSeller</div>
          <div class="intro-heading">It's Nice To Meet You</div>
          <%--<a class="btn btn-xl js-scroll-trigger" href="#services">Tell Me More</a>--%>
             <asp:Button ID="buttonReferenceData"  runat="server" Text="Reference "   class="btn btn-xl js-scroll-trigger" 
                                    ToolTip="Reference Data" OnClick="buttonReferenceData_Click" />
            <asp:Button ID="buttonSalesAgent" runat="server" Text="Sales Agents Management" class="btn btn-xl js-scroll-trigger" 
                                    ToolTip="Sales Agents" OnClick="buttonSalesAgent_Click" />
 <asp:Button ID="buttonReport" runat="server" Text="Report Center" class="btn btn-xl js-scroll-trigger"  ToolTip="Report Center" OnClick="buttonReport_Click" />
<asp:Button ID="buttonSecurity" runat="server" Text="Security " class="btn btn-xl js-scroll-trigger"  ToolTip="Security " OnClick="buttonSecurity_Click" />
                    
           <%-- <a class="btn btn-xl js-scroll-trigger" href="#services">Tell Me More</a>--%>
        </div>
      </div>
    </header>
</asp:Content>
