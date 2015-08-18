<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Dashboard._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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
            <h1 class="text-light">Virtual machines <span class="mif-drive-eta place-right"></span></h1>
            <hr class="thin bg-grayLighter">

            <button class="button primary" runat="server" onclick="pushMessage('info')"><span class="mif-plus"></span>Create...</button>
            <button class="button success" onclick="pushMessage('success')"><span class="mif-play"></span>Start</button>
            <button class="button warning" onclick="pushMessage('warning')"><span class="mif-loop2"></span>Restart</button>
            <button class="button alert" onclick="pushMessage('alert')">Stop all machines</button>
            <hr class="thin bg-grayLighter">
            <div class="row">
                Search:
            </div>
            <asp:GridView GridLines="None" ID="gvDepartments" class="dataTable border bordered" data-role="datatable" data-auto-width="false"
                runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDepartments" AllowPaging="True"
                AllowSorting="True" DataKeyNames="department_id" PageSize="5" CellPadding="4" ForeColor="#333333">
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
                    <asp:BoundField DataField="department_id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="department_id"></asp:BoundField>
                    <asp:BoundField DataField="department_desc" HeaderText="Description" SortExpression="department_desc"></asp:BoundField>
                    <asp:BoundField DataField="department_type" HeaderText="Type" SortExpression="department_type"></asp:BoundField>
                    <asp:BoundField DataField="department_code" HeaderText="Code" SortExpression="department_code"></asp:BoundField>
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
            <asp:SqlDataSource ID="SqlDataSourceDepartments" runat="server"
                ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT * FROM [ref_department]"></asp:SqlDataSource>

        </div>
    </div>
    <%-- --%>
</asp:Content>
