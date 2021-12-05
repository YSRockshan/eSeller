<%@ Page Title="" Language="C#" MasterPageFile="~/Security/SecurityHome.master" AutoEventWireup="true" CodeBehind="BzFlexerShTypeSecurityGroup.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Security.BzFlexerShTypeSecurityGroup" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Security User Group Stakeholder Type"></asp:Label>
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
                                <asp:GridView ID="gridViewAllStakeholderType" runat="server" Caption="All Stakeholder Types"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewAllStakeholderType_RowCreated" OnPageIndexChanging="gridViewAllStakeholderType_PageIndexChanging">
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
                                        <asp:BoundField DataField="Id" HeaderText="Stakeholder TypeID" />
                                        <asp:BoundField DataField="Description" HeaderText="Stakeholder Type" />
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
                                            <asp:Button ID="buttonRemove" runat="server" Text="<< Remove" CssClass="button_normal"
                                                OnClick="buttonRemove_Click" />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="Print" runat="server" Text="Print" CssClass="button_normal"
                                                OnClick="buttonPrint_Click" />
                                        </div>
                                    </li>
                                </ul>
                            </td>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewMappedStakeholderType" runat="server" Caption="Mapped Stakeholder Types"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewMappedStakeholderType_RowCreated" OnPageIndexChanging="gridViewMappedStakeholderType_PageIndexChanging">
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
        </ul>
    </fieldset>
</asp:Content>
