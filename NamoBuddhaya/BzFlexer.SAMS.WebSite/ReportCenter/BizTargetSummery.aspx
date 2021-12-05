<%@ Page Title="" Language="C#" MasterPageFile="~/ReportCenter/ReportHome.master" AutoEventWireup="true" CodeBehind="BizTargetSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.BizTargetSummery" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%--<div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Target Summary"></asp:Label>
    </div>
    <fieldset>
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
                <br />
            </li>
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSalesTargetSummary" runat="server" Caption="Sales Target Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="10"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesTargetSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesTargetSummary_PageIndexChanging">
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
    </fieldset>--%>

     <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Stakeholder Details"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewEmployeeDetail" runat="server" Caption="Stakeholder Details"
                        CssClass="ColStyle" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                        AllowPaging="true" Width="99.6%" >
                        <%--OnRowCreated="gridViewEmployeeDetail_RowCreated"
                        OnSelectedIndexChanged="gridViewEmployeeDetail_SelectedIndexChanged" OnPageIndexChanging="gridViewEmployeeDetail_PageIndexChanging">--%>
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
                    <asp:Button ID="buttonPrint" runat="server" Text="Print" CssClass="button_normal"
                        TabIndex="6" OnClick="buttonPrint_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        TabIndex="8" OnClick="buttonCancel_Click" />
                </div>
            </li>
        </ul>
    </fieldset>

</asp:Content>
