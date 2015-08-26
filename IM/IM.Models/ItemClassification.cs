using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_item_classifcation")]
    public class ItemClassification
    {
        [PrimaryKey,NonUpdatable]
        [MapField("classifcation_id")]
        public int Id { get; set; }

        [MapField("classification_code")]
        public string Code { get; set; }

        [MapField("classification_name")]
        public string ClassificationName { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }

    }
}
