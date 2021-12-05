<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerStandardProperyCode.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerStandardProperyCode" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Standard Property Codes"></asp:Label>
    </div>
    <table width="100%" height="5px">
        <tbody>
            <tr>
                <td align="right">
                    <%--<osm:FlashMessage ID="FlashMessage1" runat="server" />--%>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>--%>
                    <asp:GridView ID="gridViewStdPropertyCode" runat="server" Caption="Standard Property Codes"
                        CssClass="ColStyle" EmptyDataText="No data to display" AllowPaging="True" PageSize="10"
                        Width="99.6%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                        </Columns>
                    </asp:GridView>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
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
                                            <asp:Label ID="labelStdPropertyCode" runat="server" Text="Standard Property Code"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxStdPropertyCodeAdd" runat="server" Width="100px" Enabled="true"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelStdPropertyDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxStdPropertyDescriptionAdd" runat="server" Width="300px" MaxLength="50"
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
                                            <asp:Label ID="labelStdPropertyCode2" runat="server" Text="Standard Property Code"
                                                CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxStdPropertyCodeModify" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="4"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelStdPropertyDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxStdPropertyDescriptionModify" runat="server" Width="300px"
                                                MaxLength="50" TabIndex="5" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
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