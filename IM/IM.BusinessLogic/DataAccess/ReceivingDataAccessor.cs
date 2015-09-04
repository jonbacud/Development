using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class ReceivingDataAccessor : AccessorBase<ReceivingDataAccessor.DB, ReceivingDataAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        public virtual void ReceivingReport(string datefrom, string dateto, int itemclassid, string itemdesc, int supplierid, string suppliercode,string barcode,  SqlDataSource datasource)
        {
            string mssQL;
            string swhere = "";
            string mstr;
            mssQL = "SELECT a.receiving_date, a.reference_no,a.po_number,a.invoice_no,i.supplier_name,b.barcode,c.item_name,k.category_desc,a.alobs_number,"
                 + " l.fullname,a.mode_procurement,b.expirydate,b.recvdQTY,d.unit_desc,b.price,b.Total_amount,e.location_desc,f.rack_desc,h.shelve_desc,"
                 + " g.bin_desc,a.status,b.remarks FROM trn_receivingHeader a INNER JOIN trn_receiving_detail b ON a.receiving_id = b.receiving_id"
                 + " INNER JOIN ref_item c ON b.item_id = c.item_id INNER JOIN ref_unit d ON b.unit_id = d.unit_id"
                 + " INNER JOIN ref_location e ON e.location_id = b.location_id INNER JOIN ref_rack f ON f.rack_id = b.rack_id"
                 + " INNER JOIN ref_bin g ON g.bin_id = b.bin_id INNER JOIN ref_shelve h ON h.shelve_id = b.shelve_id"
                 + " INNER JOIN ref_supplier i ON i.supplier_id = b.supplier_id INNER JOIN ref_department j ON j.department_id = b.dep_id"
                 + " INNER JOIN ref_category k ON k.category_id = a.category_id INNER JOIN ref_enduser l ON l.enduser_id = a.enduserid WHERE 1 = 1";

            if (datefrom != "")
            {
                if (dateto != "")
                {
                    swhere = swhere + " AND a.receiving_date BETWEEN '"+ datefrom +"' AND '"+ dateto +"'";
                }
            }

            if (itemclassid > 0)
            {
                swhere = swhere + " AND k.category_id = '"+ itemclassid +"'";
            }

            if (itemdesc != "")
            {
                swhere = swhere + " AND c.item_name LIKE '%" + itemdesc + "%'";
            }

            if (supplierid > 0)
            {
                swhere = swhere + " AND i.supplier_id = '" + supplierid + "'";
            }

            if (suppliercode != "")
            {
                swhere = swhere + " AND i.supplier_code = '" + suppliercode + "'";
            }

            if (barcode != "")
            {
                swhere = swhere + " AND b.barcode = '" + barcode + "'";
            }

            mstr = mssQL + swhere + " ORDER BY a.receiving_date ASC";

            var strCmd = new StringBuilder(mstr);
            datasource.SelectCommand = strCmd.ToString();
            datasource.DataBind();
        }        
    }
}
