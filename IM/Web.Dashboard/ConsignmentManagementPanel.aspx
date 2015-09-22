<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsignmentManagementPanel.aspx.cs" Inherits="Web.Dashboard.ConsignmentManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/ConsignmentManagementPanel"><span class="icon mif-folder-open"></span>Consignements</a></li>
            </ul>
            <h4 class="text-italic">Consignment Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="consignment/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:GridView GridLines="None" Font-Size="12px" ID="gvDepartments" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDepartments" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="id" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="id"></asp:BoundField>
                                        <asp:BoundField DataField="co_date" HeaderText="Con. Date" SortExpression="co_date"
                                            DataFormatString="{0:MMM dd, yyyy}"></asp:BoundField>
                                        <asp:BoundField DataField="company_name" HeaderText="Company" SortExpression="company_name"></asp:BoundField>
                                        <asp:BoundField DataField="company_address" HeaderText="Address" SortExpression="company_address" />
                                        <asp:BoundField DataField="deliver_to" HeaderText="Deliver To" SortExpression="deliver_to" />
                                        <asp:BoundField DataField="prepared_by" HeaderText="Prepared By" SortExpression="prepared_by" />
                                        <asp:BoundField DataField="co_quantity" HeaderText="Quantity" SortExpression="co_quantity" />
                                        <asp:BoundField DataField="co_id" HeaderText="Reference No." SortExpression="co_id" />
                                        <asp:BoundField DataField="co_status" HeaderText="Status" SortExpression="co_status" />
                                        <asp:BoundField DataField="days_deliver" HeaderText="Days Deliver" SortExpression="days_deliver" />
                                        <asp:BoundField DataField="requisition_no" HeaderText="Request No." SortExpression="requisition_no" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" data-role="hint" data-hint-background="bg-blue" data-hint="Info.|View Consignment Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/consignment-detail/0/"+Eval("id")%>'>
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
                                    SelectCommand="SELECT consignment_orders.* FROM consignment_orders"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
