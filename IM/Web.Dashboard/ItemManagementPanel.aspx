<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemManagementPanel.aspx.cs" Inherits="Web.Dashboard.ItemManagementPanel" %>
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
                <li><a href="#"><span class="icon mif-folder-open"></span>Items</a></li>
            </ul>
            <h4 class="text-italic">Items Management <span class="mif-file-text place-right"></span></h4>
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
                                    DataSourceID="SqlDataSourceItems" DataKeyNames="item_id"  class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="item_id" HeaderText="ID" SortExpression="item_id" InsertVisible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="item_code" HeaderText="CODE" SortExpression="item_code" />
                                        <asp:BoundField DataField="barcode" HeaderText="BARCODE" SortExpression="barcode" />
                                        <asp:BoundField DataField="item_name" HeaderText="NAME" SortExpression="item_name" />
                                        <asp:BoundField DataField="classification_name" HeaderText="CLASSIFICATION" SortExpression="classification_name" />
                                        <asp:BoundField DataField="item_type_desc" HeaderText="TYPE" SortExpression="item_type_desc" />
                                        <asp:BoundField DataField="last_purchase_price" HeaderText="LAST PURCHASE PRICE" SortExpression="last_purchase_price" />
                                        <asp:BoundField DataField="last_selling_price" HeaderText="LAST SELLING PRICE" SortExpression="last_selling_price" />
                                        <asp:BoundField DataField="reorder_qty" HeaderText="REORDER QTTY" SortExpression="reorder_qty" />
                                        <asp:BoundField DataField="department_desc" HeaderText="DEPARTMENT" SortExpression="department_desc" />
                                        <asp:BoundField DataField="datecreated" HeaderText="DATE CREATED" SortExpression="datecreated" />
                                        <asp:TemplateField>
                                              <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hpLnkInfo" data-role="hint" data-hint-background="bg-blue"
                                                    data-hint="Info.|View Item Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/ItemEntry.aspx?mode=0&id="+Eval("item_id") %>'>
                                                    <span class="mif-pencil"></span>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceItems" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT ref_item.item_id, ref_item.item_code, ref_item.barcode, ref_item.item_name, ref_item_classifcation.classification_name, ref_item_type.item_type_desc,  ref_item.last_purchased_date, ref_item.last_purchase_price, ref_item.last_selling_price, ref_item.reorder_qty, ref_item.reorder_level, ref_department.department_desc, ref_item.datecreated FROM ref_item INNER JOIN ref_item_classifcation ON ref_item.item_class_id = ref_item_classifcation.classifcation_id INNER JOIN ref_item_type ON ref_item.item_type_id = ref_item_type.itemtype_id INNER JOIN ref_department ON ref_item.dep_id = ref_department.department_id"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
