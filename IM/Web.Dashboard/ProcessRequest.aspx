<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProcessRequest.aspx.cs" Inherits="Web.Dashboard.ProcessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script>
         function showDialog(id) {
             var dialog = $("#" + id).data('dialog');
             if (!dialog.element.data('opened')) {
                 dialog.open();
             } else {
                 dialog.close();
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <button class="button" onclick="showDialog('dialog9')">Overlay 2</button>

         
        </ContentTemplate>
    </asp:UpdatePanel>
      <div data-role="dialog" id="dialog9" class="padding20" data-close-button="true" data-overlay="true" data-overlay-color="op-dark">
            <h1>Simple dialog</h1>
            <p>
                This dialog with colored overlay
            </p>
        </div>
</asp:Content>
