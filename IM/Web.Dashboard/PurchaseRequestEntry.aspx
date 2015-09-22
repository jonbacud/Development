<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseRequestEntry.aspx.cs" Inherits="Web.Dashboard.PurchaseRequestEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="PurchaseRequestManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Purchase</a></li>
            </ul>
            <h4 class="text-italic">New Purchase Request Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row cells5">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Request Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtReferenceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan3 margin5">
                        <label style="font-weight: 800;">Request Date</label>
                        <div class="input-control text full-size" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                            <asp:TextBox runat="server" ID="txtRequestDate"></asp:TextBox>
                            <button class="button bg-active-green"><span class="mif-calendar"></span></button>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">SAI Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtSAINumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">ALOBS Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtALOBSNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Stock Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtStockNumber"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">From Department</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLFromDepartments" AutoPostBack="True" OnSelectedIndexChanged="DDLFromDepartments_SelectedIndexChanged" />
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell colspan9">
                        <label style="font-weight: 800;">Select Item</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLItems" AutoPostBack="True" />

                        </div>
                    </div>
                    <div class="cell colspan2 margin10">
                        <div class="input-control full-size ">
                            <asp:HyperLink ID="hpLinkViewDetails" CssClass="button link" runat="server">
                                <span class="mif-file-text">view details</span>
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Submitted To</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDepartments" AutoPostBack="True" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Unit</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLUnits" DataSourceID="ObjectDataSourceUnits" DataTextField="Description"
                                DataValueField="Id" />
                            <asp:ObjectDataSource ID="ObjectDataSourceUnits" runat="server" SelectMethod="FetchAll"
                                TypeName="IM.BusinessLogic.DataManager.UnitManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLFromDepartments" Name="departmentId"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox CssClass="fg-darkRed text-bold" runat="server" min="1" Type="Number" ID="txtQuantity" Text="1"></asp:TextBox>
                        </div>
                    </div>

                    <div class="cell colspan3 margin5">
                    </div>
                </div>

            </div>

            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:LinkButton class="button button-shadow default" ID="lnkButtonAdd" runat="server" OnClick="lnkButtonAdd_Click">
                          <span class="mif-arrow-down"></span>Add
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size">
                        <asp:GridView ID="gvSelectedItems" Style="width: 100%;" class="dataTable border bordered" data-role="datatable" data-auto-width="false"
                            runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnRowDeleting="gvSelectedItems_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EstimatedCost" HeaderText="Estimated Cost" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RequestNumber" HeaderText="Request No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton data-role="hint" data-hint-background="bg-red"
                                            data-hint="Remove|Remove this Item" data-hint-position="left" ID="btnLinkDelete"
                                            OnClientClick="return confirm('Are you sure?\n You want to delete this Item?')"
                                            runat="server" CausesValidation="False" CommandName="Delete" Text="Delete">
                                            <span class="icon mif-arrow-up"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                Please select item and click add to add in the list.
                            </EmptyDataTemplate>
                        </asp:GridView>

                    </div>
                </div>
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Bin" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a href="PurchaseRequestManagementPanel.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
