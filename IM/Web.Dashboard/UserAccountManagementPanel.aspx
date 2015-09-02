<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAccountManagementPanel.aspx.cs" Inherits="Web.Dashboard.UserAccountManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar" style="height: 100%;">
                <li class="active"><a href="DepartmentManagementPanel.aspx">
                    <span class="mif-users icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="/RequisitionManagementPanel">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Requisitions</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="/IssuanceManagementPanel">
                    <span class="mif-folder-minus icon"></span>
                    <span class="title">Items Issuance</span>
                    <span class="counter">2</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-folder-download icon"></span>
                    <span class="title">Receiving Items</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="/ItemManagementPanel">
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
                <li><a href="#"><span class="icon mif-folder-open"></span>User Accounts</a></li>
            </ul>
            <h4 class="text-italic">User Accounts Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="user/1/0" runat="server" ID="hpLnkAddNew">
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
                                <asp:TextBox runat="server" ID="txtSearch" placeholder="Search..." AutoPostBack="True"
                                    OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </div>
                    </div>
                    <div class="flex-grid">
                        <div class="row">
                            <div class="cell auto-size">
                                <asp:GridView GridLines="None" ID="gvCategories" class="dataTable border bordered" data-role="datatable"
                                    data-auto-width="false"
                                    runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceUserAccounts" AllowPaging="True"
                                    AllowSorting="True" DataKeyNames="userid" PageSize="5" CellPadding="4" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="userid" HeaderText="Id" InsertVisible="False"
                                            ReadOnly="True" SortExpression="userid">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="username" HeaderText="User Name" SortExpression="username">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="position" HeaderText="Position" SortExpression="position"></asp:BoundField>
                                        <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname"></asp:BoundField>
                                        <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
                                        <asp:TemplateField HeaderText="Active" SortExpression="isActive">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("isActive") %>' />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                  <span data-hint-color="fg-white" data-role="hint" data-hint-background="bg-lightBlue"
                                                    data-hint='<%# bool.Parse(Eval("isActive").ToString()) ? "Active" : "In Active" %>'
                                                    data-hint-position="top" class='<%# bool.Parse(Eval("isActive").ToString()) 
                                                ? "mif-checkmark fg-green" : "mif-stop fg-red" %>'></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="department_desc" HeaderText="Department" SortExpression="department_desc" />
                                          <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                               <asp:HyperLink data-hint-color="fg-white" data-role="hint"  data-hint-background="bg-blue" data-hint="Info.|View User Account Details" data-hint-position="left"  runat="server" ID="hpLinlUpdate" 
                                                   NavigateUrl='<%#"~/user/0/"+Eval("userid") %>'>
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
                                <asp:SqlDataSource ID="SqlDataSourceUserAccounts" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT ref_user.userid, ref_user.username, ref_user.position, ref_user.firstname, ref_user.lastname, ref_user.isActive, ref_department.department_desc FROM ref_user INNER JOIN ref_department ON ref_user.department_id = ref_department.department_id"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSourceCategories" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT ref_category.category_id,ref_category.category_code,ref_category.category_desc,ref_department.department_desc FROM [ref_category] inner join ref_department on ref_category.dep_id = ref_department.department_id order by category_id desc "></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
