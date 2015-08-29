<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseRequestManagementPanel.aspx.cs" Inherits="Web.Dashboard.PurchaseRequestManagementPanel" %>

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
                <li><a href="#"><span class="icon mif-folder-open"></span>Purchase Request</a></li>
            </ul>
            <h4 class="text-italic">Purchase Reques Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="ItemEntry.aspx?mode=1&id=0" runat="server" ID="hpLnkAddNew">
                <span class="mif-plus"></span> Create...
            </asp:HyperLink>
            <asp:LinkButton ID="lnlBtnReLoad" class="button warning" runat="server"><span class="mif-loop2"></span> Reload</asp:LinkButton>
            <asp:HyperLink class="button alert" NavigateUrl="PrintItem.aspx" runat="server" ID="HyperLink2">
                <span class="mif-printer"></span> Print
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="cell colspan5">
                            <div class="input-control text full-size" data-role="input">
                                <asp:TextBox runat="server" ID="txtSearch" placeholder=" Search..."></asp:TextBox>
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </div>
                    </div>
                    <div class="flex-grid">
                        <div class="row">
                            <div class="cell auto-size">
                                <asp:GridView ID="gvItems" Font-Size="12px" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataSourceID="SqlDataSourceItems" DataKeyNames="id" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="requisition_no" HeaderText="Request No." SortExpression="requisition_no" />
                                        <asp:BoundField DataField="pr_date" HeaderText="Request Date" SortExpression="pr_date" 
                                            DataFormatString="{0:MMMM dd, yyyy}" />
                                        <asp:BoundField DataField="sai_number" HeaderText="SAI No." SortExpression="sai_number" />
                                        <asp:BoundField DataField="alobs_number" HeaderText="ALOBS No." SortExpression="alobs_number" />
                                        <asp:BoundField DataField="stock_number" HeaderText="Stock No." SortExpression="stock_number" />
                                        <asp:BoundField DataField="requested_by" HeaderText="Request By" SortExpression="requested_by" />
                                        <asp:BoundField DataField="received_by" HeaderText="Received By" SortExpression="received_by" />
                                        <asp:BoundField DataField="item_name" HeaderText="Item Name" SortExpression="item_name" />
                                        <asp:BoundField DataField="unit_code" HeaderText="Unit Code" SortExpression="unit_code" />
                                        <asp:BoundField DataField="pr_quantity" HeaderText="Quantity" SortExpression="pr_quantity" />
                                        <asp:BoundField DataField="pr_status" HeaderText="Status" SortExpression="pr_status" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hpLnkInfo" data-role="hint" data-hint-background="bg-blue"
                                                    data-hint="Info.|View Item Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/PurchaseRequestEntry.aspx?mode=0&id="+Eval("id") %>'>
                                                    <span class="mif-pencil"></span>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceItems" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT purchase_requests.*, ref_item.item_name FROM purchase_requests INNER JOIN ref_item ON purchase_requests.pr_id = ref_item.item_id"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
