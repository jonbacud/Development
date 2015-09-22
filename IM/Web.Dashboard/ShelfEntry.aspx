<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShelfEntry.aspx.cs" Inherits="Web.Dashboard.ShelfEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="ShelveManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Shelf</a></li>
            </ul>
            <h4 class="text-italic">New Shelf<span class="mif-file-text place-right"></span></h4>
                      <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Shelf Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtShelfCode"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="cell auto-size">
                    <label style="font-weight: 800;">Description</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="txtShelfDescription" />
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="cell colspan8 margin5 ">
                    <label style="font-weight: 800;">Department</label>
                    <div class="input-control text full-size ">
                        <asp:DropDownList ID="DDLDepartments" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click"   />
             <asp:Button runat="server" Visible="False"  ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                 data-hint="Delete|Delete this Shelf" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a href="ShelveManagementPanel.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
