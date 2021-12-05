<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iCommissionSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.iReporter.iCommissionSummery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true"
                    OnPageIndexChanging="OnPaging">
                    <Columns>

                        <asp:BoundField DataField="MemberCommssionDetailId" HeaderText="MemberCommssionDetailId" />
                        <asp:BoundField DataField="Branch" HeaderText="Branch" />
                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                        <asp:BoundField DataField="Seq" HeaderText="Seq." />
                        <asp:BoundField DataField="ItemCode" HeaderText="Item" />
                        <asp:BoundField DataField="Commission" HeaderText="Commission" />
                        <asp:BoundField DataField="SalesTarget" HeaderText="SalesTarget" />
                        <asp:BoundField DataField="TargetCommission" HeaderText="TargetCommission" />
                        <asp:BoundField DataField="TotalCommission" HeaderText="TotalCommission" />
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
