<%@ Page Title="" Language="C#" MasterPageFile="~/ReportCenter/ReportHome.master" AutoEventWireup="true" CodeBehind="BizBudgetSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.BizBudgetSummery" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--   
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Budget Summary"></asp:Label>
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
                    <asp:Label ID="labelSalesBudget" runat="server" Text="Sales Budget" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesBudget" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesBudget_SelectedIndexChanged">
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
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    <asp:GridView ID="gridViewSalesBudgetSummary" runat="server" Caption="Sales Budget Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="10"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesBudgetSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesBudgetSummary_PageIndexChanging">
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
                            <asp:BoundField DataField="Id" HeaderText="SalesBudgetDetaild" />
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Biz_Branches.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Products.Description") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Sales Budget">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesBudget" runat="server" Text='<%# Bind("Biz_SalesBudgets.Description") %>'></asp:Label>
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
    </fieldset>
--%>
    
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Budget Summary"></asp:Label>
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
                    <asp:Label ID="labelSalesBudget" runat="server" Text="Sales Budget" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesBudget" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesBudget_SelectedIndexChanged">
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
                    <asp:GridView ID="gridViewSalesBudgetSummary" runat="server" Caption="Sales Budget Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="10"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesBudgetSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesBudgetSummary_PageIndexChanging">
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
                            <asp:BoundField DataField="Id" HeaderText="SalesBudgetDetaild" />
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Biz_Branches.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Products.Description") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Sales Budget">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesBudget" runat="server" Text='<%# Bind("Biz_SalesBudgets.Description") %>'></asp:Label>
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
    </fieldset>

</asp:Content>

