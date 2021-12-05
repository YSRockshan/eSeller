<%@ Page Title="" Language="C#" MasterPageFile="~/ReportCenter/ReportHome.master" AutoEventWireup="true" CodeBehind="BizCommissionSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.BizCommissionSummery" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Commission Summary"></asp:Label>
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
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesTarget" runat="server" Text="Sales Person" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesPerson" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesPerson_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProductCategory" runat="server" Text="Product Category" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                        AutoPostBack="true" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSubProductCategory" runat="server" Text="Sub Product Category"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSubProductCategory" runat="server" CssClass="select"
                        AutoPostBack="true" AppendDataBoundItems="true" Width="30%" OnSelectedIndexChanged="dropDownListSubProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProduct" runat="server" Text="Product" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProduct" runat="server" CssClass="select" AutoPostBack="true"
                        AppendDataBoundItems="true" Width="30%" OnSelectedIndexChanged="dropDownListProduct_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="0" Selected="True"></asp:ListItem>
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
                    <asp:GridView ID="gridViewSalesCommissionSummary" runat="server" Caption="Sales Target Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="10"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesTCommssionSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesCommissionSummary_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="MemberCommssionDetailId" HeaderText="MemberCommssionDetailId" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" />
                            <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                            <asp:BoundField DataField="Seq" HeaderText="Seq." />
                            <asp:BoundField DataField="ItemCode" HeaderText="Item" />
                            <asp:BoundField DataField="Commission" HeaderText="Commission" />
                            <asp:BoundField DataField="SalesTarget" HeaderText="SalesTarget" />
                            <asp:BoundField DataField="TargetCommission" HeaderText="TargetCommission" />
                            <asp:BoundField DataField="TotalCommission" HeaderText="TotalCommission" />
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
            </ul>
    </fieldset>

</asp:Content>
