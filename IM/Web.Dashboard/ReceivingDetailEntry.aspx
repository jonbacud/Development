<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceivingDetailEntry.aspx.cs" Inherits="Web.Dashboard.ReceivingDetailEntry" %>
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
                <li><a href="/ReceivingManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a runat="server" id="hpLinkDetails" >Receiving Item Details</a></li>
                <li><a href="#">New Receiving Detail Item</a></li>
            </ul>
            <h4 class="text-italic">New Receiving Item Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Reference Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox disabled runat="server" ID="txtReferenceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">P.O. Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-qrcode prepend-icon"></span>
                            <asp:TextBox disabled runat="server" ID="txtPONumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Invoice Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtInvoiceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">P.R. Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtPRNumber"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Department</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtDepartment" disabled></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Receiving Date</label>
                        <div class="input-control text full-size" >
                            <asp:TextBox disabled runat="server" required ID="txtReceivingDate"></asp:TextBox>
                         
                        </div>
                    </div>
                    <div class="cell colspan5 margin5">
                        <label style="font-weight: 800;">Supplier</label>
                        <span class="mif-drive-eta"></span>
                        <div class="input-control text full-size">
                            <asp:TextBox runat="server" ID="txtSupplier" disabled></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Category</label>
                        <span class="mif-apps"></span>
                        <div class="input-control text full-size">
                         <asp:TextBox runat="server" ID="txtCategory" disabled></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">ALOBS Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtAlobsNumber" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Mode Procurement</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtModeProcurement" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtAmount" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Selling Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox disabled runat="server" ID="txtSellingAmount" />
                        </div>
                    </div>
                </div>
                <hr class="thin bg-active-brown">

                <div class="row">
                    <div class="cell colspan6">
                        <label style="font-weight: 800;">Classification</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList required runat="server" ID="DDLClassifications"
                               AutoPostBack="True" />
                        </div>
                    </div>
                    <div class="cell "></div>
                    <div class="cell colspan5">
                        <label style="font-weight: 800;">Type</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList required runat="server" ID="DDLTypes"  AutoPostBack="True" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Items</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList required runat="server" ID="DDLItems" AutoPostBack="True" />
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
                <div class="row">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" min="1" Type="Number" ID="txtReceivedQuantity" Text="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan3 margin5">
                        <label style="font-weight: 800;">Unit</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLUnits"   />
                          
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Price</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required ID="txtPrice" Text="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Total Price</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtTotalPrice" Text="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Selling Price</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtSellingPrice" Text="1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row cells5">
                    <div class="cell colspan3 margin5">
                        <label style="font-weight: 800;">Location</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLLocations" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Rack</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLRacks" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Bin</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLBins" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Shelf</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLShelves" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Expiry Date</label>
                        <div class="input-control text full-size" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                            <asp:TextBox runat="server" ID="txtExpiryDate"></asp:TextBox>
                            <button class="button bg-active-green"><span class="mif-calendar"></span></button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Remarks</label>
                        <div class="input-control text full-size">
                            <asp:TextBox runat="server" ID="txtRemarks"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Received Item" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a runat="server" id="hpLinkBack" class="button link"><span class="mif-undo"></span>BACK</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
