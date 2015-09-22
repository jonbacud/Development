<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentEntry.aspx.cs" Inherits="Web.Dashboard.NewDepartmentEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row cells2 auto-size" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/DepartmentManagementPanel"><span class="icon mif-folder"></span></a></li>
                <li><a href="#">Department Entry</a></li>
            </ul>
            <h4 class="text-italic">
                <asp:Literal runat="server" Text="New Department" ID="ltrlTitle"></asp:Literal>
                <span class="mif-file-text place-right"></span>
            </h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size margin5">
                        <label>Department Description</label>
                        <div class="input-control text full-size">
                            <asp:TextBox runat="server" ID="txtDescription" placeholder=""></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
                <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                    data-hint="Delete|Delete this Department" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
                <asp:HyperLink CssClass="button link" runat="server" NavigateUrl="/DepartmentManagementPanel">
                        <span class="mif-undo"></span>
                        BACK TO LIST
                </asp:HyperLink>
                <hr class="thin bg-grayLighter">
            </div>
        </div>
    </div>
</asp:Content>
