﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LocationManagementPanel.aspx.cs" Inherits="Web.Dashboard.LocationManagementPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="#"><span class="icon mif-folder-open"></span>Locations</a></li>
            </ul>
            <h4 class="text-italic">Locations Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="LocationEntry.aspx?mode=1&id=0" runat="server" ID="hpLnkAddNew">
                <span class="mif-plus"></span> Create...
            </asp:HyperLink>
            <asp:LinkButton ID="lnlBtnReLoad" class="button warning" runat="server"><span class="mif-loop2"></span> Reload</asp:LinkButton>
            <asp:HyperLink class="button alert" NavigateUrl="PrintDepartments.aspx" runat="server" ID="HyperLink2">
                <span class="mif-printer"></span> Print
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="cell colspan5">
                            <div class="input-control text full-size" data-role="input">
                                <asp:TextBox runat="server" ID="txtSearch" placeholder="Search..." AutoPostBack="True"></asp:TextBox>
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </div>
                    </div>
                    <div class="flex-grid">
                        <div class="row">
                            <div class="cell auto-size">
                                <asp:GridView GridLines="None" ID="gvLocations" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceLocations" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="location_id" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                         <asp:TemplateField>
                                            <ItemTemplate>
                                                <label class="input-control checkbox small-check no-margin">
                                                    <input runat="server" id="chkLocation" type="checkbox">
                                                    <span class="check"></span>
                                                </label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="location_id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="location_id">
                                         <ItemStyle HorizontalAlign="Center" Width="50px" />
                                         </asp:BoundField>
                                        <asp:BoundField DataField="location_code" HeaderText="Code" SortExpression="location_code"></asp:BoundField>
                                        <asp:BoundField DataField="location_desc" HeaderText="Description" SortExpression="location_desc"></asp:BoundField>
                                        <asp:BoundField DataField="department_desc" HeaderText="Department" SortExpression="department_desc"></asp:BoundField>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hpLnkInfo" data-role="hint" data-hint-background="bg-blue" 
                                                    data-hint="Info.|View Location Details" data-hint-position="left" 
                                                    NavigateUrl='<%# "~/LocationEntry.aspx?mode=0&id="+Eval("location_id") %>'>
                                                    <span class="mif-pencil"></span>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <EmptyDataTemplate>
                                        Data not found!
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#000" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle BorderStyle="None" CssClass="pager" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>  
                                <asp:SqlDataSource ID="SqlDataSourceLocations" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" 
                                    SelectCommand="SELECT ref_location.location_id, ref_location.location_desc, ref_location.location_code, ref_department.department_desc FROM ref_location INNER JOIN ref_department ON ref_location.dep_id = ref_department.department_id order by ref_location.location_id desc"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
