<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iBudgetSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.iReporter.iBudgetSummery" %>

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
                        <asp:BoundField DataField="Id" HeaderText="SalesBudgetDetaild" />
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Biz_Branches.Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Products.Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="Value" HeaderText="Value [LKR]" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:TemplateField HeaderText="UnitOfMeasure">
                            <ItemTemplate>
                                <asp:Label ID="LabelUnitOfMeasure" runat="server" Text='<%# Bind("Biz_UnitOfMeasures.Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sales Budget">
                            <ItemTemplate>
                                <asp:Label ID="LabelSalesBudget" runat="server" Text='<%# Bind("Biz_SalesBudgets.Description") %>'></asp:Label>
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
