<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSalesForecastDetails.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSalesForecastDetails" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Forecast Details"></asp:Label>
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
                <div class="formfield">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewAllProducts" runat="server" Caption="All Products" CssClass="ColStyle"
                                    Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false" PageSize="10"
                                    OnRowCreated="gridViewAllProducts_RowCreated" OnPageIndexChanging="gridViewAllProducts_PageIndexChanging">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" OnCheckedChanged="checkBoxHeader_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkBoxItem" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Product ID" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                            <td align="center" valign="middle">
                                <ul class="form">
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="buttonAdd" runat="server" Text="Add >>" CssClass="button_normal"
                                                OnClick="buttonAdd_Click" />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Button ID="buttonRemove" runat="server" Text="<< Remove" CssClass="button_normal"
                                                OnClick="buttonRemove_Click" />
                                        </div>
                                    </li>
                                </ul>
                            </td>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewMappedProducts" runat="server" Caption="Mapped Products" PageSize="10"
                                    CssClass="ColStyle" Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewMappedProducts_RowCreated" OnPageIndexChanging="gridViewMappedProducts_PageIndexChanging"
                                    OnRowDataBound="gridViewMappedProducts_RowDataBound">
                                    <RowStyle CssClass="RowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkBoxHeader" runat="server" AutoPostBack="true" OnCheckedChanged="checkBoxHeader_CheckedChanged" />
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
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                           <%-- SelectedValue='<%#((!(String.IsNullOrEmpty(Eval( "Type").ToString()))) ? (Eval("Type")):"0" )%>--%>
                                                <asp:DropDownList ID="dropDownListType" runat="server" CssClass="select" AutoPostBack="true"
                                                    OnSelectedIndexChanged="dropDownListType_SelectedIndexChanged" 
                                                    SelectedValue='<%#((!(String.IsNullOrEmpty(Eval( "Type").ToString()))) ? (Eval("Type")):"0" )%>'>
                                                    <asp:ListItem Value="0" Text="-Select-" Selected="True" />
                                                    <asp:ListItem Value="Q" Text="Quantity" />
                                                    <asp:ListItem Value="V" Text="Value" />
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value [LKR]">
                                            <ItemTemplate>
                                                <asp:TextBox ID="textBoxValue" runat="server" Width="50px" MaxLength="50" CssClass="textbox_size2"
                                                    OnTextChanged="TextBox_TextChange" Text='<%#((!(String.IsNullOrEmpty(Eval( "Value").ToString()))) ? String.Format(Eval("Value").ToString(), "{0:000}"):"" )%>'
                                                    Enabled='<%#((!(String.IsNullOrEmpty(Eval( "Type").ToString()))) &&  (Eval("Type")).ToString()=="V" )%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="textBoxQuantity" runat="server" Width="50px" MaxLength="50" CssClass="textbox_size2"
                                                    OnTextChanged="TextBox_TextChange" Text='<%#((!(String.IsNullOrEmpty(Eval("Quantity").ToString()))) ? String.Format(Eval("Quantity").ToString() ,"{0:000}") : "")%>'
                                                    Enabled='<%#((!(String.IsNullOrEmpty(Eval( "Type").ToString()))) &&  (Eval("Type")).ToString()=="Q" )%>'> </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="UnitOfMeasure">
                                            <ItemTemplate>
                                            <%--SelectedValue='<%#((!(String.IsNullOrEmpty(Eval( "UnitOfMeasureId").ToString()))) ? (Eval("UnitOfMeasureId")):0 )%>' --%>
                                                <asp:DropDownList ID="dropDownListUnitOfMeasure" runat="server" CssClass="select"
                                                    Enabled="false" AppendDataBoundItems="true" AutoPostBack="true" >
                                                    <asp:ListItem Value="0" Text="- Select -"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ProductId">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Biz_Products.Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="labelEmptyDataText" runat="server" Text="No Data to Display"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </li>
            <li>
                <div class="formfield">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonSave_Click" />
                </div>
                <br />

            </li>
            
    </fieldset>
</asp:Content>
