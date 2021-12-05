<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.iReporter.WebForm1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Target Summary"></asp:Label>
    </div>
<%--    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBranch" runat="server" Text="Branch" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListBranch" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListBranch_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesTarget" runat="server" Text="Sales Target" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesTarget" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesTarget_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProductCategory" runat="server" Text="Product Category" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                        AutoPostBack="true" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSubProductCategory" runat="server" Text="Sub Product Category"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSubProductCategory" runat="server" CssClass="select"
                        AutoPostBack="true" AppendDataBoundItems="true" Width="30%" OnSelectedIndexChanged="dropDownListSubProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>--%>
        <div>
            <div>
                    <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true"
                    OnPageIndexChanging="OnPaging"
                        >
                        <Columns>
                           <%-- <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkBoxItem" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="Id" HeaderText="SalesTargetDetaild" />
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Biz_Branches.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_InventoryItems.Description") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Sales Target">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesTarget" runat="server" Text='<%# Bind("Biz_SalesTargets.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
        <%--        <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true"
                    OnPageIndexChanging="OnPaging">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="150px" DataField="IdUnitOfMeasure" HeaderText="CustomerID" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="IdUnitOfMeasure" HeaderText="City" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Value" HeaderText="Country" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Type" HeaderText="PostalCode" />
                    </Columns>
                </asp:GridView>--%>
            </div>
            <br />
            <asp:Button ID="btnExportWord" runat="server" Text="ExportToWord" OnClick="btnExportWord_Click" />
            &nbsp;
        <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel" OnClick="btnExportExcel_Click" />
            &nbsp;
        <asp:Button ID="btnExportPDF" runat="server" Text="ExportToPDF" OnClick="btnExportPDF_Click" />
            &nbsp;
        <asp:Button ID="Button1" runat="server" Text="ExportToCSV" OnClick="btnExportCSV_Click" />
    </form>
    </div>
    </form>
</body>
</html>
