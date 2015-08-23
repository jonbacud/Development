<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierEntry.aspx.cs" Inherits="Web.Dashboard.SupplierEntry" %>

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
                <li><a href="ReceivingItemsManagementPanel.aspx">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="Items/Default.aspx">
                    <span class="mif-database icon"></span>
                    <span class="title">Items/Products</span>
                    <span class="counter">0</span>
                </a></li>
                <li class="active"><a href="SupplierManagementPanel.aspx">
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
                <li><a href="SupplierManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Supplier</a></li>
            </ul>
            <h4 class="text-italic">New Supplier <span class="mif-file-text place-right"></span></h4>
             <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row cell2">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Supplier Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtSupplierCode"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Supplier Name</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtSupplierName"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Address</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtSupplierAddress" />
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Contact Person</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtContactPerson" />
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Email address</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtEmailAddress" />
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Telephone No.</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtTelephoneNumber" />
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Fax No.</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtFaxNumber" />
                        </div>
                    </div>
                </div>

                <div class="row ">
                    <div class="cell colspan8 margin5 ">
                        <label style="font-weight: 800;">Department</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList ID="DDLDepartments" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="cell colspan4 margin20">
                        <label class="input-control checkbox">
                            <asp:CheckBox Text="" ID="chkIsConsignment" runat="server" />
                            <span class="check"></span>
                            <span class="caption">Consignment</span>
                        </label>
                    </div>
                </div>
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE ITEM" CssClass="button primary" OnClick="btnSave_Click" />
            <a href="SupplierManagementPanel.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
