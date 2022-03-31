using System;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Contracts.User.Enums;

namespace OnlineShop.User.Persistence.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
