<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSalesForecastPeriods.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSalesForecastPeriods" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Forecasting Periods"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewForecastPeriod" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        Caption="Forecasting Periods" CssClass="ColStyle" EmptyDataText="No Data to Display"
                        PageSize="10" Width="98%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Frequency" HeaderText="Frequency" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
        <%-- UpdateMode="Conditional"--%>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
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
                                            <asp:Label ID="labelfrequencyAdd" runat="server" Text="Frequency" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="dropDownListFrequency" runat="server" CssClass="select"
                                                AutoPostBack="true" TabIndex="1" Width="15%">
                                                <asp:ListItem Value="Y" Text="Year"></asp:ListItem>
                                                <asp:ListItem Value="M" Text="Month"></asp:ListItem>
                                                <asp:ListItem Value="W" Text="Week"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelYearAdd" runat="server" Text="Year" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxYearAdd" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelMonthAdd" runat="server" Text="Month" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxMonthAdd" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelWeekAdd" runat="server" Text="Week" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxWeekAdd" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelDescriptionAdd" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxDescriptionAdd" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                                TabIndex="3" />
                                            <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button_normal" />
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
                                            <asp:Label ID="labelfrequencyEdit" runat="server" Text="Frequency" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:DropDownList ID="dropDownListFrequencyEdit" runat="server" CssClass="select"
                                                AutoPostBack="true" TabIndex="1" Width="15%">
                                                <asp:ListItem Value="Y" Text="Year"></asp:ListItem>
                                                <asp:ListItem Value="M" Text="Month"></asp:ListItem>
                                                <asp:ListItem Value="W" Text="Week"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelYearEdit" runat="server" Text="Year" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxYearEdit" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelMonthEdit" runat="server" Text="Month" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxMonthEdit" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelWeekEdit" runat="server" Text="Week" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxWeekEdit" runat="server" Width="20%" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelDescriptionEdit" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxDescriptionEdit" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="5" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonEdit" runat="server" Text="Save" CssClass="button_normal" TabIndex="6" />
                                            <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                TabIndex="7" />
                                            <asp:Button ID="buttonCancel2" runat="server" Text="Cancel" CssClass="button_normal"
                                                TabIndex="8" />
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
