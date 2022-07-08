using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDProject.Models;

namespace TDDProjectTest.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
        
             new() {
                new User
                    {
                        Id = 1,
                        Name = "Jane",
                        Address = new Address()
                        {
                            Street = "Some street 7",
                            City = "Sim city",
                            Zip = "12345"
                        },
                        Email = "mail@mail.com"
                    },
                new User
                    {
                        Id = 2,
                        Name = "Jane",
                        Address = new Address()
                        {
                            Street = "Other street 7",
                            City = "Duckburg",
                            Zip = "54321"
                        },
                        Email = "mail@example.com"
                    }
            };
    }
}
