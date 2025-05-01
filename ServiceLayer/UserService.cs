using DataLayer;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
        UserContext userContext;
        public UserService()
        {
            userContext = new UserContext(new GameDbContext());
        }
        public void AddUser(string name, string password)
        {
            if (name.Length > 50)
            {
                throw new ArgumentException("Name must be ");
            }
        }
    }
}
