using Project.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRoles Role { get; set; }

        //Relational Properties
        public virtual List<Order> Orders { get; set; }
        public virtual AppUserProfile Profile { get; set; }
    }
}
