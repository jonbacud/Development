<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemIssuanceEntry.aspx.cs" Inherits="Web.Dashboard.ItemIssuanceEntry" %>

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
                            <span class="notify-title">  <asp:Literal runat="server" ID="ltrlMessageHeader"></asp:Literal></span>
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
                        <asp:TextBox CssClass="text-bold fg-darkRed" runat="server" ID="txtRISNumber"></asp:TextBox>
                        <asp:LinkButton runat="server" ID="btnGetRISDetail"
                            class="button success block-shadow-success text-shadow" OnClick="btnGetRISDetail_Click">
                                 <span class="mif-search"></span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 700;">Issue to</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDepartments" />
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 700;">Total Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" style="text-align:center;" CssClass="text-bold fg-darkRed"
                                 ID="txtTotalAmount" ReadOnly="True"></asp:TextBox>
                        </div>
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
                                        <asp:Label ID="lblItemName" ToolTip='<%# Eval("RequesitionId") %>' 
                                             runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClassificationName" HeaderText="Classification" />
                                <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                                <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                <asp:BoundField DataField="Quantity" HeaderText="Qtty" >
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rcvd Qtty" >
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Issue Qtty">
                                    <ItemTemplate>
                                        <div class="input-control text" style="width: 70px;">
                                            <asp:TextBox CssClass="text-bold fg-darkRed" ID="txtQuantity" 
                                                Text='<%# Eval("Quantity") %>' runat="server" Type="Number">
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
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSubmitIssuance" Enabled="False" runat="server" Text="SUBMIT ISSUANCE" 
                CssClass="button primary" OnClick="btnSubmitIssuance_Click" />
            <a href="/IssuanceManagementPanel" class="button link">
                <span class="mif-undo">BACK TO LIST</span>
            </a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
