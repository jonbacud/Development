using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class ReceivingEntry : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly SupplierManager _supplierManager = new SupplierManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly LocationManager _locationManager = new LocationManager();
        private readonly RackManager _rackManager = new RackManager();
        private readonly BinManager _binManager = new BinManager();
        private readonly ShelveManager _shelveManager = new ShelveManager();

        public List<ReceivingItem> ReceivedItems()
        {
            var items = new List<ReceivingItem>();
            if (Session["RECEIVING_ITEMS"] != null)
            {
                items = (List<ReceivingItem>)Session["RECEIVING_ITEMS"];
            }
            else
            {
                Session["RECEIVING_ITEMS"] = items;
            }
            return items;
        } 


        protected void Page_Init(object sender, EventArgs e)
        {
            var departments = _dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();

            InitSuppliers(int.Parse(DDLDepartments.SelectedValue));
            InitItems();
            InitLocations();
            InitRacks();
            InitBins();
            InitShelves();
        }

        private void InitSuppliers(int departmentId)
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
             string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLSuppliers.DataSource = _supplierManager.FetchAll(departmentId).OrderBy(s=>s.Name);
            DDLSuppliers.DataTextField = "Name";
            DDLSuppliers.DataValueField = "Id";
            DDLSuppliers.DataBind();
        }

        private void InitItems()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLItems.DataSource = _itemManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataValueField = "Id";
            DDLItems.DataBind();
        }

        private void InitLocations()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLLocations.DataSource = _locationManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLLocations.DataTextField = "Description";
            DDLLocations.DataValueField = "Id";
            DDLLocations.DataBind();
        }

        private void InitRacks()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLRacks.DataSource = _rackManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLRacks.DataTextField = "Description";
            DDLRacks.DataValueField = "Id";
            DDLRacks.DataBind();
        }

        private void InitBins()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLBins.DataSource = _binManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLBins.DataTextField = "BinDescription";
            DDLBins.DataValueField = "Id";
            DDLBins.DataBind();
        }

        private void InitShelves()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLShelves.DataSource = _shelveManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLShelves.DataTextField = "Description";
            DDLShelves.DataValueField = "Id";
            DDLShelves.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSelectedItems.DataSource = ReceivedItems();
                gvSelectedItems.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {

        }

        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSuppliers(int.Parse(DDLDepartments.SelectedValue));
            InitItems();
            InitLocations();
            InitRacks();
            InitBins();
            InitShelves();
        }
    }
}