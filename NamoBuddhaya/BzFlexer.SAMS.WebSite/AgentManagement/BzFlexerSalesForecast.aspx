<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSalesForecast.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSalesForecast" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="Sales Forecast"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSalesForecast" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        Caption="Sales Forecast" CssClass="ColStyle" EmptyDataText="No Data to Display"
                        PageSize="10" Width="99.6%" OnRowCreated="gridViewSalesForecast_RowCreated" OnPageIndexChanging="gridViewSalesForecast_PageIndexChanging"
                        OnSelectedIndexChanged="gridViewSalesForecast_SelectedIndexChanged">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:TemplateField HeaderText="Period">
                                <ItemTemplate>
                                    <asp:Label ID="LabelPeriod" runat="server" Text='<%# Bind("Biz_Periods.Description") %>'></asp:Label>
                                    <%--<%# DataBinder.Eval(Container.DataItem, "StandardProperty.Description")%>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
        <table width="100%">
            <tbody>
                <tr>
                    <td align="right">
                        <Biz:FlashText ID="FlashText1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
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
                                            <asp:Label ID="labelPeriodAdd" runat="server" Text="Period" CssClass="legendlabel_size2"
                                                Visible="True" Width="200px"></asp:Label>
                                            <asp:DropDownList ID="dropDownListPeriodAdd" runat="server" CssClass="select" AutoPostBack="true"
                                                TabIndex="1" Width="200px" AppendDataBoundItems="true">
                                                <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSalesforecastCodeAdd" runat="server" Text="Sales Forecast Code"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSalesforecastCodeAdd" runat="server" Width="100px" Enabled="true"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSalesforecastDescriptionAdd" runat="server" Text="Description"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSalesforecastDescriptionAdd" runat="server" Width="300px"
                                                MaxLength="50" TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                                TabIndex="3" OnClick="buttonSave_Click" />
                                            <asp:Button ID="buttonCancel1" runat="server" Text="Cancel" CssClass="button_normal" OnClick="buttonCancel1_Click" />
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
                                            <asp:Label ID="labelPeriodEdit" runat="server" Text="Period" CssClass="legendlabel_size2"
                                                Visible="True" Width="200px"></asp:Label>
                                            <asp:DropDownList ID="dropDownListPeriodEdit" runat="server" CssClass="select" AutoPostBack="true"
                                                TabIndex="1" Width="200px" AppendDataBoundItems="true">
                                                <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSalesforecastCodeEdit" runat="server" Text="Sales Forecast Code"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSalesforecastEdit" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="4"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSalesforecastDescriptionEdit" runat="server" Text="Description"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSalesforecastpDescriptionEdit" runat="server" Width="300px"
                                                MaxLength="50" TabIndex="5" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonModify" runat="server" Text="Save" CssClass="button_normal" TabIndex="6" OnClick="buttonModify_Click" />
                                            <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                TabIndex="7" OnClick="buttonDelete_Click" />
                                            <asp:Button ID="buttonCancel2" runat="server" Text="Cancel" CssClass="button_normal"
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
    <br />
</asp:Content>
