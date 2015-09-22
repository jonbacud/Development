<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceivingManagementPanel.aspx.cs" Inherits="Web.Dashboard.ReceivingManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="#"><span class="icon mif-folder-open"></span>Received Items</a></li>
            </ul>
            <h4 class="text-italic">Receiving Items Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="receiving/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:TextBox runat="server" ID="txtSearch" placeholder="Search..." AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </div>
                    </div>
                    <div class="flex-grid">
                        <div class="row">
                            <div class="cell auto-size">
                                <asp:GridView GridLines="None" Font-Size="12px" ID="gvCategories"
                                    class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceReceiving" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="receiving_id" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="receiving_id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="receiving_id"></asp:BoundField>
                                        <asp:BoundField DataField="reference_no" HeaderText="Ref. No." SortExpression="reference_no"></asp:BoundField>
                                        <asp:BoundField DataField="po_number" HeaderText="P.O. No." SortExpression="po_number"></asp:BoundField>
                                        <asp:BoundField DataField="invoice_no" HeaderText="Invoice No." SortExpression="invoice_no"></asp:BoundField>
                                        <asp:BoundField DataField="pr_number" HeaderText="P.R. No." SortExpression="pr_number" />
                                        <asp:BoundField DataField="receiving_date" HeaderText="Received Date" SortExpression="receiving_date" DataFormatString="{0:MMM dd, yyyy}" />
                                        <asp:BoundField DataField="alobs_number" HeaderText="ALOBS No." SortExpression="alobs_number" />
                                        <asp:BoundField DataField="mode_procurement" HeaderText="Procurement" SortExpression="mode_procurement" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" DataFormatString="{0:##,##0.00}" />
                                        <asp:BoundField DataField="selling_amount" HeaderText="Selling Amt." SortExpression="selling_amount" DataFormatString="{0:##,##0.00}" />
                                        <asp:BoundField DataField="supplier_name" HeaderText="Supplier" SortExpression="supplier_name" />
                                        <asp:BoundField DataField="category_desc" HeaderText="Category" SortExpression="category_desc" />
                                        <asp:BoundField DataField="department_desc" HeaderText="Department" SortExpression="department_desc" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hpLnkInfo" data-role="hint" data-hint-background="bg-blue" data-hint="Info.|View Receiving Item Details" data-hint-position="left" NavigateUrl='<%# "~/receiving-details/0/"+Eval("receiving_id") %>'>
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
                                <asp:SqlDataSource ID="SqlDataSourceReceiving" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT trn_receivingHeader.*, ref_supplier.supplier_name, ref_category.category_desc, ref_department.department_desc FROM trn_receivingHeader INNER JOIN ref_supplier ON trn_receivingHeader.supplier_id = ref_supplier.supplier_id INNER JOIN ref_category ON trn_receivingHeader.category_id = ref_category.category_id INNER JOIN ref_department ON trn_receivingHeader.dep_id = ref_department.department_id"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
