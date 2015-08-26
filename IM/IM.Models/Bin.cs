using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_bin")]
    public class Bin
    {
        [PrimaryKey,NonUpdatable]
        [MapField("bin_id")]
        public int Id { get; set; }
        [MapField("bin_code")]
        public string BinCode { get; set; }
        [MapField("bin_desc")]
        public string BinDescription { get; set; }
        [MapField("dep_id")]
        public int DepartmentId { get; set; }
        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
