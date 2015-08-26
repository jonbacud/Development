using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_category")]
    public class Category
    {
        [PrimaryKey,NonUpdatable]
        [MapField("category_id")]
        public int Id { get; set; }

        [MapField("category_code")]
        public string Code { get; set; }

        [MapField("category_desc")]
        public string Description { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
