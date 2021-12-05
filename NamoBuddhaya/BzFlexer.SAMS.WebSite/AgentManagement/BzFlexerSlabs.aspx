<%@ Page Title="" Language="C#" MasterPageFile="~/AgentManagement/AgentManagementHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSlabs.aspx.cs" Inherits="BzFlexer.SAMS.WebView.AgentManagement.BzFlexerSlabs" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Commission Slab"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewCommissionSlab" runat="server" Caption="Commission Slab"
                        CssClass="ColStyle" EmptyDataText="No data to display" AllowPaging="True" PageSize="10"
                        Width="99.6%" AutoGenerateColumns="false" OnRowCreated="gridViewCommissionSlab_RowCreated"
                        OnSelectedIndexChanged="gridViewCommissionSlab_SelectedIndexChanged">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="SlabId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>
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
                                            <asp:Label ID="labelSlabCode" runat="server" Text="Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSlabAdd" runat="server" Width="100px" Enabled="true" MaxLength="8"
                                                CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSlabDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSlabDescriptionAdd" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                                OnClick="buttonSave_Click" />
                                            <asp:Button ID="buttonCancel1" runat="server" Text="Cancel" CssClass="button_normal"
                                                TabIndex="4" OnClick="buttonCancel1_Click" />
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
                                            <asp:TextBox ID="textBoxSlabIdModify" runat="server" Width="100px" Visible="false"
                                                CssClass="textbox_size2Upper"></asp:TextBox>
                                            <asp:Label ID="labelSlabCode2" runat="server" Text="Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSlabCodeModify" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="5"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="labelSlabDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="textBoxSlabDescriptionModify" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="6" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonEdit" runat="server" Text="Save" CssClass="button_normal" TabIndex="7"
                                                OnClick="buttonEdit_Click" />
                                            <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                TabIndex="8" OnClick="buttonDelete_Click" />
                                            <asp:Button ID="buttonCancel2" runat="server" Text="Cancel" CssClass="button_normal"
                                                TabIndex="9" OnClick="buttonCancel2_Click" />
                                        </div>
                                    </li>
                                    <li>
                                        <br />
                                    </li>
                                    <li>
                                        <div class="gridfield">
                                            <asp:GridView ID="gridViewSlabDetail" runat="server" Caption="Slab Detail" CssClass="ColStyle"
                                                EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                                                AutoGenerateColumns="false" OnRowCreated="gridViewSlabDetail_RowCreated" OnSelectedIndexChanged="gridViewSlabDetail_SelectedIndexChanged">
                                                <RowStyle CssClass="RowStyle" />
                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                <HeaderStyle CssClass="GridHeader" />
                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                <Columns>
                                                    <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                                       SelectImageUrl="~/BoostUnit/images/select.png" />
                                                    <asp:BoundField DataField="Id" HeaderText="SlabDetaiId" />
                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    <asp:BoundField DataField="Slab_From" HeaderText="Slab From" />
                                                    <asp:TemplateField HeaderText="Slab To">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="textBoxSlabTo" runat="server" Text='<%# Eval("Slab_To") %>' 
                                                                CssClass="textbox_customsize" Width="80px" AutoPostBack="true" OnTextChanged="textBoxSlabTo_TextChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Commission Rate (%)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="textBoxCommissionRAte" runat="server" Text='<%# Eval("Rate") %>' 
                                                                CssClass="textbox_customsize" Width="80px" AutoPostBack="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="buttonnew" runat="server" Text="New" CssClass="button_normal" TabIndex="6"
                                                OnClick="buttonSlabDetailAdd_Click" />
                                            <asp:Button ID="buttonSlabDetailSave" runat="server" Text="Save" CssClass="button_normal"
                                                TabIndex="7" OnClick="buttonSlabDetailSave_Click" />
                                            <asp:Button ID="buttonSlabDetailDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                TabIndex="8" OnClick="buttonSlabDetailDelete_Click" />
                                            <asp:Button ID="buttonSlabDetailCancel" runat="server" Text="Cancel" CssClass="button_normal"
                                                TabIndex="9" OnClick="buttonSlabDetailCancel_Click" />
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

