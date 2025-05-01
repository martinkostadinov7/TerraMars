using DataLayer;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace ServiceLayer
{
    public class UserService
    {
        UserContext userContext;
        public UserService()
        {
            userContext = new UserContext(new GameDbContext());
        }
        public void AddUser(string username, string password)
        {
            ValidateUserData(username, password);
            userContext.Create(new User(username, password));
        }

        private static void ValidateUserData(string username, string password)
        {
            if (username.Length > 50)
            {
                throw new ArgumentException("Maximum Username length is 50!");
            }
            if (password.Length > 16)
            {
                throw new ArgumentException("Maximum Password length is 16!");
            }
            if (password.Length < 8)
            {
                throw new ArgumentException("Minimum Password length is 8!");
            }
            if (username.Length < 3)
            {
                throw new ArgumentException("Minimum Username length is 3!");
            }
            if (!string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid Username!");
            }
            if (!string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Invalid Password!");
            }
        }

        public void UpdateUser(int id, string username, string password)
        {
            User userFromDb = userContext.Read(id);
            ValidateUserData(username, password);
            userFromDb.Username = username;
            userFromDb.Password = password;
            userContext.Update(userFromDb);
        }
        public void DeleteUser(int id)
        {
            User userFromDb = userContext.Read(id);
            userContext.Delete(userFromDb.Id);
        }
    }
}
