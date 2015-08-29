using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class ItemIssuanceEntry : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var departments = _dManager.FetchAll();
                DDLDepartments.DataSource = departments;
                DDLDepartments.DataTextField = "Description";
                DDLDepartments.DataValueField = "Id";
                DDLDepartments.DataBind();

                InitialiazeIssuanceEntry("23232");

                txtIssuanceDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
            }
        }

        private void InitialiazeIssuanceEntry(string requestReferenceNumber)
        {
            RequisitionManager rManager = new RequisitionManager();
            ItemManager itemManager = new ItemManager();
            var items = rManager.FetchAll()
                .Where(r => r.ReferenceNumber.Equals(requestReferenceNumber) && !r.Status.Equals("Issued"));

            decimal totalAmount =
                (from p in items let item = itemManager.FetchById(p.ItemId) select item.LastSellingPrice*p.QuantityIssued).Sum();
            txtTotalAmount.Text = totalAmount.ToString("##0.00");

            ItemClassificationManager classificationManager = new ItemClassificationManager();
            ItemTypeManager itManager = new ItemTypeManager();
            UnitManager uManager = new UnitManager();
            List<RequestItem> requesItems = (from ri in items
                let classification = classificationManager.FetchById(ri.ItemClassificationId)
                let department = _dManager.FetchById(ri.DepartmentId)
                let item = itemManager.FetchById(ri.ItemId)
                let type = itManager.FetchById(item.TypeId)
                let unit = uManager.FetchById(ri.UnitId)
                select new RequestItem
                {
                    Barcode = ri.BarCode,
                    CalssificationName = classification.ClassificationName,
                    ClassificationId = classification.Id,
                    DepartmentId = department.Id,
                    DepartmentName = department.Description,
                    ItemCode = item.ItemCode,
                    ItemId = item.Id,
                    ItemName = item.ItemName,
                    ReferenceNumber = ri.ReferenceNumber,
                    RequestDate = ri.RequisitionDate,
                    RequestTo = ri.DepartmentId,
                    TypeId = type.Id,
                    TypeName = type.ItemDesciption,
                    UnitName = unit.Description,
                    UnitId = unit.Id,
                    Uid = ri.UniqueId,
                    Quantity = ri.QuantityIssued,
                    RequesitionId = item.Id,
                    ItemPrice = item.LastSellingPrice
                }).ToList();

            Session["REQUEST_ITEMS"] = requesItems;
            gvSelectedItems.DataSource = requesItems;
            gvSelectedItems.DataBind();
        }

        protected void btnSubmitIssuance_Click(object sender, EventArgs e)
        {
           IssuanceManager issuanceManager = new IssuanceManager();
           IssuanceDetailManager idManager = new IssuanceDetailManager();

            Issuance issuance = new Issuance
            {
                DateCreated = DateTime.Now,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                IsPosted = false,
                IssuanceDate = DateTime.Parse(txtIssuanceDate.Text),
                IssuedTo = DDLDepartments.SelectedItem.Text,
                ReferenceNumber = txtReferenceNumber.Text.Trim(),
                RequisitionId = 0,
                TotalAmount = decimal.Parse(txtTotalAmount.Text),
                Unid = Guid.NewGuid()
            };
            issuanceManager.Save(issuance);
            int Identity = issuanceManager.Identity;

            List<RequestItem> requestItems = (List<RequestItem>) Session["REQUEST_ITEMS"];

            List<IssuanceDetail> issuanceDetails = requestItems.Select(requestItem => new IssuanceDetail
            {
                UnitId = requestItem.UnitId, Uid = Guid.NewGuid(), Quantity = requestItem.Quantity, Barcode = requestItem.Barcode, IsPosted = false, IssuanceId = Identity, ItemId = requestItem.ItemId, Price = requestItem.ItemPrice,
            }).ToList();

            idManager.Save(issuanceDetails);
        }
    }
}