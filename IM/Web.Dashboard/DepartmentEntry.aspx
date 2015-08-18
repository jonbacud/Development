<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentEntry.aspx.cs" Inherits="Web.Dashboard.NewDepartmentEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">

        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li class="active"><a href="DepartmentManagementPanel.aspx">
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
                <li><a href="DepartmentManagementPanel.aspx"><span class="icon mif-folder"></span></a></li>
                <li><a href="#">Department Entry</a></li>
            </ul>
            <h4 class="text-italic" >
                <asp:Literal runat="server" Text="New Department" ID="ltrlTitle"></asp:Literal>
                <span class="mif-file-text place-right"></span>
            </h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size">
                        <label >Department Description</label>
                        <div class="input-control text full-size" data-role="input">
                            <asp:TextBox runat="server" ID="txtDescription" placeholder="" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row cells2">
                    <div class="cell colspan3 margin5">
                        <label>Type</label>
                        <label class="input-control radio">
                            <asp:RadioButton ID="rdioRetail" Checked="True" runat="server" GroupName="departmentType"
                                 OnCheckedChanged="rdioRetail_CheckedChanged" AutoPostBack="True" />
                            <span class="check"></span>
                            <span class="caption">Retail</span>
                        </label>
                        <label class="input-control radio">
                            <asp:RadioButton ID="rdioWholesale" runat="server" GroupName="departmentType"
                                 AutoPostBack="True" OnCheckedChanged="rdioWholesale_CheckedChanged" />
                            <span class="check"></span>
                            <span class="caption">Whole Sale</span>
                        </label>
                    </div>
                    <div class="cell colspan3">
                        <label>Department Code</label>
                        <div class="input-control text full-size" data-role="input">
                            <asp:TextBox runat="server" Enabled="False" ID="txtDepartmentCode" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <hr class="thin bg-grayLighter">
                <div class="row">
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button" OnClick="btnSave_Click"/>
                    <asp:HyperLink CssClass="button link" runat="server" NavigateUrl="DepartmentManagementPanel.aspx">
                        <span class="mif-undo"></span>
                        BACK TO LIST
                    </asp:HyperLink>
                </div>
                <hr class="thin bg-grayLighter">
            </div>
        </div>
    </div>
</asp:Content>
