using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.SeedData
{
    public class RolesSeed
    {
        public static List<Role> Get()
        {
            List<Role> roles = new List<Role>();

            var user = new Role()
            {
                Id = 1,
                Name = "User"

            };
            roles.Add(user);

            var manager = new Role()
            {
                Id = 2,
                Name = "Manager"
            };
            roles.Add(manager);

            var admin = new Role()
            {
                Id = 3,
                Name = "Admin"
            };
            roles.Add(admin);

            return roles;
        }
    }
}
