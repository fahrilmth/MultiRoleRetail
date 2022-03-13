using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiRoleRetail.Models;


namespace MultiRoleRetail
{
    public static class UserHelper
    {
        public static User? UserID { get; set; } = null;
        public static User? UserName { get; set; } = null;
        public static User? UserEmail { get; set; } = null;
        public static User? UserPhone { get; set; } = null;
        public static User? UserRole { get; set; } = null;
    }
}
