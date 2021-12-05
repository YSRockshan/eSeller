<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportShTypeSecurityGroup.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.Security.Rep.ReportShTypeSecurityGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div>
            <div>
                    <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true"
                    OnPageIndexChanging="OnPaging">
                          <Columns>
                                       
                                        <asp:BoundField DataField="IdStakeholderType" HeaderText="StakeholderTypeId" />
                                        <asp:TemplateField HeaderText="Stakeholder Type">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_StakeholderTypes.Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
    
            </div>
            <br />
            <asp:Button ID="btnExportWord" runat="server" Text="ExportToWord" OnClick="btnExportWord_Click" />
            &nbsp;
        <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel" OnClick="btnExportExcel_Click" />
            &nbsp;
        <asp:Button ID="btnExportPDF" runat="server" Text="ExportToPDF" OnClick="btnExportPDF_Click" />
            &nbsp;
        <asp:Button ID="Button1" runat="server" Text="ExportToCSV" OnClick="btnExportCSV_Click" />
        </div>
    </form>
</body>
</html>
