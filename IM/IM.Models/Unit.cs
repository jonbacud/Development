using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_unit")]
    public class Unit
    {
        [PrimaryKey,NonUpdatable]
        [MapField("unit_id")]
        public int Id { get; set; }

        [MapField("unit_code")]
        public string Code { get; set; }

        [MapField("unit_desc")]
        public string Description { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }

    }
}
