<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintDepartments.aspx.cs" Inherits="Web.Dashboard.PrintDepartments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Departments</title>
    
    <style type="text/css" media="all">
         #gvDepartments {
             font-family: Verdana;
             font-size: 10px;
        }
         #gvDepartments tr {
             padding: 2px 3px;
         }
        #gvDepartments tr td {
            padding: 2px 3px;
        }
    </style>
    <style type="text/css" media="print">
        
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="cell">
               <label style="font-weight: 800; font-family: Verdana;">
                   Department List
               </label>
            </div>
        </div>
        <hr class="thin bg-grayLighter"/>
    <div>
        <asp:GridView ID="gvDepartments" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="Code" HeaderText="Code" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
