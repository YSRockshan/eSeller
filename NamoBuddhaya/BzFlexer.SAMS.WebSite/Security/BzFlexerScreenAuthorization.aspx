<%@ Page Title="" Language="C#" MasterPageFile="~/Security/SecurityHome.master" AutoEventWireup="true" CodeBehind="BzFlexerScreenAuthorization.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Security.BzFlexerScreenAuthorization" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Screen Permission"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <br />
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSecurityGroup" runat="server" Text="Security User Group" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListsecurityGroup" runat="server" CssClass="select"
                        AutoPostBack="true" TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListsecurityGroup_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSystemModule" runat="server" Text="System Module" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSystemModule" runat="server" CssClass="select"
                        AutoPostBack="true" TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="labelSystemModule_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>
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
                                <asp:GridView ID="gridViewAllScreens" runat="server" Caption="All Screens" CssClass="ColStyle"
                                    Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewAllScreens_RowCreated" OnPageIndexChanging="gridViewAllScreens_PageIndexChanging">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" OnCheckedChanged="checkBoxHeader_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkBoxItem" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Screen ID" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
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
                                            <asp:Button ID="buttonAdd" runat="server" Text="Add >>" CssClass="button_normal"
                                                OnClick="buttonAdd_Click" />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="buttonRemove" runat="server" Text="<< Remove" CssClass="button_normal" OnClick="buttonRemove_Click" />
                                        </div>
                                    </li>
                                </ul>
                            </td>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewMappedScreens" runat="server" Caption="Mapped Screens"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewMappedScreens_RowCreated" OnPageIndexChanging="gridViewMappedScreens_PageIndexChanging">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" OnCheckedChanged="checkBoxHeader_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkBoxItem" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Screen ID" />
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Screens.Description") %>'></asp:Label>
                                                <%--<%# DataBinder.Eval(Container.DataItem, "Screen.Description")%>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="propertyDescription" HeaderText="Description" />--%>
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
            <br />
            <li>
                <table width="100%">
                    <tbody>
                        <tr>
                            <td align="right">
                                <Biz:FlashText ID="FlashText1" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </li>
            <%-- <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal" />
                </div>
            </li>--%>
        </ul>
    </fieldset>
</asp:Content>
