<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerBranch.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerBranch" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row-fluid">
        <asp:Label ID="lblFormTitle" runat="server" class="page-header" Text="Branches"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <%--<div class="gridfield">
                    <asp:GridView ID="gridViewBranch" runat="server" Caption="Branches" CssClass="table table-striped custab"
                        EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                       AutoGenerateColumns="false">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="text-center" />
                        <SelectedRowStyle CssClass="text-center" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                SelectImageUrl="~/styles/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="BranchId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>--%>
               <%--   OnPageIndexChanging="gridViewBranch_PageIndexChanging" OnRowCreated="gridViewBranch_RowCreated"
                        OnSelectedIndexChanged="gridViewBranch_SelectedIndexChanged"--%>

                <div class="gridfield">
                    <asp:GridView ID="gridViewBranch" runat="server" Caption="Branches" CssClass="ColStyle"
                        EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                        OnPageIndexChanging="gridViewBranch_PageIndexChanging" OnRowCreated="gridViewBranch_RowCreated"
                        OnSelectedIndexChanged="gridViewBranch_SelectedIndexChanged" AutoGenerateColumns="false">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                SelectImageUrl="~/styles/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="BranchId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>

               <%-- <div class="gridfield">
                    <asp:GridView ID="gridViewBranch" runat="server" Caption="Branches" CssClass="ColStyle"
                        EmptyDataText="No data to display" AllowPaging="True" PageSize="10" Width="99.6%"
                      OnRowCreated="gridViewBranch_RowCreated"
                        OnSelectedIndexChanged="gridViewBranch_SelectedIndexChanged" AutoGenerateColumns="false">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ItemStyle-Width="20" ShowSelectButton="True" ButtonType="Image"
                                SelectImageUrl="~/styles/images/select.png" />
                            <asp:BoundField DataField="BranchId" HeaderText="Id" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>--%>
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
                                            <asp:Label ID="lblBranchCode" runat="server" Text="Branch Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="txtBranchAdd" runat="server" Width="100px" Enabled="true" MaxLength="8"
                                                CssClass="textbox_size2Upper" TabIndex="1"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="lblBranchDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="txtBranchDescriptionAdd" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="2" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" Enabled="true" CssClass="button_normal"
                                               OnClick="buttonSave_Click" TabIndex="3" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button_normal"
                                               OnClick="buttonCancel1_Click" TabIndex="4" />
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
                                            <asp:Label ID="lblBranchCodeModify" runat="server" Text="Branch Code" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="txtBranchModify" runat="server" Width="100px" Enabled="false"
                                                MaxLength="8" CssClass="textbox_size2Upper" TabIndex="5"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="formlable">
                                            <asp:Label ID="lblDescriptionModify" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                            <asp:TextBox ID="txtBranchDescriptionModify" runat="server" Width="300px" MaxLength="50"
                                                TabIndex="6" Enabled="true" CssClass="textbox_size2"></asp:TextBox>
                                            <font color="#FF0000">*</font>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="buttonlist2">
                                            <asp:Button ID="btnModify" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonEdit_Click"
                                                TabIndex="7" />
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button_normal"
                                               OnClick="buttonDelete_Click" TabIndex="8" />
                                            <asp:Button ID="btnCancel2" runat="server" Text="Cancel" CssClass="button_normal"
                                               OnClick="buttonCancel2_Click" TabIndex="9" />
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
