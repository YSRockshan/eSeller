<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSingleRateCommissions.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSingleRateCommissions" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Single Rate Commission"></asp:Label>
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
                    <asp:GridView ID="gridViewSingleRate" runat="server" Caption="Single Rate" CssClass="ColStyle"
                        EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                        AutoGenerateColumns="false" OnRowCreated="gridViewSingleRate_RowCreated" OnPageIndexChanging="gridViewSingleRate_PageIndexChanging"
                        OnSelectedIndexChanged="gridViewSingleRate_SelectedIndexChanged">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="SingleRateId" />
                            <%--<asp:TemplateField HeaderText="RateMode">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSingleRateMode" runat="server" Text='<%#  ((Eval( "RateMode")==null)?"" :((Eval( "RateMode").ToString().Trim()=="T")?"Total Sales":"Sales Profit"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="LabelStatus" runat="server" Text='<%#  ((Eval( "Status")==null)?"" :((Eval( "Status").ToString().Trim()=="A")?"Active":"Inactive"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="formlable">
                  <%--  <asp:Label ID="labelRateMode" runat="server" Text="" CssClass="legendlabel_size2"></asp:Label>
                    <asp:RadioButtonList ID="radioButtonListRateMode" runat="server" CssClass="radiobuttons"
                        AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="radioButtonListRateMode_SelectedIndexChanged">
                        <asp:ListItem Value="T" Text="Total Sales" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="P" Text="Sales Profit"></asp:ListItem>
                    </asp:RadioButtonList>--%>
                    <asp:HiddenField ID="hiddenFieldSingleRate" runat="server" />
                </div>
            </li>
            <li>
                <div class="formlable">
                    <asp:Label ID="labelRate" runat="server" Text="Rate" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxRate" runat="server" Width="10%" MaxLength="50" TabIndex="2"
                        Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                    <font color="#FF0000">*</font>
                    <asp:HiddenField ID="hiddenFieldstatus" runat="server"  />
                </div>
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonActInct" runat="server" Text="A / I" Enabled="true" CssClass="button_normal"
                        OnClick="buttonActInct_Click" />
                    <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                        OnClick="buttonSave_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        TabIndex="4" OnClick="buttonCancel_Click" />
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
</asp:Content>
