<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSalesTargetsDetail.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSalesTargetsDetail" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Target Details"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBranch" runat="server" Text="Branch" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListBranch" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListBranch_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSalesTarget" runat="server" Text="Sales Target" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSalesTarget" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSalesTarget_SelectedIndexChanged">
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
                        AutoPostBack="true" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSubProductCategory_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProduct" runat="server" Text="Genaral Product"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProduct" runat="server" CssClass="select"
                        AutoPostBack="true" Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListProduct_SelectedIndexChanged">
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
                <br />
            </li>
            <li>
                <div class="formfield">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="gridViewAllInventoryItems" runat="server" Caption="All Inventory Items" CssClass="ColStyle"
                                    Width="250px" EmptyDataText="No Data to Display" AutoGenerateColumns="false"
                                    OnRowCreated="gridViewAllInventoryItems_RowCreated" OnPageIndexChanging="gridViewAllInventoryItems_PageIndexChanging">
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
                                        <asp:BoundField DataField="Id" HeaderText="InventoryItemId" />
                                        <asp:BoundField DataField="CodeInventoryItem" HeaderText="Inventory Item" />
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
                                <asp:GridView ID="gridViewMappedInventoryItem" runat="server" Caption="Mapped Items"
                                    CssClass="ColStyle" Width="250px" PageSize="10" EmptyDataText="No Data to Display"
                                    AutoGenerateColumns="false" OnRowCreated="gridViewMappedInventoryItem_RowCreated"
                                    OnPageIndexChanging="gridViewMappedInventoryItem_PageIndexChanging" OnRowDataBound="gridViewMappedInventoryItem_RowDataBound">
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
                                        <asp:BoundField DataField="Id" HeaderText="SalesTargetDetailId" />
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelDescriptions" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Biz_InventoryItems.CodeInventoryItem")%>'></asp:Label>
                                                <%--<%# DataBinder.Eval(Container.DataItem, "StandardProperty.Description")%>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="dropDownListType" runat="server" CssClass="select" Enabled="false" AutoPostBack="true"
                                                    OnSelectedIndexChanged="dropDownListType_SelectedIndexChanged" SelectedValue='<%#((!(String.IsNullOrEmpty(Eval("Type").ToString()))) ? (Eval("Type")):"0" )%>'>
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
                                                <%--SelectedValue='<%#((!(String.IsNullOrEmpty(Eval( "UnitOfMeasureId").ToString()))) ? (Eval("UnitOfMeasureId")):0 )%>'--%>
                                                <asp:DropDownList ID="dropDownListUnitOfMeasure" runat="server" CssClass="select"
                                                    Enabled="true" AppendDataBoundItems="true" AutoPostBack="true">
                                                    <asp:ListItem Value="0" Text="- Select -"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ProductId">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Biz_InventoryItems.Biz_Products.Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Value" HeaderText="Amount" />

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
                <div class="buttonlist2">
                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonSave_Click" />
                </div>
            </li>
        </ul>
    </fieldset>
</asp:Content>
