<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerPriceBook.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerPriceBook" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Price Book"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewPriceBook" runat="server" Caption="Price Book" CssClass="ColStyle"
                        EmptyDataText="No data to display" AutoGenerateColumns="false" Width="99.6%"
                        OnSelectedIndexChanged="gridViewPriceBook_SelectedIndexChanged" OnRowCreated="gridViewPriceBook_RowCreated"
                        OnPageIndexChanging="gridViewPriceBook_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="PriceBookId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:TemplateField HeaderText="Currency">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCurrency" runat="server" Text='<%# Bind("Biz_Currencies.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="labelEmptyGridText" runat="server" Text="No data to display"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </li>
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="right">
                            <Biz:FlashText ID="FlashText1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
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
                                        <div class="formlable">
                                            <asp:Label ID="labelBusinessUnitCode" runat="server" Text="Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxCode" runat="server" Width="100px" Enabled="true" MaxLength="8"
                                                CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#EE4000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelBusinessUnitDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxDescription" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#EE4000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Label ID="label1" runat="server" Text="Currency" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="dropDownListCurrencyAdd" runat="server" AppendDataBoundItems="true"
                                                CssClass="select" AutoPostBack="true" Enabled="false">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font class="mandatoryfield">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonSave" Text="Save" runat="server" Enabled="true" CssClass="button_normal"
                                                TabIndex="3" OnClick="buttonSave_Click" />
                                            <asp:Button ID="buttonCancel1" Text="Cancel" runat="server" CssClass="button_normal"
                                                OnClick="buttonCancel1_Click" />
                                    </li>
                                </ul>
                            </Content>
                        </cc1:AccordionPane>
                        <%--Accordiaon Pane to View / Modify / Remove Details--%>
                        <cc1:AccordionPane ID="accordionPaneEdit" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Modify</Header>
                            <Content>
                                <ul class="form">
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelBusinessUnitCode2" runat="server" Text="Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxCodeModify" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="4"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelBusinessUnitDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxDescriptionModify" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="5" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <asp:TextBox ID="textBoxPriceBookIdModify" runat="server" Visible="false" CssClass="textbox_size1"
                                            Width="80px"></asp:TextBox>
                                    </li>
                                    <li>
                                        <div class="formfield">
                                            <asp:Label ID="label2" runat="server" Text="Currency" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="DropDownListCurrencyModify" runat="server" CssClass="select"
                                                AppendDataBoundItems="true" AutoPostBack="true" Enabled="false">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font class="mandatoryfield">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonModify" Text="Save" runat="server" CssClass="button_normal"
                                                TabIndex="6" OnClick="buttonModify_Click" />
                                            <asp:Button ID="buttonDelete" Text="Delete" runat="server" CssClass="button_normal"
                                                TabIndex="7" OnClick="buttonDelete_Click" />
                                            <asp:Button ID="buttonCancel2" Text="Cancel" runat="server" CssClass="button_normal"
                                                TabIndex="8" OnClick="buttonCancel2_Click" />
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
</asp:Content>
