<%@ Page Title="" Language="C#" MasterPageFile="~/Report/Report.master" AutoEventWireup="true" CodeBehind="Biz_SalesSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.Biz_SalesSummery" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderProgramTree" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Sales Summary"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBranch" runat="server" Text="Branch" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListBranch" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListBranch_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesPerson" runat="server" Text="Sales Person" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesPerson" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesPerson_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProductCategory" runat="server" Text="Product Category" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                        AutoPostBack="true" TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSubProductCat" runat="server" Text="Sub Product Category" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSubProductCat" runat="server" CssClass="select"
                        AutoPostBack="true" AppendDataBoundItems="true" TabIndex="1" Width="200px" OnSelectedIndexChanged="dropDownListSubProductCat_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProduct" runat="server" Text="Genaral Product" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListProduct" runat="server" CssClass="select" AutoPostBack="true"
                        AppendDataBoundItems="true" TabIndex="1" Width="200px" OnSelectedIndexChanged="dropDownListProduct_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesTarget" runat="server" Text="Sales Target" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesTarget" runat="server" CssClass="select" AutoPostBack="true"
                        AppendDataBoundItems="true" TabIndex="1" Width="200px" OnSelectedIndexChanged="dropDownListSalesTarget_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
    <table width="100%">
        <tbody>
            <tr>
                <td align="right">
                        <Biz:FlashText ID="FlashText1" runat="server" />
                    </td>
            </tr>
        </tbody>
    </table>
    <fieldset>
        <ul class="form">
            <li>
                <%--Load Sales Budget Data to grid view--%>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSalesSummary" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        Caption="Sales Summary" CssClass="ColStyle" EmptyDataText="No Data to Display"
                        PageSize="10" Width="99.6%" OnRowCreated="gridViewSalesSummary_RowCreated" OnPageIndexChanging="gridViewSalesSummary_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                SelectImageUrl="~/styles/images/select.png" />
                                <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" />
                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="Product" HeaderText="Product" />
                                <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                <asp:BoundField DataField="PriceBook" HeaderText="Price Book" />
                                <asp:BoundField DataField="SalesTarget" HeaderText="Sales Target" />
                                <asp:BoundField DataField="Gross" HeaderText="Gross" />
                                <asp:BoundField DataField="Discount" HeaderText="Discount" />
                                <asp:BoundField DataField="Net" HeaderText="Net" />
                            <%--<asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" />
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Branch.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="LabelProduct" runat="server" Text='<%# Bind("BranchProduct.Product.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Code">
                                <ItemTemplate>
                                    <asp:Label ID="LabelItem" runat="server" Text='<%# Bind("InventoryItem.InventoryItemCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PriceBook">
                                <ItemTemplate>
                                    <asp:Label ID="LabelPriceBook" runat="server" Text='<%# Bind("BranchPriceBook.PriceBook.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SalesTarget">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesTarget" runat="server" Text='<%# Bind("SalesTarget.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gross">
                                <ItemTemplate>
                                    <asp:Label ID="LabelGross" runat="server" Text='<%# Bind("TotalValue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discount">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDiscount" runat="server" Text='<%# Bind("DiscountValue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonPrint" runat="server" Text="Print" CssClass="button_normal"
                        TabIndex="6" OnClick="buttonPrint_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        TabIndex="8" OnClick="buttonCancel_Click" />
                </div>
            </li>
        </ul>
    </fieldset>
</asp:Content>
