<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsignmentDetails.aspx.cs" Inherits="Web.Dashboard.ConsignmentDetails" %>

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
                    <label style="font-weight: 600;">Consignment Date</label>
                    <div class="input-control text full-size " data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                        <asp:TextBox runat="server" ID="txtConsignmentDate"></asp:TextBox>
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
                            <asp:DropDownList runat="server" ID="DDLCompanies" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Days Deliver</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" required ID="txtDaysDeliver" Text="1" type="Number" min="1"></asp:TextBox>
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
                            <asp:DropDownList runat="server" ID="DDlDeliverTo" AutoPostBack="True" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Recived By</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtPreparedBy"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="thin bg-lighterBlue">
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:HyperLink class="button button-shadow default" Style="width: 230px;"
                            NavigateUrl="" runat="server" ID="hpLinkNewDetail">
                             <span class="mif-arrow-down">Add Donation Item</span>
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size">
                        <asp:GridView ID="gvSelectedItems" Style="width: 100%; font-size: 13px;" class="dataTable border bordered"
                            data-role="datatable" data-auto-width="false"
                            runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
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
                                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:###,##0.00}">
                                    <ItemStyle Font-Bold="True" ForeColor="#990000" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" data-role="hint"
                                            data-hint-background="bg-blue" data-hint="Info.|View Donation Item Details" data-hint-position="left"
                                            NavigateUrl='<%# "~/consignment-detail-entry/0/"+Eval("Id")%>'>
                                                             <span class="mif-pencil"></span>
                                        </asp:HyperLink>
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
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Donation" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <asp:HyperLink class="button link" runat="server" ID="hpLinkBack">
                  <span class="mif-undo">BACK TO LIST</span>
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
