<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssuanceManagementPanel.aspx.cs" Inherits="Web.Dashboard.IssuanceManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li><a href="DepartmentManagementPanel.aspx">
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
                <li class="active"><a href="#">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="Items/Default.aspx">
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
                <li><a href="#"><span class="icon mif-folder-open"></span>Item Issuance</a></li>
            </ul>
            <h4 class="text-italic">Item Issuance Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="issuance/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:GridView GridLines="None" Font-Size="12px" ID="gvCategories"
                                    class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceIssuance" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="issuance_id" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="issuance_id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="issuance_id">
                                            <ItemStyle CssClass="text-bold" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="reference_number" HeaderText="Ref. Number" SortExpression="reference_number">
                                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="issuance_date" HeaderText="Date Issued"
                                            SortExpression="issuance_date" DataFormatString="{0:MMM dd, yyyy}"></asp:BoundField>
                                        <asp:BoundField DataField="issued_to" HeaderText="Issued To" SortExpression="issued_to"></asp:BoundField>
                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount"
                                            SortExpression="total_amount" DataFormatString="{0:##,##0.00}">
                                            <ItemStyle HorizontalAlign="Right" CssClass="text-bold fg-darkRed" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ris_reference_number"
                                            HeaderText="Request Ref. No." SortExpression="ris_reference_number">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="isPosted">
                                            <ItemTemplate>
                                                <span data-hint-color="fg-white" data-role="hint" data-hint-background="bg-lightBlue"
                                                    data-hint='<%# bool.Parse(Eval("isPosted").ToString()) ? "Posted" : "Not Posted" %>'
                                                    data-hint-position="top" class='<%# bool.Parse(Eval("isPosted").ToString()) 
                                                ? "mif-checkmark fg-green" : "mif-stop fg-red" %>'></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="datecreated" HeaderText="Date Created" SortExpression="datecreated">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" data-hint-color="fg-white" runat="server" data-role="hint"
                                                    data-hint-background="bg-blue" data-hint="Info.|View Issuance Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/issuance-details/"+Eval("issuance_id")%>'>
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
                                <asp:SqlDataSource ID="SqlDataSourceIssuance" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT trn_issuance_header.* FROM trn_issuance_header order by trn_issuance_header.issuance_id desc"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
