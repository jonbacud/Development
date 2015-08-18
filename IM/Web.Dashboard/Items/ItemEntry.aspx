<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemEntry.aspx.cs" 
    Inherits="Web.Dashboard.Items.ItemEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li><a href="../DepartmentManagementPanel.aspx">
                    <span class="mif-users icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="../RequisitionManagementPanel.aspx">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Requisitions</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="IssuanceManagementPanel.aspx">
                    <span class="mif-folder-minus icon"></span>
                    <span class="title">Items Issuance</span>
                    <span class="counter">2</span>
                </a></li>
                <li><a href="../ReceivingItemsManagementPanel.aspx">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li class="active"><a href="Default.aspx">
                    <span class="mif-database icon"></span>
                    <span class="title">Items/Products</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="../SupplierManagementPanel.aspx">
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
                <li><a href="Default.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Item</a></li>
            </ul>
            <h4 class="text-italic">New Item Entry <span class="mif-file-text place-right"></span></h4>
            <div class="flex-grid">
                <div class="row">
                    <div class="cell colspan6 margin5">
                        <label>Item Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox  runat="server" ID="txtItemCode"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label>Bar Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-barcode prepend-icon"></span>
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtBarCode"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="cell auto-size">
                    <label>Item Name</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="txtItemName" />
                    </div>
                </div>
            </div>
            <div class="example" data-text="item details">
                <div class="flex-grid">
                    <div class="row ">
                        <div class="cell auto-size">
                            <label>Department</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" ID="DDLDepartments" DataSourceID="ObjectDataSourceDepartments"
                                    DataTextField="Description" DataValueField="Id" AutoPostBack="True" />
                                <asp:ObjectDataSource ID="ObjectDataSourceDepartments" runat="server" SelectMethod="FetchAll"
                                    TypeName="IM.BusinessLogic.DataManager.DepartmentManager"></asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell colspan6">
                            <label>Calssification</label>
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
                            <label>Type</label>
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
                    </div>
                    <div class="row cells3">
                        <div class="cell colspan4 margin5">
                            <label>Quantity</label>
                            <div class="input-control text full-size ">
                                <asp:TextBox runat="server" min="1" Type="Number" ID="txtQuantity" Text="1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell colspan4 margin5">
                            <label>Unit</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" ID="DDLUnits" DataSourceID="ObjectDataSourceUnits" DataTextField="Description"
                                    DataValueField="Id" />
                                <asp:ObjectDataSource ID="ObjectDataSourceUnits" runat="server" SelectMethod="FetchAll"
                                    TypeName="IM.BusinessLogic.DataManager.UnitManager">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="cell colspan4 margin5">
                            <label>Re Order Level</label>
                            <div class="input-control text full-size ">
                                <asp:TextBox runat="server" min="1" Type="Number" ID="txtReOrderLevel" Text="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell colspan4">
                            <label>Last Purchase Date</label>
                            <div class="input-control text" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                                <asp:TextBox runat="server" ID="txtLastPurchaseDate"></asp:TextBox>
                                <button class="button"><span class="mif-calendar"></span></button>
                            </div>
                        </div>
                        <div class="cell colspan4">
                            <label>Last Selling Price</label>
                            <div class="input-control text">
                                <span class="mif-money prepend-icon"></span>
                                <asp:TextBox runat="server" ID="txtLastSellingPrice"></asp:TextBox>

                            </div>
                        </div>
                        <div class="cell colspan4">
                            <label>Last Purchase Price</label>
                            <div class="input-control text">
                                <span class="mif-money prepend-icon"></span>
                                <asp:TextBox runat="server" ID="txtLastPurchasePrice"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE ITEM" CssClass="button primary" OnClick="btnSave_Click" />
            <a href="Default.aspx" class="button link"> <span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
