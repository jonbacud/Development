<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequisitionManagementPanel.aspx.cs" Inherits="Web.Dashboard.RequisitionManagementPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="height: 100%">

        
        <div class="cell auto-size padding20 bg-white" id="cell-content">
            <ul class="breadcrumbs2 no-margin small">
                <li><a href="#"><span class="icon mif-folder-open"></span>Requisitions</a></li>
            </ul>
            <h4 class="text-italic">Requisitions Management <span class="mif-file-text place-right"></span></h4>
            <hr class="thin bg-grayLighter">
            <asp:HyperLink class="button primary" NavigateUrl="requisition/1/0" runat="server" ID="hpLnkAddNew">
                <span class="mif-plus"></span> Create...
            </asp:HyperLink>
            <asp:LinkButton ID="lnlBtnReLoad" class="button warning" runat="server"><span class="mif-loop2"></span> Reload</asp:LinkButton>
            <asp:HyperLink class="button alert" NavigateUrl="PrintItem.aspx" runat="server" ID="HyperLink2">
                <span class="mif-printer"></span> Print
            </asp:HyperLink>
            <hr class="thin bg-grayLighter">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="cell colspan5">
                            <div class="input-control text full-size" data-role="input">
                                <asp:TextBox runat="server" ID="txtSearch" placeholder=" Search..."></asp:TextBox>
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </div>
                    </div>
                    <div class="flex-grid">
                        <div class="row">
                            <div class="cell auto-size">
                                <asp:GridView ID="gvItems" Font-Size="12px" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataSourceID="SqlDataSourceRequisitions" DataKeyNames="ris_id" class="dataTable border bordered"
                                    data-role="datatable"
                                    data-auto-width="false" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="ris_id" HeaderText="ID" SortExpression="ris_id"
                                            InsertVisible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="reference_number" HeaderText="REF. No." SortExpression="reference_number" />
                                        <asp:BoundField DataField="item_name" HeaderText="NAME" SortExpression="item_name" />
                                        <asp:BoundField DataField="barcode" HeaderText="BARCODE" SortExpression="barcode" />
                                        <asp:BoundField DataField="qty_issued" HeaderText="QTTY ISSUED" SortExpression="qty_issued" />
                                        <asp:BoundField DataField="qty_received" HeaderText="QTTY RECEIVED" SortExpression="qty_received" />
                                        <asp:BoundField DataField="submitted_to" HeaderText="SUBMITTED TO" SortExpression="submitted_to" />
                                        <asp:BoundField DataField="unit_desc" HeaderText="UNIT" SortExpression="unit_desc" />
                                        <asp:BoundField DataField="classification_name" HeaderText="CLASSIFICATION"
                                            SortExpression="classification_name" />
                                        <asp:BoundField DataField="status" HeaderText="STATUS" SortExpression="status" />
                                        <asp:BoundField DataField="requisition_date" HeaderText="REQUEST DATE" SortExpression="requisition_date"
                                            DataFormatString="{0:MMM dd, yyyy}" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hpLnkInfo" data-role="hint" data-hint-background="bg-blue"
                                                    data-hint="Info.|View Requisition Details" data-hint-position="left"
                                                    NavigateUrl='<%# "~/requisition/0/"+Eval("ris_id") %>'>
                                                    <span class="mif-pencil"></span>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceRequisitions" runat="server" ConnectionString="<%$ ConnectionStrings:IMConnectionString %>" SelectCommand="SELECT trn_requisition.ris_id, trn_requisition.reference_number, ref_item.item_name, trn_requisition.barcode, trn_requisition.qty_issued, trn_requisition.qty_received, trn_requisition.submitted_to, ref_department.department_desc, ref_unit.unit_desc, ref_item_classifcation.classification_name, trn_requisition.status, trn_requisition.requisition_date FROM trn_requisition INNER JOIN ref_item ON trn_requisition.item_id = ref_item.item_id INNER JOIN ref_unit ON trn_requisition.unit_id = ref_unit.unit_id INNER JOIN ref_department ON trn_requisition.dep_id = ref_department.department_id INNER JOIN ref_item_classifcation ON trn_requisition.item_class_id = ref_item_classifcation.classifcation_id order by trn_requisition.ris_id desc"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
