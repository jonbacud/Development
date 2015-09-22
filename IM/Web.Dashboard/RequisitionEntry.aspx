<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequisitionEntry.aspx.cs" Inherits="Web.Dashboard.RequisitionEntry" %>

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
                <li><a href="/RequisitionManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Requestion</a></li>
            </ul>
            <h4 class="text-italic">New Requestion Entry<span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <div runat="server" style="width: 500px;" visible="False" clientidmode="Static" id="divMessageBox">
                            <span id="btnClose" class="notify-closer"></span>
                            <span class="notify-title">Submit Successful!</span>
                            <span class="notify-text">
                                <asp:Literal runat="server" ID="ltrlMessage"></asp:Literal>
                            </span>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="cell colspan6 margin5">
                    <label style="font-weight: 700;">Reference Number</label>
                    <div class="input-control text full-size ">
                        <span class="mif-anchor prepend-icon"></span>
                        <asp:TextBox CssClass="text-bold fg-darkRed" ReadOnly="True" runat="server" ID="txtReferenceNumber"></asp:TextBox>
                    </div>
                </div>
                <div class="cell colspan6 margin5">
                    <label style="font-weight: 700;">Date Requested</label>
                    <div class="input-control text full-size " data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                        <asp:TextBox runat="server" ID="txtDateRequested"></asp:TextBox>
                        <button class="button"><span class="mif-calendar"></span></button>
                    </div>
                </div>
            </div>
            <div>
                <div class="flex-grid">
                    <div class="row ">
                        <div class="cell auto-size">
                            <label style="font-weight: 700;">Department</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" AutoPostBack="True" ID="DDLDepartments"
                                    OnSelectedIndexChanged="DDLDepartments_SelectedIndexChanged" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell colspan5">
                            <label style="font-weight: 700;">Classification</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" ID="DDLClassifications" OnSelectedIndexChanged="DDLClassifications_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="cell "></div>
                        <div class="cell colspan5">
                            <label style="font-weight: 700;">Type</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList AutoPostBack="True" runat="server" ID="DDLTypes" OnSelectedIndexChanged="DDLTypes_SelectedIndexChanged" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="cell colspan8 auto-size">
                            <label style="font-weight: 700;">Items</label>
                            <div class="input-control text full-size ">
                                <asp:DropDownList runat="server" AutoPostBack="True" ID="DDLProducts"
                                    OnSelectedIndexChanged="DDLProducts_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="cell colspan2 margin10">
                            <div class="input-control">
                                <asp:HyperLink runat="server" Target="_blank" CssClass="button link"
                                    ID="hpLinkItemDetails">View Item Details</asp:HyperLink>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="cell colspan3">
                            <label style="font-weight: 700;">Item Code</label>
                            <div class="input-control text">
                                <span class="mif-tag prepend-icon"></span>
                                <asp:TextBox runat="server" ReadOnly="True" ID="txtItemCode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell colspan3">
                            <label style="font-weight: 700;">Barcode</label>
                            <div class="input-control text">
                                <span class="mif-barcode prepend-icon"></span>
                                <asp:TextBox runat="server" ReadOnly="True" ID="txtBarCode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell colspan3">
                            <label style="font-weight: 700;">Unit</label>
                            <div class="input-control text">
                                <asp:DropDownList runat="server" ID="DDLUnits" />
                            </div>
                        </div>
                        <div class="cell colspan3">
                            <div class="input-control">
                                <asp:HyperLink runat="server" Target="_blank" CssClass="button link" ID="hpLinkViewStocks">View Item Stocks</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="cell colspan2 margin5">
                            <label style="font-weight: 700;">Quantity Issue</label>
                            <div class="input-control text full-size">
                                <asp:TextBox runat="server" ID="txtQuantityIssue" min="1" Text="1" Type="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell colspan10 margin5">
                            <label style="font-weight: 700;">Request to</label>
                            <div class="input-control text full-size">
                                <asp:DropDownList runat="server" ID="DDLRequestTo" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:LinkButton class="button button-shadow default" ID="lnkButtonAdd" runat="server" OnClick="lnkButtonAdd_Click">
                          <span class="mif-arrow-down"></span>Add
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div>
                <div class="flex-grid">
                    <div class="row">
                        <div class="cell auto-size">
                            <asp:GridView ID="gvSelectedItems" Style="width: 100%; font-size: 13px;" class="dataTable border bordered" data-role="datatable" data-auto-width="false"
                                runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnRowDeleting="gvSelectedItems_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                            <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ClassificationName" HeaderText="Classification" />
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference No." />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="Remove from list." ID="btnLinkDelete"
                                                OnClientClick="return confirm('Are you sure?\n You want to delete this Item?')" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete">
                                            <span class="icon mif-arrow-up"></span>
                                            </asp:LinkButton>
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
            </div>
            <hr class="thin bg-grayLighter">
            <asp:Button runat="server" Text="SUBMIT REQUEST" CssClass="button primary" ID="btnSubmitEntry" OnClick="btnSubmitEntry_Click" />
            <span runat="server" id="btnProcess" class="button warning mif-file-text" onclick="showDialog('dialogProcess')">PROCESS REQUEST</span>
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Request" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a href="/RequisitionManagementPanel" class="button link">
                <span class="mif-undo">BACK TO LIST</span>
            </a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
    <div data-role="dialog" id="dialogProcess" class="padding20" data-close-button="true" data-type="warning"
        data-overlay="true" data-overlay-color="op-dark">
        <h3>Process Request </h3>
        <div class="row">
            <div class="cell auto-size">
                <label style="font-weight: 700;">Received Qty:</label>
                <div class="input-control text">
                    <asp:TextBox CssClass="text-bold fg-darkRed" runat="server" min="0" Text="1" Type="Number" ID="txtQuantityReceived"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row flex-just-center">
            <div class="cell">
                <div class="input-control">
                    <asp:Button CssClass="button default" runat="server" Text="PROCESS" ID="btnProcessRequest" OnClick="btnProcessRequest_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
