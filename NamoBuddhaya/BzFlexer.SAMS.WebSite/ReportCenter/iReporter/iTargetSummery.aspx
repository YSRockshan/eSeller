<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iTargetSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.iReporter.iTargetSummery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="GridView1" runat="server" Caption="Stakeholder Details"
                        CssClass="ColStyle" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                        AllowPaging="true" Width="99.6%" >
                        <%--OnRowCreated="gridViewEmployeeDetail_RowCreated"
                        OnSelectedIndexChanged="gridViewEmployeeDetail_SelectedIndexChanged" OnPageIndexChanging="gridViewEmployeeDetail_PageIndexChanging">--%>
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="Stakehlder ID" />
                            <asp:BoundField DataField="FullName" HeaderText="Stakeholder Name" />
                            <%--<asp:TemplateField HeaderText="Default Stakeholder Type">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_StakeholderTypes.Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
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
