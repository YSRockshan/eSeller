<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerTaxRates.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerTaxRates" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labeFormTitle" runat="server" Text="Tax Rates"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelTaxCode" runat="server" Text="Tax Code" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListTaxCode" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labeProductType" runat="server" Text="Product Type" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductType" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="20%">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewTaxRates" runat="server" CssClass="ColStyle" Caption="Tax Rates"
                        EmptyDataText="No Data to Display" AutoGenerateColumns="false" Width="99.6%"
                        Visible="true">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                            <asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
        <asp:UpdatePanel ID="updatePaneHeader" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <cc1:Accordion ID="accordianInputs" runat="server" AutoSize="None" RequireOpenedPane="true"
                    ContentCssClass="accordionContent" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                    FramesPerSecond="40" SelectedIndex="0" SuppressHeaderPostbacks="false" TransitionDuration="250">
                    <Panes>
                        <cc1:AccordionPane ID="accordionPaneAdd" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Add</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <%--<li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelTaxCode" runat="server" Text="Tax Code" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxTaxCode" runat="server" MaxLength="3" Width="10%" CssClass="textbox_size2"
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:TextBox ID="textBoxTaxDescription" runat="server" MaxLength="50" Width="50%"
                                                        CssClass="textbox_size2" Enabled="false"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>--%>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelTaxRate" runat="server" Text="Tax Rate" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxTaxRate" runat="server" MaxLength="3" Width="10%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelEffectiveDate" runat="server" Text="Effective Date" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxEffectiveDate" runat="server" MaxLength="50" Width="20%"
                                                        CssClass="textbox_size2"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="calendarExtenderEffDate" runat="server" PopupButtonID="textBoxEffectiveDate"
                                                        TargetControlID="textBoxEffectiveDate">
                                                    </cc1:CalendarExtender>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" />
                                                    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal" />
                                                </div>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPaneEdit" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Modify</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelEdit" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <%-- <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelTaxCode2" runat="server" Text="Tax Code" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxTaxCode2" runat="server" MaxLength="3" Width="10%" CssClass="textbox_size2"
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:TextBox ID="textBoxTaxDescription2" runat="server" MaxLength="50" Width="50%"
                                                        CssClass="textbox_size2" Enabled="false"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>--%>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelTaxRate2" runat="server" Text="Tax Rate" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxTaxRate2" runat="server" MaxLength="3" Width="10%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelEffectiveDate2" runat="server" Text="Effective Date" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxEffectiveDate2" runat="server" MaxLength="50" Width="50%"
                                                        CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonModify" runat="server" Text="Save" CssClass="button_normal" />
                                                    <asp:Button ID="buttoDelete" runat="server" Text="Delete" CssClass="button_normal" />
                                                    <asp:Button ID="ButtonCancel2" runat="server" Text="Cancel" CssClass="button_normal" />
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
</asp:Content>