<%@ Page Title="" Language="C#" MasterPageFile="~/Reference/ReferenceHome.master" AutoEventWireup="true" CodeBehind="BzFlexerParameterValues.aspx.cs" Inherits="BzFlexer.SAMS.WebView.Reference.BzFlexerParameterValues" %>


<%@ Register Src="~/BoostUnit/ValidationText.ascx" TagName="FlashText" TagPrefix="Biz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtitle">
        <asp:Label ID="labelFormTitle" runat="server" Text="Parameter Values"></asp:Label>
    </div>
    <fieldset>
        <ul class="form">
            <li>
                <br />
                <div class="formfield">
                    <asp:Label ID="labelParameterCode" runat="server" Text="General Parameter" CssClass="legendlabel_size2"
                        Visible="True" Width="200px"></asp:Label>
                    <asp:DropDownList ID="dropDownListParameter" runat="server" CssClass="select" AutoPostBack="true"
                        TabIndex="1" Width="200px">
                    </asp:DropDownList>
                    <font color="#FF0000">*</font>
                </div>
                <br />
            </li>
        </ul>
    </fieldset>
    <br />
    <fieldset>
        <ul class="form">
            <li>
                <div class="gridfield">
                    <asp:GridView ID="gridViewParameters" runat="server" Caption="Parameter Values" CssClass="ColStyle"
                        EmptyDataText="No data to display" TabIndex="2" AllowPaging="True" AutoGenerateColumns="False"
                        Visible="true" Width="99.6%">
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <HeaderStyle CssClass="GridHeader" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="20" ButtonType="Image"
                               SelectImageUrl="~/BoostUnit/images/select.png" />
                            <asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date" />
                            <asp:BoundField DataField="Expirydate" HeaderText="Expiry Date" />
                            <asp:BoundField DataField="Value" HeaderText="Value" />
                            <%--<asp:TemplateField HeaderText="Data Type">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "DataType.Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InputType" HeaderText="Input Type" />--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </li>
            <li>
                <br />
            </li>
        </ul>
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
                                                    <asp:Label ID="labelDataType" runat="server" Text="Data Type" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:DropDownList ID="DropDownListDataType" runat="server" Visible="True" CssClass="dropdownlist_size"
                                                        TabIndex="5" AutoPostBack="true" Width="100px">
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListDataType" ></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="hiddenFieldDataTypeNumericAdd" runat="server" />
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelParaValue" runat="server" Text="Parameter Value" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxParaValue" TabIndex="6" runat="server" CssClass="textbox_size1"
                                                        Width="300px" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListDataType" ></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="hiddenField1" runat="server" />
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelEffectiveDate" runat="server" Text="Effective Date" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxEffectiveDate" runat="server" CssClass="textbox_size1" Width="100px"
                                                        MaxLength="8" TabIndex="3"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBoxParaCode" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelExpiryDate" runat="server" Text="Expiry Date" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxExpiryDate" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="100px" MaxLength="50"></asp:TextBox>
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
                                                    <asp:Button ID="buttonSaveAdd" runat="server" TabIndex="15" Text="Save" CssClass="button_normal" />
                                                    <asp:Button ID="buttonCancelAdd" runat="server" TabIndex="16 " Text="Cancel" CssClass="button_normal" />
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
                                                    <asp:Label ID="labelDataTyp2" runat="server" Text="Data Type" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:DropDownList ID="DropDownListDataType2" runat="server" Visible="True" CssClass="dropdownlist_size"
                                                        TabIndex="5" AutoPostBack="true" Width="100px">
                                                    </asp:DropDownList>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListDataType" ></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="hiddenField2" runat="server" />
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelParaValue2" runat="server" Text="Parameter Value" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxParaValue2" TabIndex="6" runat="server" CssClass="textbox_size1"
                                                        Width="300px" MaxLength="50"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListDataType" ></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="hiddenField3" runat="server" />
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelEffectiveDate2" runat="server" Text="Effective Date" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxEffectiveDate2" runat="server" CssClass="textbox_size1" Width="100px"
                                                        MaxLength="8" TabIndex="3"></asp:TextBox>
                                                    <font color="#FF0000">*</font>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBoxParaCode" ></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="formfield">
                                                    <asp:Label ID="labelExpiryDate2" runat="server" Text="Expiry Date" CssClass="legendlabel_size2"
                                                        Visible="True"></asp:Label>
                                                    <asp:TextBox ID="textBoxExpiryDate2" TabIndex="4" runat="server" CssClass="textbox_size1"
                                                        Width="100px" MaxLength="50"></asp:TextBox>
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
                                                    <asp:Button ID="buttonSaveEdit" runat="server" Text="Save" CssClass="button_normal"
                                                        TabIndex="15" />
                                                    <asp:Button ID="buttonCancelEdit" runat="server" TabIndex="16" Text="Cancel" CssClass="button_normal" />
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