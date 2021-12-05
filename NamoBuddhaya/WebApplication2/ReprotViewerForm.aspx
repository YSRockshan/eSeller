<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReprotViewerForm.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportViewerForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Report Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:350px">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
            AutoDataBind="true" HasCrystalLogo="False" />
             <%--onviewzoom="CrystalReportViewer1_ViewZoom"--%>
    </div>
    </form>
</body>
</html>



