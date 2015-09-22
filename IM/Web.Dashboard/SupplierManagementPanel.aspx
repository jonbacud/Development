<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierManagementPanel.aspx.cs" Inherits="Web.Dashboard.SupplierManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">

        <div class="cell auto-size padding20 no-margin bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/SupplierManagementPanel"><span class="icon mif-folder-open"></span>Suppliers</a></li>
            </ul>
            <h4 class="text-italic">Supplier Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="supplier/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:GridView GridLines="None" ID="gvSuppliers" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDepartments" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="supplier_id" PageSize="5" CellPadding="4" 
                                    ForeColor="#333333" OnPageIndexChanging="gvSuppliers_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <label class="input-control checkbox small-check no-margin">
                                                    <input type="checkbox">
                                                    <span class="check"></span>
                                                </label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="supplier_id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="supplier_id">
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="supplier_code" HeaderText="Code" SortExpression="supplier_code"></asp:BoundField>
                                        <asp:BoundField DataField="supplier_name" HeaderText="Name" SortExpression="supplier_name"></asp:BoundField>
                                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address"></asp:BoundField>
                                        <asp:BoundField DataField="contact_person" HeaderText="Contact person" 
                                            SortExpression="contact_person"></asp:BoundField>
                                        <asp:BoundField DataField="telNo" HeaderText="Tel No" SortExpression="telNo"></asp:BoundField>
                                        <asp:BoundField DataField="faxNumber" HeaderText="Fax No" SortExpression="faxNo"></asp:BoundField>
                                        <asp:BoundField DataField="emailaddress" HeaderText="Email" SortExpression="emailaddress"></asp:BoundField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" data-role="hint" data-hint-background="bg-blue" 
                                                    data-hint="Info.|View Supplier Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/supplier/0/"+Eval("supplier_id")%>'>
                                        <span class="mif-pencil"></span>
                                                </asp:HyperLink>

                                            </ItemTemplate>
                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
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
                                <asp:SqlDataSource ID="SqlDataSourceDepartments" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:IMConnectionString %>"
                                    SelectCommand="SELECT * FROM [ref_supplier] order by supplier_id desc"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
