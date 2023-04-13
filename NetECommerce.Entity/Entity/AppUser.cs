using Microsoft.AspNetCore.Identity;
using System;

namespace NetECommerce.Entity.Entity
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
    }
}
