<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerUOM.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerUOM" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labeFormTitle" runat="server" Text="Unit Of Measure"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <br />
                <div class="formfield">
                    <asp:Label ID="labelUnitOfMeasureType" runat="server" Text="Unit Of Measure Type"
                        CssClass="legendlabel_size2"></asp:Label>
                    <asp:DropDownList ID="dropDownListUnitOfMeasureType" runat="server" CssClass="select"
                        Width="30%" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListUnitOfMeasureType_SelectedIndexChanged">
                        <asp:ListItem value="" Text="-Select-" Selected="True" ></asp:ListItem>
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewUnitOfMeasure" runat="server" CssClass="ColStyle" Caption="Unit Of Measure"
                        EmptyDataText="No Data to Display" AutoGenerateColumns="false" Width="99.6%"
                        Visible="true" OnRowCreated="gridViewUnitOfMeasure_RowCreated" OnSelectedIndexChanged="gridViewUnitOfMeasure_SelectedIndexChanged"
                        OnPageIndexChanging="gridViewUnitOfMeasure_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="UnitOfMeasureId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Symbol" HeaderText="Symbol" />
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
        <asp:UpdatePanel ID="updatePaneHeader" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <cc1:Accordion ID="accordianInputs" runat="server" AutoSize="None" RequireOpenedPane="true"
                    ContentCssClass="accordionContent" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                    FramesPerSecond="40" SelectedIndex="0" SuppressHeaderPostbacks="false" TransitionDuration="250">
                    <Panes>
                        <cc1:AccordionPane ID="accordionPaneAdd" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Add</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitOfMeasureCode" runat="server" Text="Unit Of Measure Code"
                                                        CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxUnitOfMeasureCode" runat="server" MaxLength="3" Width="10%"
                                                        CssClass="textbox_size2Upper"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDescription" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxDescription" runat="server" MaxLength="50" Width="50%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelSymbol" runat="server" Text="Symbol" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxSymbol" runat="server" MaxLength="50" Width="10%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSave" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonSave_Click" />
                                                    <asp:Button ID="buttonCancel1" runat="server" Text="Cancel" CssClass="button_normal" OnClick="buttonCancel1_Click" />
                                                </div>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane ID="AccordionPaneEdit" runat="server" HeaderCssClass="accordionHeader">
                            <Header>
                                Modify</Header>
                            <Content>
                                <asp:UpdatePanel ID="updatePanelEdit" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <ul class="form">
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitOfMeasureCode2" runat="server" Text="Unit Of Measure Code"
                                                        CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxUnitOfMeasureCode2" runat="server" MaxLength="3" Width="10%"
                                                        CssClass="textbox_size2Upper"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDescription2" runat="server" Text="Description" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxDescription2" runat="server" MaxLength="50" Width="50%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelSymbol2" runat="server" Text="Symbol" CssClass="legendlabel_size2"></asp:Label>
                                                    <asp:TextBox ID="textBoxSymbol2" runat="server" MaxLength="10" Width="50%" CssClass="textbox_size2"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonModify" runat="server" Text="Save" CssClass="button_normal" OnClick="buttonModify_Click" />
                                                    <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button_normal" OnClick="buttonDelete_Click" />
                                                    <asp:Button ID="buttonCancel2" runat="server" Text="Cancel" CssClass="button_normal" OnClick="buttonCancel2_Click" />
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