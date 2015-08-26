using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_shelve")]
    public class Shelve
    {
        [PrimaryKey,NonUpdatable]
        [MapField("shelve_id")]
        public int Id { get; set; }

        [MapField("shelve_desc")]
        public string Description { get; set; }

        [MapField("shelve_code")]
        public string Code { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
