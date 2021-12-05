<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerEmployee.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerEmployee" %>


<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Stakeholder Details"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewEmployeeDetail" runat="server" Caption="Stakeholder Details"
                        CssClass="ColStyle" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                        AllowPaging="true" Width="99.6%" OnRowCreated="gridViewEmployeeDetail_RowCreated"
                        OnSelectedIndexChanged="gridViewEmployeeDetail_SelectedIndexChanged" OnPageIndexChanging="gridViewEmployeeDetail_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="Stakehlder ID" />
                            <asp:BoundField DataField="FullName" HeaderText="Stakeholder Name" />
                            <asp:TemplateField HeaderText="Default Stakeholder Type">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_StakeholderTypes.Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonModify" runat="server" Text="Modify" CssClass="button_normal"
                        OnClick="buttonModify_Click" />
                    <asp:Button ID="buttonActiveInactive" runat="server" Text="A/I" CssClass="button_normal"
                        OnClick="buttonActiveInactive_Click" />
                    <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                        OnClick="buttonDelete_Click" />
                </div>
            </li>
        </ul>
    </fieldset>
    <br />
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
                <div class="formfield">
                    <asp:Label ID="labelTitle" runat="server" Text="Title" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListTitle" runat="server" CssClass="select" Width="10%">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                        <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                        <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                        <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                        <asp:ListItem Text="Ven" Value="Ven"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelFullName" runat="server" Text="Name in Full" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxFullName" runat="server" CssClass="textbox_size2" Width="50%"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelLastName" runat="server" Text="Last Name" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxLastName" runat="server" CssClass="textbox_size2" Width="25%"
                        Enabled="false"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelInitials" runat="server" Text="Initials" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxInitials" runat="server" CssClass="textbox_size2" Width="25%"
                        Enabled="false"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <%-- <li>
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
            </li>--%>
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
                    <asp:TextBox ID="textBoxLane" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
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
                    <asp:Label ID="labelNicNo" runat="server" Text="NIC No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxNicNo" runat="server" CssClass="textbox_size2" Width="25%">
                    </asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelDateOfBirth" runat="server" Text="Date of Birth" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxDateOfBirth" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox><cc1:CalendarExtender
                        runat="server" ID="calendarExtenderDateOfBirth" TargetControlID="textBoxDateOfBirth"
                        PopupButtonID="textBoxDateOfBirth">
                    </cc1:CalendarExtender>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <asp:Label ID="labelGender" runat="server" Text="Gender" CssClass="legendlabel_size2"></asp:Label>
                <asp:RadioButtonList ID="radioButtonListGender" runat="server" CssClass="radiobuttons"
                    AutoPostBack="true" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M" Text="Male" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="F" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelPassportNo" runat="server" Text="Passport No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxPassportNo" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelMaritualStatus" runat="server" Text="Maritual Status" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListMaritualStatus" runat="server" CssClass="select"
                        Width="20%">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="UnMarried" Text="UnMarried" Enabled="true"></asp:ListItem>
                        <asp:ListItem Value="Married" Text="Married"></asp:ListItem>
                        <asp:ListItem Value="Divorced" Text="Divorced"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelDesignation" runat="server" Text="Designation" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxDesignation" runat="server" CssClass="textbox_size2" Width="30%"></asp:TextBox>
                    <%--<asp:DropDownList ID="dropDownListDesignation" runat="server" CssClass="select" Width="30%">
                    </asp:DropDownList>--%>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labeEpfNo" runat="server" Text="EPF No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxEpfNo" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelEtfNo" runat="server" Text="ETF No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxEtfNo" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelHomeTelepnone" runat="server" Text="Home Telephone No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxHomeTelepnone" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelMobile" runat="server" Text="Mobile No" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxMobile" runat="server" CssClass="textbox_size2" Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelEmail" runat="server" Text="E-mail Address" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxEmail" runat="server" CssClass="textbox_size2" Width="50%"></asp:TextBox>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelOfficeTelephone" runat="server" Text="Official Telephone No"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxOfficeTelephone" runat="server" CssClass="textbox_size2"
                        Width="25%"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBranch" runat="server" Text="Default Branch" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListBranch" runat="server" CssClass="select" Width="20%"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelStakeholderType" runat="server" Text="Default Stakeholder Type"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListStakeholderType" runat="server" CssClass="select"
                        Width="20%" AppendDataBoundItems="true">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelEmployeeStatus" runat="server" Text="Employee Status" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListEmployeeStatus" runat="server" CssClass="select"
                        Width="20%">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="A" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="I" Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonAdd" runat="server" Text="Add" CssClass="button_normal" OnClick="buttonAdd_Click" />
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonSave_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        OnClick="buttonCancel_Click" />
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>
    <br />
</asp:Content>
