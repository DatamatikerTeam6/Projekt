using HundeProjekt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HundeProjekt.Data
{
    public class UserContext : IdentityDbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
          : base(options)
        {
        }

    }
   
}
