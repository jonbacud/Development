<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemIssuanceEntry.aspx.cs" Inherits="Web.Dashboard.ItemIssuanceEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%;">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li><a href="DepartmentManagementPanel.aspx">
                    <span class="mif-users icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Requisitions</span>
                    <span class="counter">0</span>
                </a></li>
                <li class="active"><a href="IssuanceManagementPanel.aspx">
                    <span class="mif-folder-minus icon"></span>
                    <span class="title">Items Issuance</span>
                    <span class="counter">2</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-database icon"></span>
                    <span class="title">Items/Products</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-drive-eta icon"></span>
                    <span class="title">Suppliers</span>
                    <span class="counter">0</span>
                </a></li>
                 <li><a href="#">
                    <span class="mif-undo icon"></span>
                    <span class="title">Returns</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-file-excel icon"></span>
                    <span class="title">Reports</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-user icon"></span>
                    <span class="title">User Accounts</span>
                    <span class="counter">0</span>
                </a></li>
            </ul>
        </div>
        <div class="cell auto-size padding20 bg-white" id="cell-content">
              <ul class="breadcrumbs2 small">
                    <li><a href="ItemIssuanceManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                    <li><a href="#">New Issuance</a></li>
                </ul>
            <h4 class="text-italic">New Issuance Entry <span class="mif-file-text place-right"></span></h4>
            <div class="row">
                <div class="cell colspan6 margin5">
                    <label>Reference Number</label>
                    <div class="input-control text full-size ">
                        <span class="mif-anchor prepend-icon"></span>
                        <asp:TextBox runat="server" ID="txtReferenceNumber"></asp:TextBox>
                    </div>
                </div>
                <div class="cell colspan6 margin5">
                    <label>Issuance Date</label>
                    <div class="input-control text full-size " data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                        <asp:TextBox runat="server" ID="txtIssuanceDate"></asp:TextBox>
                        <button class="button"><span class="mif-calendar"></span></button>
                    </div>
                </div>
            </div>
            <div class="example" data-text="Header">
                <div class="flex-grid">
                    <div class="row ">
                        <div class="cell auto-size">
                            <label>Issue to</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" ID="DDLDepartments" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell colspan5">
                            <label>Total Amount</label>
                            <div class="input-control text full-size ">
                                <span class="mif-money prepend-icon"></span>
                                <asp:TextBox runat="server" ID="txtTotalAmount" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell "></div>
                        <%--  <div class="cell colspan5">
                            <label>Type</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList AutoPostBack="True" runat="server" ID="DDLTypes" />
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
            <%--  <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:LinkButton class="button button-shadow default" ID="lnkButtonAdd" runat="server">
                          <span class="mif-arrow-down"></span>Add
                        </asp:LinkButton>
                    </div>
                </div>
            </div>--%>
            <div class="example" data-text="request details">
                <div class="flex-grid">
                    <div class="row">
                        <div class="cell auto-size">
                            <asp:GridView ID="gvSelectedItems" Style="width: 100%;" class="dataTable border bordered"
                                data-role="datatable" data-auto-width="false"
                                runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <label class="input-control checkbox small-check no-margin">
                                                <asp:CheckBox runat="server" ID="chkItem" />
                                                <span class="check"></span>
                                            </label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                            <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CalssificationName" HeaderText="Calssification" />
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Qtty" />
                                    <asp:TemplateField HeaderText="Issue Qtty">
                                        <ItemTemplate>
                                                <div class="input-control text" style="width:70px;">
                                                    <asp:TextBox ID="txtQuantity" Text='<%# Eval("Quantity") %>' runat="server" Type="Number">
                                                        
                                                    </asp:TextBox>
                                                </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:HyperLink Target="_blank" ToolTip="Viwe Details" runat="server"
                                                NavigateUrl='<%# "~/Items/ItemDetails.aspx?id="+Eval("ItemId") %>'>
                                            <span class="icon mif-file-text"></span>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    Please select item and click add to add in the list.
                                </EmptyDataTemplate>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSubmitIssuance" runat="server" Text="SUBMIT ISSUANCE" CssClass="button primary" OnClick="btnSubmitIssuance_Click" />
            <a href="RequisitionManagementPanel.aspx" class="button link">BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
