<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReprotViewerForm.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.Report.ReprotViewerForm" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CrystalReportSource2" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    </form>
</body>
</html>
