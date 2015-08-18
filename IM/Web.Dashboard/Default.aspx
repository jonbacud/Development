<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Dashboard._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row" style="height: 100%">
        <div class="cell size-x200" id="cell-sidebar" style=" height: 100%">
           
        </div>
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <div style="width:500px;height:350px; border-color:blue;border-style:solid;" >
                Information Summary<br />
                (0) Pending Requisition<br />
                (0) Expiring Items<br />
                (0) Items for re-order<br />
                
            </div> 
        </div>
    </div>
    <%-- --%>
</asp:Content>
