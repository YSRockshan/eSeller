<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerPriceBookDetails.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerPriceBookDetails" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Price Book Details"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelPriceBook" runat="server" Text="Price Book" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListPriceBook" runat="server" CssClass="select" Width="30%"
                        AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListPriceBook_SelectedIndexChanged">
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
            <br />
        </ul>
    </fieldset>
    <table width="100%">
        <tbody>
            <tr>
                 <tr>
                    <td align="right">
                        <Biz:FlashText ID="FlashText1" runat="server" />
                    </td>
                </tr>
            </tr>
        </tbody>
    </table>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewPriceBookDetail" runat="server" Caption="Price Book Details"
                        CssClass="ColStyle" EmptyDataText="No data to display" TabIndex="2" AllowPaging="True"
                        AutoGenerateColumns="False" Visible="true" Width="99.6%" OnRowCreated="gridViewPriceBookDetail_RowCreated"
                        OnPageIndexChanging="gridViewPriceBookDetail_PageIndexChanging" OnSelectedIndexChanged="gridViewPriceBookDetail_SelectedIndexChanged">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="PriceBookDetailId" />
                            <asp:TemplateField HeaderText="Code">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCode" runat="server" Text='<%# Bind("Biz_Products.Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Biz_Products.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PricePer_Unit" HeaderText="Price Per Unit" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
        </ul>
        <table width="100%">
            <tbody>
                <tr>
                     <tr>
                    <td align="right">
                        <Biz:FlashText ID="FlashText2" runat="server" />
                    </td>
                </tr>
                </tr>
            </tbody>
        </table>
        <asp:UpdatePanel ID="updatePanelInputFields" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <cc1:Accordion ID="accordionInputs" runat="server" SuppressHeaderPostbacks="false"
                    RequireOpenedPane="true" AutoSize="None" TransitionDuration="250" FramesPerSecond="40"
                    FadeTransitions="true" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" SelectedIndex="0" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="accordionPaneAdd" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Add
                            </Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelProduct" runat="server" Text="Product" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListProduct" runat="server" CssClass="select" AutoPostBack="true"
                                                        TabIndex="2" Width="200px" AppendDataBoundItems="true">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitofMeasure" runat="server" Text="Unit of Measure" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListUnitofMeasure" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="2" Width="200px" AppendDataBoundItems="true">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCurrency1" runat="server" Text="Price Per Unit" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListCurrency1" runat="server" CssClass="select" AutoPostBack="true"
                                                        TabIndex="2" Width="10%">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="textBoxPricePerUnit" runat="server" CssClass="textbox_size1" Width="20%"
                                                        MaxLength="8" TabIndex="3" AutoPostBack="true" OnTextChanged="textBoxPricePerUnit_TextChanged"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDiscountRate" runat="server" Text="Discount" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:TextBox ID="textBoxDiscountRate" runat="server" CssClass="textbox_size1" Width="9.6%"
                                                        MaxLength="8" TabIndex="3" Text="0.00" AutoPostBack="true"  OnTextChanged="textBoxDiscountRate_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="textBoxDiscount" Text="0.00" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="50" Enabled="false"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCurrency2" runat="server" Text="Cost Per Unit" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListCurrency2" runat="server" CssClass="select" AutoPostBack="true"
                                                        TabIndex="2" Width="10%">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="textBoxCostPerUnit" Text="0.00" TabIndex="5" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="50" Enabled="false"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCommissionRate" runat="server" Text="Commission" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:TextBox ID="textBoxCommissionRate" runat="server" CssClass="textbox_size1" Width="9.6%"
                                                        MaxLength="8" TabIndex="6" Text="0.00" AutoPostBack="true" OnTextChanged="textBoxCommissionRate_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="textBoxCommission" Text="0.00" TabIndex="7" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="50" Enabled="false"></asp:TextBox>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSave" runat="server" TabIndex="15" Text="Save" CssClass="button_normal"
                                                        OnClick="buttonSave_Click" />
                                                    <asp:Button ID="buttonCancel1" runat="server" TabIndex="16 " Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancel1_Click" />
                                                </div>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="accordionPaneEdit" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Modify</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelEdit" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelProductEdit" runat="server" Text="Product" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListProductEdit" runat="server" CssClass="select" AutoPostBack="true"
                                                        TabIndex="2" Width="200px" AppendDataBoundItems="true">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitofMeasureEdit" runat="server" Text="Unit of Measure" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListUnitofMeasureEdit" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="2" Width="200px" AppendDataBoundItems="true">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCurrency1Edit" runat="server" Text="Price Per Unit" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListCurrency1Edit" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="2" Width="10%">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="textBoxPricePerUnitEdit" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="8" TabIndex="3" AutoPostBack="true" OnTextChanged="textBoxPricePerUnitEdit_TextChanged"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDiscoutRateEdit" runat="server" Text="Discount" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:TextBox ID="textBoxDiscountRateEdit" runat="server" CssClass="textbox_size1"
                                                        Width="9.6%" MaxLength="8" Text="0.00" TabIndex="3" AutoPostBack="true" OnTextChanged="textBoxDiscountRateEdit_TextChanged" ></asp:TextBox>
                                                    <asp:TextBox ID="textBoxDiscountEdit" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="50" Text="0.00"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCurrency2Edit" runat="server" Text="Cost Per Unit" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListCurrency2Edit" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="2" Width="10%">
                                                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="textBoxCostPerUnitEdit" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="50" Text="0.00"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelCommissionRateEdit" runat="server" Text="Commission" CssClass="legendlabel_size2"
                                                        Visible="True" Width="200px"></asp:Label>
                                                    <asp:TextBox ID="textBoxCommisionRateEdit" runat="server" CssClass="textbox_size1"
                                                        Width="9.6%" MaxLength="8" TabIndex="3" Text="0.00" AutoPostBack="true" OnTextChanged="textBoxCommisionRateEdit_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="textBoxCommissionEdit" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="20%" MaxLength="30" Text="0.00"></asp:TextBox>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonModify" runat="server" Text="Save" CssClass="button_normal"
                                                        TabIndex="15" OnClick="buttonModify_Click" />
                                                    <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                        TabIndex="15" OnClick="buttonDelete_Click" />
                                                    <asp:Button ID="buttonCancel2" runat="server" TabIndex="16" Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancel2_Click" />
                                                </div>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <br />
</asp:Content>
