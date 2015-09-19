<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemClassificationPanel.aspx.cs" Inherits="Web.Dashboard.ItemClassificationPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style="background-color: #71b1d1; height: 100%">
            <ul class="sidebar">
                <li class="active"><a href="Default.aspx">
                    <span class="mif-apps icon"></span>
                    <span class="title">Departments</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-vpn-publ icon"></span>
                    <span class="title">websites</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-drive-eta icon"></span>
                    <span class="title">Virtual machines</span>
                    <span class="counter">2</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-cloud icon"></span>
                    <span class="title">Cloud services</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-database icon"></span>
                    <span class="title">SQL Databases</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-cogs icon"></span>
                    <span class="title">Automation</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-apps icon"></span>
                    <span class="title">all items</span>
                    <span class="counter">0</span>
                </a></li>
                <li><a href="#">
                    <span class="mif-apps icon"></span>
                    <span class="title">all items</span>
                    <span class="counter">0</span>
                </a></li>
            </ul>
        </div>
        <div class="cell auto-size padding20 bg-white" id="cell-content">
          <ul class="breadcrumbs2 small">
                <li><a href="#"><span class="icon mif-folder-open"></span>Item Classifications</a></li>
            </ul>
            <h4 class="text-italic">Item Classification Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="/item-classification/1/0" runat="server" ID="hpLnkAddNew">
                <span class="mif-plus"></span> Create...
            </asp:HyperLink>
            <asp:LinkButton ID="lnlBtnReLoad" class="button warning" runat="server"><span class="mif-loop2"></span> Reload</asp:LinkButton>
            <asp:HyperLink class="button alert" NavigateUrl="PrintDepartments.aspx" runat="server" ID="HyperLink2">
                <span class="mif-printer"></span> Print
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
            <div class="row">
                <div class="cell  auto-size size-x500">
                    Filter by Department  
                    <label class="input-control">
                        <asp:DropDownList runat="server" ID="DDLDepartments" AutoPostBack="True"
                            DataSourceID="SqlDataSourceDepartments" DataTextField="department_desc" DataValueField="department_id" />
                    </label>
                    <label class="input-control checkbox">
                        <asp:CheckBox runat="server" ID="chkALL" AutoPostBack="True" OnCheckedChanged="chkALL_CheckedChanged" TextAlign="Left" />
                        <span class="check"></span>
                        <span class="caption">ALL</span>
                    </label>
                </div>
                <asp:SqlDataSource ID="SqlDataSourceDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT [department_id], [department_desc] FROM [ref_department] order by [department_desc]"></asp:SqlDataSource>
            </div>
            <asp:GridView GridLines="None" ID="gvDepartments" class="dataTable border bordered" data-role="datatable" data-auto-width="false"
                runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceItemClassifications" AllowPaging="True"
                AllowSorting="True" DataKeyNames="classifcation_id" PageSize="5" CellPadding="4" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="classifcation_id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="classifcation_id">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="classification_code" HeaderText="Code" SortExpression="classification_code"></asp:BoundField>
                    <asp:BoundField DataField="classification_name" HeaderText="Classification Name" SortExpression="classification_name"></asp:BoundField>
                    <asp:BoundField DataField="department_desc" HeaderText="Department" />
                    <asp:TemplateField>
                        <ItemTemplate>
                                 <asp:HyperLink ID="HyperLink1" runat="server"  data-role="hint" data-hint-background="bg-blue" data-hint="Info.|View Item Classification Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/item-classification/0/"+Eval("classifcation_id")%>'>
                                        <span class="mif-pencil"></span>
                                                </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
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
            <asp:SqlDataSource ID="SqlDataSourceItemClassifications" runat="server"
                ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="select c.classifcation_id,c.classification_code,c.classification_name,c.dep_id,c.uid,d.department_desc from ref_item_classifcation c inner join ref_department d
 on  d.department_id=c.dep_id WHERE (c.[dep_id] = @dep_id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDLDepartments" Name="dep_id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceAll" runat="server"
                ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="select c.classifcation_id,c.classification_code,c.classification_name,c.dep_id,c.uid,d.department_desc from ref_item_classifcation c inner join ref_department d
 on  d.department_id=c.dep_id"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
