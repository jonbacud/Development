<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsignmentDetailEntry.aspx.cs" Inherits="Web.Dashboard.ConsignmentDetailEntry" %>

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
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/DonationManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">Consignment</a></li>
                <li><a href="#">New Consignment Detail</a></li>
            </ul>
            <h4 class="text-italic">New Consignment Detail Entry<span class="mif-file-text place-right"></span></h4>
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
                    <label style="font-weight: 600;">Consignment Date</label>
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
                        <label style="font-weight: 700;">Company Name</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ReadOnly="True" ID="txtCompany"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Days Deliver</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required Text="0" Style="text-align: center;" CssClass="text-bold fg-darkRed"
                                ID="txtDaysDeliver" ReadOnly="True" type="Number"></asp:TextBox>
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
                        <label style="font-weight: 700;">Deliver To</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtDeliverTo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Prepared By</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required ReadOnly="True" runat="server" ID="txtPreparedBy"></asp:TextBox>
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
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE"
                CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Consignment Item" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <asp:HyperLink class="button link" runat="server" ID="hpLinkBack">
                  <span class="mif-undo">BACK TO LIST</span>
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
