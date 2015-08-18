<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Dashboard.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="bin_id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="bin_id" HeaderText="bin_id" ReadOnly="True" SortExpression="bin_id" />
            <asp:BoundField DataField="bin_desc" HeaderText="bin_desc" SortExpression="bin_desc" />
            <asp:BoundField DataField="bin_code" HeaderText="bin_code" SortExpression="bin_code" />
            <asp:BoundField DataField="dep_id" HeaderText="dep_id" SortExpression="dep_id" />
            <asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventorWRIConnectionString1 %>" DeleteCommand="DELETE FROM [ref_bin] WHERE [bin_id] = @bin_id" InsertCommand="INSERT INTO [ref_bin] ([bin_desc], [bin_code], [dep_id], [uid]) VALUES (@bin_desc, @bin_code, @dep_id, @uid)" ProviderName="<%$ ConnectionStrings:InventorWRIConnectionString1.ProviderName %>" SelectCommand="SELECT [bin_id], [bin_desc], [bin_code], [dep_id], [uid] FROM [ref_bin]" UpdateCommand="UPDATE [ref_bin] SET [bin_desc] = @bin_desc, [bin_code] = @bin_code, [dep_id] = @dep_id, [uid] = @uid WHERE [bin_id] = @bin_id">
        <DeleteParameters>
            <asp:Parameter Name="bin_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="bin_desc" Type="String" />
            <asp:Parameter Name="bin_code" Type="String" />
            <asp:Parameter Name="dep_id" Type="Int32" />
            <asp:Parameter Name="uid" Type="Object" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="bin_desc" Type="String" />
            <asp:Parameter Name="bin_code" Type="String" />
            <asp:Parameter Name="dep_id" Type="Int32" />
            <asp:Parameter Name="uid" Type="Object" />
            <asp:Parameter Name="bin_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>425.555.0100</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>425.555.0199</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:Support@example.com">Support@example.com</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:Marketing@example.com">Marketing@example.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:General@example.com">General@example.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            One Microsoft Way<br />
            Redmond, WA 98052-6399
        </p>
    </section>
</asp:Content>