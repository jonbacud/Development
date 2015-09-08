<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationEntry.aspx.cs" Inherits="Web.Dashboard.DonationEntry" %>

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
                <li><a href="/DonationManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Donation</a></li>
            </ul>
            <h4 class="text-italic">New Donation Entry <span class="mif-file-text place-right"></span></h4>
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
                    <label style="font-weight: 600;">Donation Date</label>
                    <div class="input-control text full-size " data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                        <asp:TextBox runat="server" ID="txtDonationDate"></asp:TextBox>
                        <button class="button"><span class="mif-calendar"></span></button>
                    </div>
                </div>
                <div class="cell colspan4 margin5">
                    <label style="font-weight: 700;">Requisition Number</label>
                    <div class="input-control text full-size ">
                        <span class="mif-qrcode prepend-icon"></span>
                        <asp:TextBox CssClass="text-bold fg-darkRed" runat="server" ID="txtRISNumber"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Donated By</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDonatedBy" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Total Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required Text="0" Style="text-align: center;" CssClass="text-bold fg-darkRed"
                                ID="txtTotalQuantity" ReadOnly="True" type="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Donated To</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDonatedTo" AutoPostBack="True" OnSelectedIndexChanged="DDLDonatedTo_SelectedIndexChanged" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Recived By</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtReceivedBy"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-lighterBlue">
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 700;">Item</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLItems" AutoPostBack="True" OnSelectedIndexChanged="DDLItems_SelectedIndexChanged" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Unit</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLUnits" />
                        </div>
                    </div>
                    <div class="cell margin5">
                        <label style="font-weight: 700;">Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required ID="txtItemQuantity" Text="1" type="Number" min="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Price</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required Text="0.00" ID="txtPrice"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Barcode</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtBarcode"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:LinkButton Style="width: 230px;" class="button button-shadow default" ID="lnkButtonAdd"
                            runat="server" OnClick="lnkButtonAdd_Click">
                          <span class="mif-arrow-down"></span>Add Donation Item
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size">
                        <asp:GridView ID="gvSelectedItems" Style="width: 100%; font-size: 13px;" class="dataTable border bordered"
                            data-role="datatable" data-auto-width="false"
                            runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnRowDeleting="gvSelectedItems_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" ToolTip='<%# Eval("ItemId") %>'
                                            runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                <asp:BoundField DataField="Quantity" HeaderText="Qtty">
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Price" />
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
            <asp:Button ID="btnSave" runat="server" Text="SAVE"
                CssClass="button primary" OnClick="btnSave_Click" />
            <a href="/DonationManagementPanel" class="button link">
                <span class="mif-undo">BACK TO LIST</span>
            </a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
