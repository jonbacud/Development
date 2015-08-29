<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceivingEntry.aspx.cs" Inherits="Web.Dashboard.ReceivingEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li><a href="DepartmentManagementPanel.aspx">
                    <span class="mif-users icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="RequisitionManagementPanel.aspx">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Requisitions</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="IssuanceManagementPanel.aspx">
                    <span class="mif-folder-minus icon"></span>
                    <span class="title">Items Issuance</span>
                    <span class="counter">2</span>
                </a></li>
                <li><a href="ReceivingManagementPanel.aspx">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li class="active"><a href="Default.aspx">
                    <span class="mif-database icon"></span>
                    <span class="title">Items/Products</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="SupplierManagementPanel.aspx">
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
                    <span class="mif-apps icon"></span>
                    <span class="title">Item Storage</span>
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
                <li><a href="ItemManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Receiving Item</a></li>
            </ul>
            <h4 class="text-italic">New Receiving Item Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Reference Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtReferenceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">P.O. Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-qrcode prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtPONumber"></asp:TextBox>
                            <asp:LinkButton runat="server" ID="btnGetPODetail" class="button success block-shadow-success text-shadow">
                                 <span class="mif-search"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="cell">
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Invoice Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtInvoiceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">P.R. Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtPRNumber"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Receiving Date</label>
                        <div class="input-control text full-size" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                            <asp:TextBox runat="server" ID="txtLastPurchaseDate"></asp:TextBox>
                            <button class="button bg-active-green"><span class="mif-calendar"></span></button>
                        </div>
                    </div>
                    <div class="cell colspan5 margin5">
                        <label style="font-weight: 800;">Supplier</label>
                        <div class="input-control text full-size">
                             <span class="mif-drive-eta prepend-icon"></span>
                             <asp:DropDownList runat="server" ID="DDLSuppliers"/>
                        </div>
                    </div>
                     <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Category</label>
                        <div class="input-control text full-size">
                             <span class="mif-apps prepend-icon"></span>
                             <asp:DropDownList runat="server" ID="DDLCategories"/>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">ALOBS Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtItemName" />
                        </div>
                    </div>
                     <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Mode Procurement</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="TextBox1" />
                        </div>
                    </div>
                     <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="TextBox2" />
                        </div>
                    </div>
                     <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Selling Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="TextBox3" />
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Department</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDepartments" AutoPostBack="True" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan6">
                        <label style="font-weight: 800;">Classification</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLClassifications" DataSourceID="ObjectDataSourceClassifications"
                                DataTextField="ClassificationName" DataValueField="Id" AutoPostBack="True" />
                            <asp:ObjectDataSource ID="ObjectDataSourceClassifications" runat="server"
                                SelectMethod="FetchAll" TypeName="IM.BusinessLogic.DataManager.ItemClassificationManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="cell "></div>
                    <div class="cell colspan5">
                        <label style="font-weight: 800;">Type</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLTypes" DataSourceID="ObjectDataSourceTypes"
                                DataTextField="ItemDesciption" DataValueField="Id" AutoPostBack="True" />
                            <asp:ObjectDataSource ID="ObjectDataSourceTypes" runat="server" SelectMethod="FetchAll"
                                TypeName="IM.BusinessLogic.DataManager.ItemTypeManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="row">
                     <div class="cell auto-size">
                        <label style="font-weight: 800;">Items</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLItems" AutoPostBack="True" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" min="1" Type="Number" ID="txtQuantity" Text="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Unit</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLUnits" DataSourceID="ObjectDataSourceUnits" DataTextField="Description"
                                DataValueField="Id" />
                            <asp:ObjectDataSource ID="ObjectDataSourceUnits" runat="server" SelectMethod="FetchAll"
                                TypeName="IM.BusinessLogic.DataManager.UnitManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="cell colspan3 margin5">
                        <label style="font-weight: 800;">Re Order Level</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" min="1" Type="Number" ID="txtReOrderLevel" Text="1"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Bin" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a href="ReceivingManagementPanel.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
