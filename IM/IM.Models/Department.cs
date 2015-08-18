using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Common;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_department")]
    public class Department : EntityBase
    {
        [PrimaryKey,NonUpdatable]
        [MapField("department_id")]
        public int  Id { get; set; }

        [MapField("department_desc")]
        public string Description { get; set; }

        [MapField("department_type")]
        public string Type { get; set; }

        [MapField("department_code")]
        public string Code { get; set; }

        [MapField("uid")]
        public Guid UId { get; set; }

    }
}
