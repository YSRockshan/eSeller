<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerCoperate.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerCoperate" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Corporate Stakeholder Details"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewCorporateDetail" runat="server" Caption="Corporate Stakeholder Details"
                        CssClass="ColStyle" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                        AllowPaging="true" Width="98%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ButtonType="Image" SelectImageUrl="../Styles/images/Select.png" />
                            <asp:BoundField DataField="Id" HeaderText="Stakehlder ID" />
                            <asp:BoundField DataField="StakeholderName" HeaderText="Stakeholder Name" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonModify" runat="server" Text="Modify" CssClass="button_normal" />
                    <asp:Button ID="buttonDelete" runat="server" Text="Active/Inactive" CssClass="button_normal" />
                </div>
            </li>
        </ul>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="formfield">
                    <asp:Label ID="labelTitle" runat="server" Text="Title" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListTitle" runat="server" CssClass="select" Width="10%">
                        <asp:ListItem Text="Mess" Value="Mess" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelCompanyName" runat="server" Text="Company Name" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxCompanyName" runat="server" CssClass="textbox_size2" Width="50%"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelCountry" runat="server" Text="Country" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListCountry" runat="server" CssClass="select" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProvince" runat="server" Text="Province" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProvince" runat="server" CssClass="select" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelDistric" runat="server" Text="Distric" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListDistric" runat="server" CssClass="select" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelPostalTown" runat="server" Text="Postal Town" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListPostalTown" runat="server" CssClass="select" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelAddress" runat="server" Text="Contact Address" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxAddress" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelLane" runat="server" Text="Lane" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxLAne" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelRoad" runat="server" Text="Road" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxRoad" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelTown" runat="server" Text="Town" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxTown" runat="server" CssClass="textbox_size2" Width="25%"
                        Enabled="false"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBusinessRegNo" runat="server" Text="Business Registration No"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxBusinessRegNo" runat="server" CssClass="textbox_size2" Width="25%">
                    </asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelRegisterDate" runat="server" Text="Registration Date" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxRegisterDate" runat="server" CssClass="textbox_size2" Width="25%">
                    </asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelOfficeTelephone" runat="server" Text="Contact No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxOfficeTelephone" runat="server" CssClass="textbox_size2" />
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelStakeholderType" runat="server" Text="Stakeholder Type" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListStakeholderType" runat="server" CssClass="select"
                        Width="20%">
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelStakeholderStatus" runat="server" Text="Stakeholder Status" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListStakeholderStatus" runat="server" CssClass="select"
                        Width="20%">
                        <asp:ListItem Value="A" Text="Active" Enabled="true"></asp:ListItem>
                        <asp:ListItem Value="I" Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonAdd" runat="server" Text="Add" CssClass="button_normal" />
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal" />
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>
    <br />
</asp:Content>
