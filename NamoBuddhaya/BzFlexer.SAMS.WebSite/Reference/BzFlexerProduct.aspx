<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerProduct.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerProduct" %>

<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="General Products"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <br />
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelProCategoryCode" runat="server" Text="Product Category" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListProductCat" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="dropDownListProductCat_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li>
                <div class="formfield">
                    <asp:Label ID="labelSubProductCat" runat="server" Text="Sub Product Category" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListSubProductCat" runat="server" CssClass="select"
                        AutoPostBack="true" TabIndex="2" Width="200px" OnSelectedIndexChanged="dropDownListSubProductCat_SelectedIndexChanged">
                        <asp:ListItem Text="-Select-" Value="" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:GridView ID="gridViewGeneralProduct" runat="server" Caption="General Products"
                        CssClass="ColStyle" EmptyDataText="No data to display" TabIndex="2" AllowPaging="True"
                        AutoGenerateColumns="False" Visible="true" Width="99.6%" OnRowCreated="gridViewGeneralProduct_RowCreated" 
                        OnSelectedIndexChanged="gridViewGeneralProduct_SelectedIndexChanged" OnPageIndexChanging="gridViewGeneralProduct_PageIndexChanging">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="Id" HeaderText="ProductId" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="More_Details" HeaderText="MoreDetails" />
                            <asp:BoundField DataField="IdUnitOfMeasureType" HeaderText="UnitOfMeasureTypeId" />
                            
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
                                                    <asp:Label ID="labelProductCode" runat="server" Text="Product Code" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxProductCode" runat="server" CssClass="textbox_size1" Width="100px"
                                                        MaxLength="8" TabIndex="3"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBoxParaCode" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelDescription" runat="server" Text="Description" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxDescription" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="300px" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textBoxDes" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelMoreDetail" runat="server" Text="More Details" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxMoreDetail" TabIndex="4" runat="server" CssClass="textarea"
                                                        Width="300px" MaxLength="50" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitofMeasureType" runat="server" Text="Unit of Measure Type"
                                                        CssClass="legendlabel_size2" Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListUnitofMeasureType" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="5" Width="200px">
                                                    </asp:DropDownList>
                                                </div>
                                            </li>
                                        </ul>
                                        <ul class="form">
                                            <li>
                                                <br />
                                            </li>
                                            <li>
                                                <div class="buttonlist2">
                                                    <asp:Button ID="buttonSave" runat="server" TabIndex="15" Text="Save" CssClass="button_normal" OnClick="buttonSave_Click"/>
                                                    <asp:Button ID="buttonCancel1" runat="server" TabIndex="16 " Text="Cancel" CssClass="button_normal" OnClick="buttonCancel1_Click" />
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
                                                    <asp:Label ID="labelProductCode2" runat="server" Text="Product Code" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxProductCode2" runat="server" TabIndex="3" CssClass="textbox_size1"
                                                        Width="100px" MaxLength="8"></asp:TextBox>
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
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelMoreDetail2" runat="server" Text="More Details" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxMoreDetail2" TabIndex="4" runat="server" CssClass="textarea"
                                                        Width="300px" MaxLength="50" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelUnitofMeasureType2" runat="server" Text="Unit of Measure Type"
                                                        CssClass="legendlabel_size2" Visible="True" Width="200px"></asp:Label>
                                                    <asp:DropDownList ID="dropDownListUnitofMeasureType2" runat="server" CssClass="select"
                                                        AutoPostBack="true" TabIndex="1" Width="200px">
                                                    </asp:DropDownList>
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
                                                    <asp:Button ID="buttonCancel2" runat="server" TabIndex="16" Text="Cancel" CssClass="button_normal" OnClick="buttonCancel2_Click" />
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