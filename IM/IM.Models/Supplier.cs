using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_supplier")]
    public class Supplier
    {
        [PrimaryKey,NonUpdatable]
        [MapField("supplier_id")]
        public int Id { get; set; }

        [MapField("supplier_code")]
        public string Code { get; set; }

        [MapField("supplier_name")]
        public string Name { get; set; }

        [MapField("address")]
        public string Address { get; set; }

        [MapField("contact_person")]
        public string ContactPerson { get; set; }

        [MapField("telNo")]
        public string TelephoneNumber { get; set; }

        [MapField("faxNumber")]
        public string FaxNumber { get; set; }

        [MapField("emailaddress")]
        public string EmailAddress { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("isConsignment")]
        public bool IsConsignment { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
