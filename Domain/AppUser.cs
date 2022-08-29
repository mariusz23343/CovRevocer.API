using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public AccountType AccountType { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public enum AccountType
    {
        Patient,
        Rehabilitator
    }
}
