<%@ Page Title="" Language="C#" MasterPageFile="~/ReportCenter/ReportHome.master" AutoEventWireup="true" CodeBehind="BizCommissionChart.aspx.cs" Inherits="BzFlexer.SAMS.WebSite.ReportCenter.BizCommissionChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Commission Chart"></asp:Label>
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
                    <asp:Label ID="labelDateFrom" runat="server" Text="Date From" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxDateFrom" runat="server" CssClass="textbox_size2" Width="18%"></asp:TextBox><cc1:CalendarExtender
                        runat="server" ID="calendarExtenderDateFrom" TargetControlID="textBoxDateFrom"
                        PopupButtonID="textBoxDateFrom"></cc1:CalendarExtender>
                    <%-- </div>
                <div>--%>
                    <asp:Label ID="labelDateTo" runat="server" Text="Date To"></asp:Label>
                    <asp:TextBox ID="textBoxDateTo" runat="server" CssClass="textbox_size2" Width="18%"></asp:TextBox><cc1:CalendarExtender
                        runat="server" ID="calendarExtenderDateTo" TargetControlID="textBoxDateTo" PopupButtonID="textBoxDateTo"></cc1:CalendarExtender>
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
                <div class="gridfield">
                    <asp:GridView ID="gridViewSalesCommissionSummary" runat="server" Caption="Sales Target Summary"
                        AllowPaging="true" AutoGenerateColumns="false" CssClass="ColStyle" PageSize="5"
                        Width="99.6%" EmptyDataText="No Data to Display" OnRowCreated="gridViewSalesTCommssionSummary_RowCreated"
                        OnPageIndexChanging="gridViewSalesCommissionSummary_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                SelectImageUrl="~/styles/images/select.png" />
                            <asp:BoundField DataField="SalesRepId" HeaderText="MemberCommssionDetailId" />
                            <asp:BoundField DataField="SalesPerson" HeaderText="Sales Person" />
                            <asp:BoundField DataField="TotalCommission" HeaderText="Total Commission" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
            <li>
                <div class="gridfield">
                    <asp:Chart ID="CommissionChart" runat="server" Height="360px" Width="660px">
                        <Series>
                            <asp:Series Name="Testing" YValueType="Int32" ChartArea="DefaultChartArea" ChartType="Column"
                                Palette="SeaGreen"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="DefaultChartArea" BorderColor="DarkRed" BackColor="White">
                                <AxisY Title="Commssion [Rs.]">
                                </AxisY>
                                <AxisX Interval="1" Title="Sales Officers">
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>

           
                </div>
            </li>
            <%--<li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonPrint" runat="server" Text="Print" CssClass="button_normal"
                        TabIndex="6" OnClick="buttonPrint_Click" />
                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                        TabIndex="8" OnClick="buttonCancel_Click" />
                </div>
            </li>--%>
        </ul>
    </fieldset>

</asp:Content>
