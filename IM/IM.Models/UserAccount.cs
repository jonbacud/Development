using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_user")]
    public   class UserAccount
    {

        [MapField("userid")]
        public int UserId { get; set; }

        [MapField("username")]
        public string UserName { get; set; }

        [MapField("password")]
        public string Password { get; set; }

        [MapField("position")]
        public string Position { get; set; }

        [MapField("department_id")]
        public int DeaprtmentId { get; set; }

        [MapField("firstname")]
        public string FishName { get; set; }

        [MapField("lastname")]
        public string LastName { get; set; }

        [MapField("")]
        public bool IsActive { get; set; }
    }
}
