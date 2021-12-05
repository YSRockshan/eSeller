<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerProductCode.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerProductCode" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Product Category Product Codes"></asp:Label>
    </div>
    <asp:UpdatePanel ID="updatePanelHeader" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%-- <ul class="form">
                <li>--%>
            <div class="formlabal4">
                <fieldset>
                    <asp:Label ID="labelProCategoryCode" runat="server" Text="Product Category" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCat" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="200px">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </fieldset>
            </div>
            <%--</li>
            </ul>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <br />
            </li>
            <li>
                <div class="formfield">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewAllPropertyCode" runat="server" Caption="All Standard Property Codes"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkBoxItem" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="propertyCode" HeaderText="Property Code" />
                                        <asp:BoundField DataField="propertyDescription" HeaderText="Description" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                            <td align="center" valign="middle">
                                <ul class="form">
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="buttonLefttoRight" runat="server" Text=">" CssClass="button_normal" />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="buttonRighttoLeft" runat="server" Text="<" CssClass="button_normal" />
                                        </div>
                                    </li>
                                </ul>
                            </td>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewMappedPropertyCode" runat="server" Caption="Mapped Standard Property Codes"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkBoxItem" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="propertyCode" HeaderText="Property Code" />
                                        <asp:BoundField DataField="propertyDescription" HeaderText="Description" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal" />
                </div>
            </li>
        </ul>
    </fieldset>
</asp:Content>