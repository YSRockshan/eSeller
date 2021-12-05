<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerParameter.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerParameter" %>
<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="General Parameters"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewGeneralParameters" runat="server" Caption="General Parameters"
                        CssClass="ColStyle" EmptyDataText="No data to display" AllowPaging="True" PageSize="10"
                        Width="99.6%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
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
                                            <asp:Label ID="labelParameterCode" runat="server" Text="Parameter Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxParameterCodeAdd" runat="server" Width="100px" Enabled="true"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelParameterDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxParameterDescriptionAdd" runat="server" Width="300px" MaxLength="50"
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
                                            <asp:Label ID="labelParameterCode2" runat="server" Text="Parameter Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textParameterCodeModify" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="4"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelParameterDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxParameterDescriptionModify" runat="server" Width="300px"
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