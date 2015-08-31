<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssuanceDetailEntry.aspx.cs" Inherits="Web.Dashboard.IssuanceDetailEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function showDialog(id) {
            var dialog = $("#" + id).data('dialog');
            if (!dialog.element.data('opened')) {
                dialog.open();
            } else {
                dialog.close();
            }
        }
        $(document).ready(function () {
            $('#btnClose').click(function () {
                $('#divMessageBox').hide('slow');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%;">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li><a href="/DepartmentManagementPanel">
                    <span class="mif-users icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="/RequisitionManagementPanel">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Requisitions</span>
                    <span class="counter">0</span>
                </a></li>
                <li class="active"><a href="/IssuanceManagementPanel">
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
                <li><a href="/IssuanceManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Issuance</a></li>
            </ul>
            <h4 class="text-italic">New Issuance Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <div runat="server" style="width: 500px;" visible="False" clientidmode="Static" id="divMessageBox">
                            <span id="btnClose" class="notify-closer"></span>
                            <span class="notify-icon mif-info"></span>
                            <span class="notify-title">
                                <asp:Literal runat="server" ID="ltrlMessageHeader"></asp:Literal></span>
                            <span class="notify-text">
                                <asp:Literal runat="server" ID="ltrlMessage"></asp:Literal>
                            </span>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="cell colspan3 margin5">
                    <label style="font-weight: 700;">Reference Number</label>
                    <div class="input-control text full-size ">
                        <span class="mif-anchor prepend-icon"></span>
                        <asp:TextBox ReadOnly="True" CssClass="text-bold fg-darkRed" runat="server" ID="txtReferenceNumber"></asp:TextBox>
                    </div>
                </div>
                <div class="cell colspan3 margin5">
                    <label style="font-weight: 600;">Issuance Date</label>
                    <div class="input-control text full-size " data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                        <asp:TextBox runat="server" ID="txtIssuanceDate"></asp:TextBox>
                        <button class="button"><span class="mif-calendar"></span></button>
                    </div>
                </div>
                <div class="cell colspan4 margin5">
                    <label style="font-weight: 700;">Requisition Number</label>
                    <div class="input-control text full-size ">
                        <span class="mif-qrcode prepend-icon"></span>
                        <asp:TextBox ReadOnly="True" CssClass="text-bold fg-darkRed" runat="server" ID="txtRISNumber"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Issue to</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList Enabled="False" runat="server" ID="DDLDepartments" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Total Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" Style="text-align: center;" CssClass="text-bold fg-darkRed"
                                ID="txtTotalAmount" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 700;">Item Name</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtItemName"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 700;">Barcode</label>
                        <div class="input-control text full-size ">
                            <span class="mif-barcode prepend-icon"></span>
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtBarCode"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 700;">Issued Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox Type="Number" min="0" runat="server" ID="txtIssuedQuantity"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Item Price</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtPrice"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-lighterBlue">
            <div class="flex-grid">
                <div class="row">
                    <div class="cell colspan4  margin5">
                        <label style="font-weight: 700;">Request Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtRequestQuantity"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan3  margin5">
                        <label style="font-weight: 700;">Received Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox Type="Number" ReadOnly="True" runat="server" ID="txtReceivedQuantity"></asp:TextBox>
                        </div>
                    </div>
                   
                </div>
            </div>

            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSubmitIssuance" runat="server" Text="SUBMIT ISSUANCE"
                CssClass="button primary" OnClick="btnSubmitIssuance_Click" />
            <a runat="server" id="hpLnkBack" href="/IssuanceManagementPanel" class="button link">
                <span class="mif-undo">BACK TO LIST</span>
            </a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
