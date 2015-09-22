<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationManagementPanel.aspx.cs" Inherits="Web.Dashboard.DonationManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row" style="height: 100%">
        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="/DonationManagementPanel"><span class="icon mif-folder-open"></span>Donations</a></li>
            </ul>
            <h4 class="text-italic">Donation Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="donation/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:GridView GridLines="None" ID="gvDepartments" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDepartments" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="id" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="id"></asp:BoundField>
                                        <asp:BoundField DataField="df_id" HeaderText="Reference No." SortExpression="df_id"></asp:BoundField>
                                        <asp:BoundField DataField="df_date" HeaderText="Donation Date" SortExpression="df_date" DataFormatString="{0:MMM dd, yyyy}"></asp:BoundField>
                                        <asp:BoundField DataField="received_by" HeaderText="Received By" SortExpression="received_by" />
                                        <asp:BoundField DataField="donated_by" HeaderText="Donated By" SortExpression="donated_by" />
                                        <asp:BoundField DataField="donated_to" HeaderText="Donated To" SortExpression="donated_to" />
                                        <asp:BoundField DataField="df_quantity" HeaderText="Quantity" SortExpression="df_quantity" />
                                        <asp:BoundField DataField="df_status" HeaderText="Status" SortExpression="df_status" />
                                        <asp:BoundField DataField="requisition_no" HeaderText="Requisition No." SortExpression="requisition_no" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" data-role="hint" data-hint-background="bg-blue" data-hint="Info.|View Donation Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/donation-detail/0/"+Eval("id")%>'>
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
                                    SelectCommand="SELECT id, df_id, df_date, item_code, received_by, donated_by, donated_to, df_quantity, df_status, requisition_no FROM donation_forms order by id desc"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <%-- --%>
</asp:Content>
