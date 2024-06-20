using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public static class DbInitializerSeeds
    {
        public static List<Manager> GetManagers()
        {
            return
            [
                new() {
                    ManagerName = "John Doe",
                    ManagerPhoneNumber = "6135414861"
                },
                new() {
                    ManagerName = "Jane Doe",
                    ManagerPhoneNumber = "3433358253"
                }
            ];
        }
    }
}