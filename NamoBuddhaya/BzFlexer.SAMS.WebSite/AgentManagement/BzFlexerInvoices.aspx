<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerInvoices.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerInvoices" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Sales Invoice"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <asp:Label ID="labelTransactionNumber" runat="server" Text=""></asp:Label>
                <br />
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelBranch" runat="server" Text="Branch" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxBranch" runat="server" CssClass="textbox_size1" Width="5%"></asp:TextBox>
                    <asp:DropDownList ID="dropDownListBranch" runat="server" CssClass="select" AutoPostBack="true"
                        Width="30%" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListBranch_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelname" runat="server" Text="Invoice Number" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="DropDownListTransactionNumber" runat="server" CssClass="select"
                        AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownListTransactionNumber_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="- Select -"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="textBoxSalesTranasaionIdModify" CssClass="genarateId" Width="28%"
                        runat="server" Enabled="false"></asp:TextBox>
                    <%--<asp:TextBox ID="textBoxTransactionStatus" Width="195px" runat="server" Enabled="false"
                         Visible="false" ></asp:TextBox>--%>
                    <%--<font class="mandatoryfield">*</font>--%>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="label9" runat="server" Text="Sales Person" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="DropDownListSalesPerson" runat="server" CssClass="select" AppendDataBoundItems="true"
                        AutoPostBack="true">
                        <asp:ListItem Value="" Text="- Select -"></asp:ListItem>
                    </asp:DropDownList>
                    <font class="mandatoryfield">*</font>
                    <asp:TextBox ID="textBoxSalesPerson" runat="server" Width="300px" Enabled="true"
                        MaxLength="50" CssClass="textbox_size2" Visible="false"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formlable">
                    <asp:Label ID="labelEffectiveDate" runat="server" Text="Invoice Date" CssClass="legendlabel_size2"></asp:Label>
                    <asp:TextBox ID="textBoxTransactionDate" runat="server" CssClass="textbox_size1"></asp:TextBox>
                    <cc1:CalendarExtender ID="calendarExtenderDateOfBirth" runat="server" Enabled="True"
                        PopupButtonID="textBoxTransactionDate" TargetControlID="textBoxTransactionDate">
                    </cc1:CalendarExtender>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="label7" runat="server" Text="PriceBook" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="DropDownListPriceBook" runat="server" CssClass="select" AppendDataBoundItems="true"
                        AutoPostBack="true" OnSelectedIndexChanged="DropDownListPriceBook_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="- Select -"></asp:ListItem>
                    </asp:DropDownList>
                    <font class="mandatoryfield">*</font>
                    <asp:TextBox ID="textBoxPriceBookId" runat="server" Width="300px" Enabled="true"
                        MaxLength="50" CssClass="textbox_size2" Visible="false"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelMainCategory" runat="server" Text="Product Category" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                         AutoPostBack="true" AppendDataBoundItems="true">
                        <asp:ListItem Text="-All-"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSubCategory" runat="server" Text="Sub Category" CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListSubProductCategory" runat="server" CssClass="select"
                        Enabled="true" AutoPostBack="true" AppendDataBoundItems="true">
                        <asp:ListItem Text="-Select-"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hiddenFieldSubCategoryIdAdd" runat="server" />
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="label1" runat="server" Text="Product" CssClass="legendlabel_size2">
                    </asp:Label>
                    <asp:DropDownList ID="DropDownListProduct" runat="server" CssClass="select" AppendDataBoundItems="true"
                        AutoPostBack="true" OnSelectedIndexChanged="DropDownListProduct_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="- Select -"></asp:ListItem>
                    </asp:DropDownList>
                    <font class="mandatoryfield">*</font>
                    <asp:TextBox ID="textBoxCompanyProductId" runat="server" Width="300px" Enabled="true"
                        MaxLength="50" CssClass="textbox_size2" Visible="false"></asp:TextBox>
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
                <div class="gridfield">
                    <asp:GridView ID="gridViewInvoice" runat="server" Caption="Invoice" CssClass="ColStyle"
                        Width="99.6%" EmptyDataText="No data to display" AutoGenerateColumns="false"
                        AllowPaging="True" OnPageIndexChanging="gridViewInvoice_PageIndexChanging" OnRowCreated="gridViewInvoice_RowCreated"
                        PageSize="10" OnSelectedIndexChanged="gridViewInvoice_SelectedIndexChanged">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="InvoiceId" />
                            <asp:BoundField DataField="SerialNo" HeaderText="Seq." />
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="InventoryItemCode" runat="server" Text='<%# ( Eval( "Biz_InventoryItems")==null ?"" :Eval( "Biz_InventoryItems.CodeInventoryItem") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCode" runat="server" Text='<%# (( Eval( "Biz_BranchProducts.Biz_Products")==null)?"" :Eval( "Biz_BranchProducts.Biz_Products.Description") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Discount_Value" HeaderText="DiscountValue" DataFormatString="{0:n2}"
                                FooterStyle-HorizontalAlign="Right" SortExpression="OrginalBelop" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" FooterStyle-HorizontalAlign="Right"
                                SortExpression="OrginalBelop" ItemStyle-HorizontalAlign="Right" />
                            <asp:TemplateField HeaderText="Unit of Measure">
                                <ItemTemplate>
                                    <asp:Label ID="LabelUnitofMeasure" runat="server" Text='<%# (( Eval( "Biz_UnitOfMeasures")==null)?"" :Eval( "Biz_UnitOfMeasures.Symbol") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Total_Value" HeaderText="TotalValue" DataFormatString="{0:n2}"
                                FooterStyle-HorizontalAlign="Right" SortExpression="OrginalBelop" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Commission_Value" HeaderText="CommissionValue" DataFormatString="{0:n2}" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="SalesTarget">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSalesTargetId" runat="server" Text='<%# ( ( Eval( "Biz_SalesTargets")==null)?"" :Eval( "Biz_SalesTargets.Description") )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyGridText" runat="server" Text="No data to display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </li>
        </ul>
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <cc1:Accordion ID="accordionInputs" runat="server" SuppressHeaderPostbacks="false"
                    RequireOpenedPane="true" AutoSize="None" TransitionDuration="250" FramesPerSecond="40"
                    FadeTransitions="true" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" SelectedIndex="0" Width="100%">
                    <Panes>
                        <%--Accordiaon Pane to Add Details--%>
                        <cc1:AccordionPane ID="accordionPaneAdd" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Add</Header>
                            <Content>
                                <ul class="form">
                                    <li>
                                        <div class="formfield">
                                            <asp:Label ID="labelSalesTarget" runat="server" Text="Target" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="DropDownListSalesTarget" runat="server" CssClass="select" 
                                                AppendDataBoundItems="true" AutoPostBack="true"> <%--OnSelectedIndexChanged="DropDownListSalesTarget_SelectedIndexChanged"--%>
                                                <asp:ListItem Value="" Text="- Unavailable -"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="textBoxSalesTargetId" runat="server" Width="300px" Enabled="true"
                                                MaxLength="50" CssClass="textbox_size2" Visible="false"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Label ID="labelItem" runat="server" Text="Item" CssClass="legendlabel_size2">
                                            </asp:Label>
                                            <asp:DropDownList ID="DropDownListItem" runat="server" CssClass="select" AppendDataBoundItems="true"
                                                AutoPostBack="true" OnSelectedIndexChanged="DropDownListItem_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="- Select -"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font class="mandatoryfield">*</font>
                                            <asp:TextBox ID="textBoxItem" runat="server" Width="300px" Enabled="true" MaxLength="50"
                                                CssClass="textbox_size2" Visible="false"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelUnitOfMeasure" runat="server" Text="Unit Of Measure" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="DropDownListUnitOfMeasure" runat="server" CssClass="select"
                                                Enabled="false" AppendDataBoundItems="true" AutoPostBack="true">
                                                <asp:ListItem Value="" Text="- Select -"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelPricePerUnit" runat="server" Text="Price Per Unit" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="dropDownListPricePerUnit" runat="server" CssClass="select"
                                                Enabled="false">
                                                <asp:ListItem Value="R" Text="LKR" Selected="True" />
                                            </asp:DropDownList>
                                            <asp:TextBox ID="textBoxPricePerUnit" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelQuantity" runat="server" Text="Quantity" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxQuantity" runat="server" Width="100px" MaxLength="50" TabIndex="2"
                                                Enabled="true" CssClass="textbox_size2" OnTextChanged="textBoxQuantity_TextChanged"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelTotalValue" runat="server" Text="Total Value" CssClass="legendlabel_size2"
                                                Enabled="false"></asp:Label>
                                            <asp:TextBox ID="textBoxTotalValue" runat="server" Width="100px" MaxLength="50" TabIndex="2"
                                                Enabled="false" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelDiscountRate" runat="server" Text="Discount" Enabled="false"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxDiscountRate" runat="server" Width="100px" MaxLength="50"
                                                Enabled="false" TabIndex="2" CssClass="textbox_size2"></asp:TextBox>
                                            <asp:TextBox ID="textBoxCostPerUnit" runat="server" Width="100px" Visible="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <asp:TextBox ID="textBoxDiscountValue" runat="server" Width="100px" MaxLength="50"
                                                TabIndex="2" Enabled="false" CssClass="textbox_size2"></asp:TextBox>
                                            <asp:TextBox ID="textBoxTotalDiscount" runat="server" Width="100px" Visible="false"
                                                MaxLength="8" CssClass="textbox_size2Upper"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <asp:TextBox ID="textBoxCommissionRate" runat="server" Width="100px" MaxLength="50"
                                            TabIndex="2" Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                        <asp:TextBox ID="textBoxCommissionValue" runat="server" Width="100px" MaxLength="50"
                                            TabIndex="2" Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                        <asp:TextBox ID="textBoxTotalCommission" runat="server" Width="100px" MaxLength="50"
                                            TabIndex="2" Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                        <asp:TextBox ID="textBoxStatus" runat="server" Width="100px" MaxLength="50" TabIndex="2"
                                            Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                    </li>
                                    <li>
                                        <asp:TextBox ID="textBoxSalesTargetIdModify" runat="server" Width="300px" Enabled="true"
                                            MaxLength="50" CssClass="textbox_size2" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="textBoxInvoiceIdModify" runat="server" Width="100px" MaxLength="50"
                                            TabIndex="2" Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                        <asp:TextBox ID="textBoxSerialModify" runat="server" Width="100px" MaxLength="50"
                                            TabIndex="2" Visible="false" CssClass="textbox_size2"></asp:TextBox>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonAdd" runat="server" Text="Add" Enabled="true" CssClass="button_normal"
                                                TabIndex="3" OnClick="buttonAdd_Click" />
                                            <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                TabIndex="7" OnClick="buttonDelete_Click" />
                                            <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                                TabIndex="4" OnClick="buttonSave_Click" />
                                            <asp:Button ID="buttonConfirm" runat="server" Text="Confirm" Enabled="true" CssClass="button_normal"
                                                TabIndex="4" OnClick="buttonConfirm_Click" />
                                            <asp:Button ID="buttonPrint" runat="server" Text="Print" Enabled="true" CssClass="button_normal"
                                                TabIndex="4" OnClick="buttonPrint_Click" />
                                            <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal"
                                                OnClick="buttonCancel_Click" />
                                        </div>
                                    </li>
                                </ul>
                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <br />
</asp:Content>
