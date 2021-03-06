﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemEntry.aspx.cs" Inherits="Web.Dashboard.ItemEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="ItemManagementPanel.aspx"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Item</a></li>
            </ul>
            <h4 class="text-italic">New Item Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row">
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Item Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtItemCode"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan6 margin5">
                        <label style="font-weight: 800;">Bar Code</label>
                        <div class="input-control text full-size ">
                            <span class="mif-barcode prepend-icon"></span>
                            <asp:TextBox ReadOnly="True" runat="server" ID="txtBarCode"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="cell auto-size">
                    <label style="font-weight: 800;">Item Name</label>
                    <div class="input-control text full-size ">
                        <asp:TextBox runat="server" ID="txtItemName" />
                    </div>
                </div>
            </div>
            <%--  <div class="example" data-text="item details">--%>
            <div class="flex-grid">
                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Department</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLDepartments" AutoPostBack="True" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan6">
                        <label style="font-weight: 800;">Calssification</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLClassifications" DataSourceID="ObjectDataSourceClassifications"
                                DataTextField="ClassificationName" DataValueField="Id" AutoPostBack="True" />
                            <asp:ObjectDataSource ID="ObjectDataSourceClassifications" runat="server"
                                SelectMethod="FetchAll" TypeName="IM.BusinessLogic.DataManager.ItemClassificationManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="cell "></div>
                    <div class="cell colspan5">
                        <label style="font-weight: 800;">Type</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLTypes" DataSourceID="ObjectDataSourceTypes"
                                DataTextField="ItemDesciption" DataValueField="Id" AutoPostBack="True" />
                            <asp:ObjectDataSource ID="ObjectDataSourceTypes" runat="server" SelectMethod="FetchAll"
                                TypeName="IM.BusinessLogic.DataManager.ItemTypeManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="row">
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Quantity</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" min="1" Type="Number" ID="txtQuantity" Text="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Unit</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList runat="server" ID="DDLUnits" DataSourceID="ObjectDataSourceUnits" DataTextField="Description"
                                DataValueField="Id" />
                            <asp:ObjectDataSource ID="ObjectDataSourceUnits" runat="server" SelectMethod="FetchAll"
                                TypeName="IM.BusinessLogic.DataManager.UnitManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLDepartments" Name="departmentId"
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="cell colspan3 margin5">
                        <label style="font-weight: 800;">Re Order Level</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" min="1" Type="Number" ID="txtReOrderLevel" Text="1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cell colspan4">
                        <label style="font-weight: 800;">Last Purchase Date</label>
                        <div class="input-control text" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                            <asp:TextBox runat="server" ID="txtLastPurchaseDate"></asp:TextBox>
                            <button class="button"><span class="mif-calendar"></span></button>
                        </div>
                    </div>
                    <div class="cell colspan4">
                        <label style="font-weight: 800;">Last Selling Price</label>
                        <div class="input-control text ">
                            <asp:TextBox runat="server" CssClass="fg-darkRed" Text="0.00" ID="txtLastSellingPrice"></asp:TextBox>

                        </div>
                    </div>
                    <div class="cell colspan4">
                        <label style="font-weight: 800;">Last Purchase Price</label>
                        <div class="input-control text">
                            <asp:TextBox runat="server" CssClass="fg-darkRed" Text="0.00" ID="txtLastPurchasePrice"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <%--</div>--%>
            <hr class="thin bg-grayLighter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Bin" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a runat="server" id="hpLinkBack" href="ItemManagementPanel.aspx" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>
