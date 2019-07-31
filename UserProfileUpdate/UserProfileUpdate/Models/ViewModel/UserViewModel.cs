using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProfileUpdate.Models.ViewModel
{
    public class UserViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email_Id { get; set; }
        public int userGroupId { get; set; }
    }
}
