﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceivingDetails.aspx.cs" Inherits="Web.Dashboard.ReceivingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/ReceivingManagementPanel"><span class="icon mif-folder-open"></span></a></li>
                <li><a href="#">New Receiving Item</a></li>
            </ul>
            <h4 class="text-italic">New Receiving Item Entry <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <div class="flex-grid">
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Reference Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-tag prepend-icon"></span>
                            <asp:TextBox disabled runat="server" ID="txtReferenceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">P.O. Number</label>
                        <div class="input-control text full-size ">
                            <span class="mif-qrcode prepend-icon"></span>
                            <asp:TextBox runat="server" ID="txtPONumber"></asp:TextBox>
                            <asp:LinkButton runat="server" ID="btnGetPODetail" class="button success block-shadow-success text-shadow">
                                 <span class="mif-search"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="cell">
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Invoice Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtInvoiceNumber"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">P.R. Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox runat="server" ID="txtPRNumber"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size">
                        <label style="font-weight: 800;">Department</label>
                        <div class="input-control text full-size ">
                            <asp:DropDownList required runat="server" ID="DDLDepartments" AutoPostBack="True"
                                OnSelectedIndexChanged="DDLDepartments_SelectedIndexChanged" />
                        </div>
                    </div>
                </div>
                <div class="row cells12">
                    <div class="cell colspan2 margin5">
                        <label style="font-weight: 800;">Receiving Date</label>
                        <div class="input-control text full-size" data-role="datepicker" data-date="1972-12-21" data-format="mmmm d, yyyy">
                            <asp:TextBox runat="server" required ID="txtReceivingDate"></asp:TextBox>
                            <button class="button bg-active-green"><span class="mif-calendar"></span></button>
                        </div>
                    </div>
                    <div class="cell colspan5 margin5">
                        <label style="font-weight: 800;">Supplier</label>
                        <span class="mif-drive-eta"></span>
                        <div class="input-control text full-size">
                            <asp:DropDownList required runat="server" ID="DDLSuppliers" />
                        </div>
                    </div>
                    <div class="cell colspan4 margin5">
                        <label style="font-weight: 800;">Category</label>
                        <span class="mif-apps"></span>
                        <div class="input-control text full-size">
                            <asp:DropDownList runat="server" ID="DDLCategories" />
                        </div>
                    </div>
                </div>
                <div class="row ">
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">ALOBS Number</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtAlobsNumber" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Mode Procurement</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtModeProcurement" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtAmount" />
                        </div>
                    </div>
                    <div class="cell auto-size margin5">
                        <label style="font-weight: 800;">Selling Amount</label>
                        <div class="input-control text full-size ">
                            <asp:TextBox required runat="server" ID="txtSellingAmount" />
                        </div>
                    </div>
                </div>
                <hr class="thin bg-active-brown">
            </div>
            <div class="flex-grid">
                <div class="row flex-just-center">
                    <div class="cell">
                        <asp:HyperLink style="width: 210px;"  class="button button-shadow default" runat="server" ID="hpLinkAddRecevingDetail">
                            <span class="mif-plus">Add Receiving Item</span> 
                        </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="flex-grid">
                <div class="row">
                    <div class="cell auto-size">
                        <asp:GridView ID="gvSelectedItems" EnableViewState="False" Style="width: 100%; font-size: 12px;" class="dataTable border bordered" data-role="datatable"
                            data-auto-width="false"
                            runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hfUniqueId" Value='<%# Bind("Uid") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReceivedQuantity" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SellingPrice" HeaderText="Selling Price" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocationName" HeaderText="Location">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RackName" HeaderText="Rack">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BinName" HeaderText="Bin">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShelveName" HeaderText="Shelf">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" data-role="hint" data-hint-background="bg-red"
                                            data-hint="Info.|View detail" data-hint-position="left"
                                            NavigateUrl='<%# "receiving-detail/0/"+Eval("Uid") %>'>
                                            <span class="icon mif-pencil"></span>
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
            <asp:Button ID="btnSave" runat="server" Text="SAVE" CssClass="button primary" OnClick="btnSave_Click" />
            <asp:Button runat="server" Visible="False" ID="btnDelete" data-role="hint" data-hint-background="bg-red"
                data-hint="Delete|Delete this Bin" data-hint-position="top" CssClass="button alert" Text="DELETE" OnClick="btnDelete_Click" />
            <a href="/ReceivingManagementPanel" class="button link"><span class="mif-undo"></span>BACK TO LIST</a>
            <hr class="thin bg-grayLighter">
        </div>
    </div>
</asp:Content>

