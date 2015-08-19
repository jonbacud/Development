using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("tmp_barcode")]
    public class Barcode
    {
        [PrimaryKey,NonUpdatable]
        [MapField("barcode_id")]
        public int Id { get; set; }

        [MapField("Barcode")]
        public string Code { get; set; }
    }
}
