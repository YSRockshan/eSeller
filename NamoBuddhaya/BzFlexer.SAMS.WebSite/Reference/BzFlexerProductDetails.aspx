<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerProductDetails.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerProductDetails" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Product Details"></asp:Label>
    </div>
    <fieldset>
        <div class="formfield">
            <asp:Label ID="labelProductCategory" runat="server" Text="Product Category" CssClass="legendlabel_size2"></asp:Label>
            <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                Width="30%">
            </asp:DropDownList>
        </div>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewProductDetail" runat="server" Caption="Product Details"
                        CssClass="ColStyle" EmptyDataText="No data to display" AllowPaging="True" PageSize="10"
                        Width="99.6%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:TemplateField HeaderText="Value"></asp:TemplateField>
                            <%-- <asp:BoundField DataField="Value" HeaderText="Value" />--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>
</asp:Content>