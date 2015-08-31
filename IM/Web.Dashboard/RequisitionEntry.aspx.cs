using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class RequisitionEntry : Page
    {
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly RequisitionManager _requisitionManager = new RequisitionManager();
        private  readonly DepartmentManager _departmentManager = new DepartmentManager();

        public int RequestId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public Requisition Requisition
        {
            get { return _requisitionManager.FetchById(RequestId); }
        }

        public List<RequestItem> RequestItems()
        {
           var items = new List<RequestItem>();
            if (Session["REQUEST_ITEMS"]!=null)
            {
                items = (List<RequestItem>) Session["REQUEST_ITEMS"];
            }
            else
            {
                Session["REQUEST_ITEMS"] = items;
            }
            return items;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //set last reference number
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var departments = _departmentManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
            DDLRequestTo.DataSource = departments;
            DDLRequestTo.DataTextField = "Description";
            DDLRequestTo.DataValueField = "Id";
            DDLRequestTo.DataBind();
            InitDetails();

            switch (Mode)
            {
                case Transaction.TransactionMode.UpdateEntry:
                    if (Requisition != null)
                    {
                        btnDelete.Visible = true;
                        btnSubmitEntry.Text = "UPDATE REQUEST";
                        lnkButtonAdd.Visible = false;
                        gvSelectedItems.Visible = false;
                        txtReferenceNumber.Text = Requisition.ReferenceNumber;
                        txtDateRequested.Text = Requisition.RequisitionDate.ToString("MMM dd, yyyy");
                        DDLProducts.SelectedValue = Requisition.ItemId.ToString();
                        DDLRequestTo.SelectedValue = Requisition.DepartmentId.ToString();
                        DDLUnits.SelectedValue = Requisition.UnitId.ToString();
                        txtQuantityIssue.Text = Requisition.QuantityIssued.ToString();
                        if (Requisition.Status == Transaction.TransactionStatus.Completed.ToString())
                        {
                            btnProcess.Visible = false;
                        }
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnSubmitEntry.Enabled = false;
                        lnkButtonAdd.Enabled = false;
                    }
                    break;
                case Transaction.TransactionMode.NewEntry:
                    txtReferenceNumber.Text = Transaction.TransactionType.RIS
                                    + "-" + (_requisitionManager.ReferenceNumber + 1);
                    txtDateRequested.Text = DateTime.Now.ToString("MMM dd, yyyy");
                    btnProcess.Visible = false;
                    break;
                case Transaction.TransactionMode.ViewDetail:
                    break;
                default:
                    btnDelete.Enabled = false;
                    btnSubmitEntry.Enabled = false;
                    lnkButtonAdd.Enabled = false;
                    break;
            }

            gvSelectedItems.DataSource = RequestItems();
            gvSelectedItems.DataBind();
        }
      
        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDetails();
        }

        private void InitDetails()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) &&
                string.IsNullOrWhiteSpace(DDLDepartments.SelectedValue.Trim())) return;
            InitClassifications();
            InitTypes();
            InitItems();
            InitUnits();
        }

        private void InitItems()
        {
            if (string.IsNullOrEmpty(DDLClassifications.SelectedValue.Trim()) ||
                string.IsNullOrEmpty(DDLTypes.SelectedValue.Trim())) return;
            DDLProducts.DataSource = _itemManager.FetchAll(int.Parse(DDLDepartments.SelectedValue),
                int.Parse(DDLClassifications.SelectedValue)
                , int.Parse(DDLTypes.SelectedValue));
            DDLProducts.DataTextField = "ItemName";
            DDLProducts.DataValueField = "Id";
            DDLProducts.DataBind();
            GetItemDetails(_itemManager);
        }

        private void GetItemDetails(ItemManager itemManager)
        {
            if (!string.IsNullOrEmpty(DDLProducts.SelectedValue))
            {
                var item = itemManager.FetchById(int.Parse(DDLProducts.SelectedValue));
                txtBarCode.Text = item.BarCode;
                txtItemCode.Text = item.ItemCode;
                hpLinkItemDetails.NavigateUrl = "~/item/2/"+item.Id;
                //stocks view
               // hpLinkViewStocks.NavigateUrl = "receiving-details/0/1";
            }
            else
            {
                txtBarCode.Text = string.Empty;
                txtItemCode.Text = string.Empty;
            }
        }

        private void InitTypes()
        {
            ItemTypeManager itemTypeManager = new ItemTypeManager();
            DDLTypes.DataSource = itemTypeManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLTypes.DataTextField = "ItemDesciption";
            DDLTypes.DataValueField = "Id";
            DDLTypes.DataBind();
        }

        private void InitClassifications()
        {
            ItemClassificationManager itemClassificationManager = new ItemClassificationManager();
            DDLClassifications.DataSource =
                itemClassificationManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLClassifications.DataTextField = "ClassificationName";
            DDLClassifications.DataValueField = "Id";
            DDLClassifications.DataBind();
        }


        private void InitUnits()
        {
            UnitManager uManager = new UnitManager();
            DDLUnits.DataSource = uManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataBind();
        }

        protected void DDLClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }

        protected void DDLTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }

        protected void DDLProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemDetails(_itemManager);

        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            
            var items = RequestItems();
            var item = new RequestItem
            {
                ItemId = int.Parse(DDLProducts.SelectedValue),
                Barcode = txtBarCode.Text.Trim(),
                ClassificationName = DDLClassifications.SelectedItem.Text,
                ClassificationId = int.Parse(DDLClassifications.SelectedValue),
                DepartmentId = int.Parse(DDLRequestTo.SelectedValue),
                DepartmentName = DDLDepartments.SelectedItem.Text,
                ItemCode = txtItemCode.Text,
                ItemName = DDLProducts.SelectedItem.Text,
                ReferenceNumber = txtReferenceNumber.Text.Trim(),
                TypeId = int.Parse(DDLTypes.SelectedValue),
                TypeName = DDLTypes.SelectedItem.Text,
                UnitId = int.Parse(DDLUnits.SelectedValue),
                UnitName = DDLUnits.SelectedItem.Text,
                RequestDate = DateTime.Parse(txtDateRequested.Text),
                Uid = Guid.NewGuid()
            };
            items.Add(item);
            gvSelectedItems.DataSource = items;
            gvSelectedItems.DataBind();
        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var list = RequestItems();
            var row = gvSelectedItems.Rows[e.RowIndex];
            var hfId = (HiddenField)row.FindControl("hfUniqueId");
            var uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.Uid == uid);
            gvSelectedItems.DataSource = RequestItems();
            gvSelectedItems.DataBind();
        }

        protected void btnSubmitEntry_Click(object sender, EventArgs e)
        {
            if (Mode==Transaction.TransactionMode.UpdateEntry)
            {
                var request = new Requisition
                {
                    ItemId = int.Parse(DDLProducts.SelectedValue),
                    BarCode = txtBarCode.Text.Trim(),
                    ItemClassificationId = int.Parse(DDLClassifications.SelectedValue),
                    DepartmentId = int.Parse(DDLRequestTo.SelectedValue),
                    DateCreated = DateTime.Now,
                    ReferenceNumber = Requisition.ReferenceNumber,
                    UniqueId = Guid.NewGuid(),
                    Id = RequestId,
                    QuantityIssued = int.Parse(txtQuantityIssue.Text),
                    QuantityReceived = 0,
                    RequisitionDate = DateTime.Parse(txtDateRequested.Text),
                    Status = Transaction.TransactionStatus.Submitted.ToString(),
                    SubmittedTo = DDLRequestTo.SelectedItem.Text,
                    UnitId = int.Parse(DDLUnits.SelectedValue)
                };
                _requisitionManager.Save(request);
                divMessageBox.Attributes.Add("class", "notify success");
                divMessageBox.Visible = true;
                ltrlMessage.Text = "Requisition entry has been updated!";
            }
            else
            {
                var requests = new List<Requisition>();
                if (RequestItems().Count <= 0) return;
                requests.AddRange(RequestItems().Select(ri => new Requisition
                {
                    UnitId = ri.UnitId,
                    BarCode = ri.Barcode,
                    DateCreated = DateTime.Now,
                    DepartmentId = ri.DepartmentId,
                    ItemClassificationId = ri.ClassificationId,
                    ItemId = ri.ItemId,
                    QuantityIssued = int.Parse(txtQuantityIssue.Text),
                    SubmittedTo = DDLRequestTo.SelectedItem.Text,
                    ReferenceNumber = txtReferenceNumber.Text.Trim(),
                    RequisitionDate = DateTime.Parse(txtDateRequested.Text),
                    Status = Transaction.TransactionStatus.Submitted.ToString(),
                    UniqueId = Guid.NewGuid(),
                    QuantityReceived = 0,
                }));
                _requisitionManager.Save(requests);
                divMessageBox.Attributes.Add("class", "notify success");
                divMessageBox.Visible = true;
                ltrlMessage.Text = "New Requisition/s entry has been saved!";
            }
            btnSubmitEntry.Enabled = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var requestToDelete = new Requisition
            {
                Id = RequestId
            };
            _requisitionManager.Delete(requestToDelete);
            divMessageBox.Attributes.Add("class", "notify warning");
            divMessageBox.Visible = true;
            btnDelete.Visible = false;
            btnSubmitEntry.Visible = false;
            lnkButtonAdd.Visible = false;
            btnProcess.Visible = false;
            lnkButtonAdd.Visible = false;
            ltrlMessage.Text = "Requisition entry has been deleted!";
        }

        protected void btnProcessRequest_Click(object sender, EventArgs e)
        {
            var requestProcess = Requisition;
            if (int.Parse(txtQuantityReceived.Text) <= 0) return;
            requestProcess.QuantityReceived = int.Parse(txtQuantityReceived.Text);
            requestProcess.Status = requestProcess.QuantityIssued == requestProcess.QuantityReceived
                ? Transaction.TransactionStatus.Completed.ToString()
                : Transaction.TransactionStatus.Partial.ToString();
            _requisitionManager.Save(requestProcess);
            divMessageBox.Attributes.Add("class", "notify success");
            divMessageBox.Visible = true;
            ltrlMessage.Text = "Requisition entry has been Processed!";
        }
    }
}