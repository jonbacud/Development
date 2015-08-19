﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Dashboard.Items.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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
                <li><a href="Default.aspx"><span class="icon mif-folder-open"></span>Items</a></li>
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
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceItems">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                        <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" SortExpression="ItemCode" />
                                        <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode" />
                                        <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                                        <asp:BoundField DataField="ClassificationId" HeaderText="ClassificationId" SortExpression="ClassificationId" />
                                        <asp:BoundField DataField="TypeId" HeaderText="TypeId" SortExpression="TypeId" />
                                        <asp:BoundField DataField="UnitId" HeaderText="UnitId" SortExpression="UnitId" />
                                        <asp:BoundField DataField="LastPurchaseDate" HeaderText="LastPurchaseDate" SortExpression="LastPurchaseDate" />
                                        <asp:BoundField DataField="LastPurchasePrice" HeaderText="LastPurchasePrice" SortExpression="LastPurchasePrice" />
                                        <asp:BoundField DataField="LastSellingPrice" HeaderText="LastSellingPrice" SortExpression="LastSellingPrice" />
                                        <asp:BoundField DataField="ReOrderQuantity" HeaderText="ReOrderQuantity" SortExpression="ReOrderQuantity" />
                                        <asp:BoundField DataField="ReOrderLevel" HeaderText="ReOrderLevel" SortExpression="ReOrderLevel" />
                                        <asp:BoundField DataField="DepartmentId" HeaderText="DepartmentId" SortExpression="DepartmentId" />
                                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                                        <asp:BoundField DataField="UniqueId" HeaderText="UniqueId" SortExpression="UniqueId" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSourceItems" runat="server" SelectMethod="FetchAll" TypeName="IM.BusinessLogic.DataManager.ItemManager"></asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
