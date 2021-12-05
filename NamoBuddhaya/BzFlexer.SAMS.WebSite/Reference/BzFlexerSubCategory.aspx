<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerSubCategory.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerSubCategory" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Sub Product Categories"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <div class="formlabal">
                    <li>
                        <br />
                    </li>
                    <li>
                        <asp:Label ID="labelProCategoryCode" runat="server" Text="Product Category" CssClass="legendlabel_size2"
                            Visible="True" Width="200px"></asp:Label>
                        <asp:DropDownList ID="dropDownListProductCategory" runat="server" CssClass="select"
                            AutoPostBack="true" TabIndex="1" Width="200px" OnSelectedIndexChanged="dropDownListProductCategory_SelectedIndexChanged">
                            <%--OnSelectedIndexChanged="dropDownListProductCategory_SelectedIndexChanged"--%>
                            <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <font color="#FF0000">*</font> </li>
                    <li>
                        <br />
                    </li>
                </div>
            </li>
        </ul>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewSubProductCat" runat="server" Caption="Sub Product Categories"
                        CssClass="ColStyle" EmptyDataText="No data to display" TabIndex="2" AllowPaging="True"
                        AutoGenerateColumns="False" Visible="true" Width="99.6%" OnRowCreated="gridViewSubProductCat_RowCreated"
                        OnSelectedIndexChanged="gridViewSubProductCat_SelectedIndexChanged" OnPageIndexChanging="gridViewSubProductCat_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <%--<asp:BoundField DataField="ProductCategoryId" HeaderText="ProductCategoryId" />--%>
                            <asp:BoundField DataField="Id" HeaderText="SubProductCategoryId" />
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
        <table width="100%">
            <tbody>
                <tr>
                    <td align="right">
                        <Biz:FlashText ID="FlashText1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
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
                                                    <asp:Label ID="labelSubProCatCode" runat="server" Text="Sub Product Category Code"
                                                        CssClass="legendlabel_size2" Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxSubProCatCode" runat="server" CssClass="textbox_size2Upper" Width="100px"
                                                        MaxLength="8" TabIndex="3"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDescription" runat="server" Text="Description" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxDescription" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="300px" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSave" runat="server" TabIndex="15" Text="Save" CssClass="button_normal"
                                                        OnClick="buttonSave_Click" />
                                                    <asp:Button ID="buttonCancel1" runat="server" TabIndex="16 " Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancel1_Click" />
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
                                                    <asp:Label ID="labelSubProCatCode2" runat="server" Text="Sub Product Category Code"
                                                        CssClass="legendlabel_size2" Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxSubProCatCode2" runat="server" TabIndex="3" CssClass="textbox_size2Upper"
                                                        Width="100px" MaxLength="8" Enabled="false"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxDescription2" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="300px" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonModify" runat="server" Text="Save" CssClass="button_normal" TabIndex="15" OnClick="buttonModify_Click" />
                                                    <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal"
                                                        TabIndex="15" OnClick="buttonDelete_Click" />
                                                    <asp:Button ID="buttonCancel2" runat="server" TabIndex="16" Text="Cancel" CssClass="button_normal"
                                                        OnClick="buttonCancel2_Click" />
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