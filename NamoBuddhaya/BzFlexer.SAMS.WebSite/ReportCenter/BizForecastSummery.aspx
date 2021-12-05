<%@ Page Title="" Language="C#" MasterPageFile="~/ReportCenter/ReportHome.master" AutoEventWireup="true" CodeBehind="BizForecastSummery.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.BizForecastSummery" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Forecast Summary"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesForecast" runat="server" Text="Sales Forecast" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesForecast" runat="server" CssClass="select"
                        AutoPostBack="true" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesForecast_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
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
                    <asp:GridView ID="gridViewSalesForecastSummary" runat="server" Caption="Sales Forecast Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="10"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesForecastSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesForecastSummary_PageIndexChanging">
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
                            <asp:BoundField DataField="Id" HeaderText="SalesForecastDetaild" />
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Products.Description") %>'></asp:Label>
                                    <%--<%# DataBinder.Eval(Container.DataItem, "StandardProperty.Description")%>--%>
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
