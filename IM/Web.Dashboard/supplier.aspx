<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="supplier.aspx.cs" Inherits="Web.Dashboard.supplier" %>
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
            <h4 class="text-italic">New Supplier <span class="mif-file-text place-right"></span></h4>
            <div class="flex-grid">
                <div class="row">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight:800;">Supplier Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtItemCode"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label style="font-weight:800;">Supplier Name</label>
                        <div class="input-control text full-size ">
                            <span class="mif-barcode prepend-icon"></span>
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtBarCode"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
             <div class="row ">
                <div class="cell auto-size">
                    <label style="font-weight:800;">Address</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="txtaddress" />
                    </div>
                </div>
            </div>
           
            <div class="row ">
                <div class="cell colspan6 margin5">
                    <label style="font-weight:800;">Contact Person</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="txtContact" />
                    </div>
                </div>
                   <div class="cell colspan6 margin5">
                    <label style="font-weight:800;">Email address</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="TextBox1" />
                    </div>
                </div>
            </div>  

               <div class="row ">
                <div class="cell colspan6 margin5">
                    <label style="font-weight:800;">Telephone No.</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="TextBox2" />
                    </div>
                </div>
                   <div class="cell colspan6 margin5">
                    <label style="font-weight:800;">Fax No.</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="TextBox3" />
                    </div>
                </div>
            </div>  
            
             <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE ITEM" CssClass="button primary" />
            <a href="Default.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
