<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerCommissionsCal.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerCommissionsCal" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Commission Calculation"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <br />
                <div class="formlable">
                    <asp:Label ID="labelLastProcessDate" runat="server" Text="Process Date" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxTransactionDate" runat="server" CssClass="textbox_size1"
                        Enabled="false"></asp:TextBox>
                    <asp:Button ID="buttonQuery" runat="server" Text="Query" Enabled="true" CssClass="button_normal"
                        TabIndex="3" OnClick="buttonQuery_Click" />
                </div>
            </li>
            <%-- <li>
                <div class="formlable">
                    <asp:Label ID="labelEffectiveDate" runat="server" Text="Process Date" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBox1" runat="server" CssClass="textbox_size1"></asp:TextBox>
                    <cc1:CalendarExtender ID="calendarExtenderDateOfBirth" runat="server" Enabled="True"
                        PopupButtonID="textBoxTransactionDate" TargetControlID="textBoxTransactionDate">
                    </cc1:CalendarExtender>
                    <asp:Button ID="buttonQuery" runat="server" Text="Query" Enabled="true" CssClass="button_normal"
                        TabIndex="3" OnClick="buttonQuery_Click" />
                </div>
            </li>--%>
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
                <div class="formlable" align="center">
                    <asp:TextBox ID="textBoxMessage" runat="server" CssClass="messageText" Enabled="false"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewCommissionProcess" runat="server" Caption="Invoice" CssClass="ColStyle"
                        Width="99.6%" EmptyDataText="No data to display" AutoGenerateColumns="false"
                        AllowPaging="True" OnPageIndexChanging="gridViewCommissionProcess_PageIndexChanging"
                        OnRowCreated="gridViewCommissionProcess_RowCreated" PageSize="10">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="InvoiceId" />
                            <asp:TemplateField HeaderText="Invoice No">
                                <ItemTemplate>
                                    <asp:Label ID="InvoiceNo" runat="server" Text='<%# ( Eval( "Biz_SalesTransactions")==null ?"" :Eval( "Biz_SalesTransactions.Invoice_No") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="serialNo" HeaderText="Seq." />
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="InventoryItemCode" runat="server" Text='<%# ( Eval( "Biz_InventoryItems")==null ?"" :Eval( "Biz_InventoryItems.CodeInventoryItem") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCode" runat="server" Text='<%# (( Eval( "Biz_BranchProducts.Product")==null)?"" :Eval( "Biz_BranchProducts.Biz_Products.Description") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" FooterStyle-HorizontalAlign="Right"
                                SortExpression="OrginalBelop" ItemStyle-HorizontalAlign="Right" />
                            <asp:TemplateField HeaderText="Unit of Measure">
                                <ItemTemplate>
                                    <asp:Label ID="LabelUnitofMeasure" runat="server" Text='<%# (( Eval( "Biz_UnitOfMeasures")==null)?"" :Eval( "Biz_UnitOfMeasures.Symbol") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Total_Value" HeaderText="TotalValue" DataFormatString="{0:n2}"
                                FooterStyle-HorizontalAlign="Right" SortExpression="OrginalBelop" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="SalesTarget">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesTargetId" runat="server" Text='<%# ( ( Eval( "Biz_SalesTargets")==null)?"" :Eval( "Biz_SalesTargets.Description ") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyGridText" runat="server" Text="No data to display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <div class="buttonlist2">
                    <asp:Button ID="buttonProcess" runat="server" Text="Process" Enabled="true" CssClass="button_normal"
                        OnClick="buttonProcess_Click" />
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
</asp:Content>
