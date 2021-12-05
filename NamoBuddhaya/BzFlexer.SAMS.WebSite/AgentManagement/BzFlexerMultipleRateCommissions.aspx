<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerMultipleRateCommissions.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerMultipleRateCommissions" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Multiple Rate Commission"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelCommission" runat="server" Text="Commission" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListCommission" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListCommission_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
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
                <div class="gridfield">
                    <asp:GridView ID="gridViewMultipleRate" runat="server" Caption="Multiple Rates" CssClass="ColStyle"
                        EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                        AutoGenerateColumns="false" OnRowCreated="gridViewMultipleRate_RowCreated">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="SlabDetaiId" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Slab_From" HeaderText="Slab From" />
                            <asp:BoundField DataField="Slab_To" HeaderText="Slab To" />
                            <asp:BoundField DataField="Rate" HeaderText="Commission Rate (%)" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="formlable">
                    <asp:Label ID="labelSlab" runat="server" Text="Slab" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSlab" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSlab_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                     <asp:HiddenField ID="hiddenFieldSlabEdit" runat="server" />
                     <asp:HiddenField ID="hiddenFieldSlabDetailEdit" runat="server" />
                </div>
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal" OnClick="buttonSave_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        TabIndex="4" OnClick="buttonCancel_Click" />
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
</asp:Content>
