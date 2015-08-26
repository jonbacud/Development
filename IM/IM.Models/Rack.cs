using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_rack")]
    public class Rack
    {
        [PrimaryKey,NonUpdatable]
        [MapField("rack_id")]
        public int Id { get; set; }

        [MapField("rack_desc")]
        public string Description { get; set; }

        [MapField("rack_code")]
        public string Code { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
