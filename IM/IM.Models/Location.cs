using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("re_location")]
    public class Location
    {
        [PrimaryKey,NonUpdatable]
        [MapField("location_id")]
        public int Id { get; set; }

        [MapField("location_desc")]
        public string Description { get; set; }

        [MapField("location_code")]
        public string Code { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
