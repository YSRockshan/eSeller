<%@ Page Title="" Language="C#" MasterPageFile="~/Security/SecurityHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSystemModule.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Security.BzFlexerSystemModule" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelTitle" runat="server" Text="System Modules"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSystemModule" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        Caption="System Modules" CssClass="ColStyle" EmptyDataText="No Data to Display"
                        PageSize="10" Width="99.6%" OnRowCreated="gridViewSystemModule_RowCreated" OnSelectedIndexChanged="gridViewSystemModule_SelectedIndexChanged"
                        OnPageIndexChanging="gridViewSystemModule_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="Module ID" />
                            <asp:BoundField DataField="SystemModule_Code" HeaderText="Module Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
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
                                            <asp:Label ID="labelSytemModuleCodeAdd" runat="server" Text="Module Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxModuleCodeAdd" runat="server" Width="100px" Enabled="true"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelModuleDescriptionAdd" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxModuleDescriptionAdd" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                                TabIndex="3" OnClick="buttonSave_Click" />
                                            <asp:Button ID="buttonCancel1" runat="server" Text="Cancel" CssClass="button_normal"
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
                                            <asp:Label ID="labelModuleCodeEdit" runat="server" Text="Module Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxModuleCodeEdit" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="4"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelModulepDescriptionEdit" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxModuleDescriptionEdit" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="5" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
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
</asp:Content>
