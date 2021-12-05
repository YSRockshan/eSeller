<%@ Page Title="" Language="C#" MasterPageFile="~/Security/SecurityHome.master" AutoEventWireup="true" CodeBehind="BzFlexerScreen.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Security.BzFlexerScreen" %>


<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderProgramTree" runat="server">
    <asp:TreeView ID="treeViewProgramTree" runat="server" ShowLines="true" CssClass="programtree"
        OnSelectedNodeChanged="treeViewProgramTreeNode_Click">
        <selectednodestyle backcolor="white" borderwidth="1" />
        <nodes></nodes>
    </asp:TreeView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="System Screens"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <br />
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSystemModule" runat="server" Text="System Module" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSystemModule" runat="server" CssClass="select"
                        AutoPostBack="true" TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListSystemModule_SelectedIndexChanged">
                        <%-- <asp:ListItem Value="" Text="-Select-" Selected="True"></asp:ListItem>--%>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <br />
        </ul>
    </fieldset>
    <br />
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
        <%-- <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSystemScreen" runat="server" Caption="System Screens" CssClass="ColStyle"
                        EmptyDataText="No data to display" TabIndex="2" AllowPaging="True" AutoGenerateColumns="False"
                        Visible="true" Width="99.6%" OnSelectedIndexChanged="gridViewSystemScreen_SelectedIndexChanged"
                        OnRowCreated="gridViewSystemScreen_RowCreated">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="ScreenId" HeaderText="Screen ID" />
                            <asp:BoundField DataField="Sequence" HeaderText="Sequence No" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>--%>
        <asp:UpdatePanel ID="updatePanelInputFields" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <cc1:Accordion ID="accordionInputs" runat="server" SuppressHeaderPostbacks="false"
                    RequireOpenedPane="true" AutoSize="None" TransitionDuration="250" FramesPerSecond="40"
                    FadeTransitions="true" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                    HeaderCssClass="accordionHeader" SelectedIndex="0" Width="100%">
                    <Panes>
                        <cc1:AccordionPane ID="accordionPaneAdd" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Add
                            </Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelScreenDescription" runat="server" Text="Screen Description" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxScreenDescription" runat="server" CssClass="textbox_size1"
                                                        Width="50%" MaxLength="50" TabIndex="3"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBoxParaCode" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelProgramFile" runat="server" Text="Program File Name" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxProgramFile" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="50%" MaxLength="50"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textBoxDes" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelSequence" runat="server" Text="Sequence No" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxSequence" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="15%" MaxLength="15"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textBoxDes" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSaveAdd" runat="server" TabIndex="15" Text="Save" CssClass="button_normal"
                                                        OnClick="buttonSaveAdd_Click" />
                                                    <asp:Button ID="buttonCancelAdd" runat="server" TabIndex="16 " Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancelAdd_Click" />
                                                </div>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="accordionPaneEdit" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Modify</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelEdit" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelScreenDescription2" runat="server" Text="Screen Description"
                                                        CssClass="legendlabel_size2" Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxScreenDescription2" runat="server" TabIndex="3" CssClass="textbox_size1"
                                                        Width="50%" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <asp:HiddenField ID="hiddenFieldScreenId" runat="server" />
                                                    <asp:HiddenField ID="hiddenFieldParentScreenId" runat="server" />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="textBoxParaCodeEdit"  ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelProgramFile2" runat="server" Text="Program File Name" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxProgramFile2" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="50%" MaxLength="50"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="textBoxDesEdit" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelSequence2" runat="server" Text="Sequence No" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxSequence2" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="15%" MaxLength="15"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="textBoxDesEdit" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSaveEdit" runat="server" Text="Save" CssClass="button_normal"
                                                        TabIndex="15" OnClick="buttonSaveEdit_Click" />
                                                    <asp:Button ID="buttonDelete" runat="server" TabIndex="16" Text="Delete" CssClass="button_normal"
                                                        OnClick="buttonDelete_Click" />
                                                    <asp:Button ID="buttonCancelEdit" runat="server" TabIndex="16" Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancelEdit_Click" />
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
    <br />
</asp:Content>
