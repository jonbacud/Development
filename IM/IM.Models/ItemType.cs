using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_item_type")]
    public class ItemType
    {
        [PrimaryKey,NonUpdatable]
        [MapField("itemtype_id")]
        public int Id { get; set; }

        [MapField("item_type_desc")]
        public string ItemDesciption { get; set; }

        [MapField("item_type_code")]
        public string ItemTypeCode { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }

    }
}
