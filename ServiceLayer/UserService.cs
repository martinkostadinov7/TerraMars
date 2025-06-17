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
            userContext = new UserContext(DbContextHelper.GetDbContext());
        }
        public UserService(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public void AddUser(string username, string password)
        {
            if(userContext.ReadAll().FirstOrDefault(x => x.Username == username) != null)
            {
                throw new Exception("User is already used!");
            }
            ValidateUserData(username, password);
            userContext.Create(new User(username, password));
        }

        private static void ValidateUserData(string username, string password)
        {
            if (username.Length > 50)
            {
                throw new Exception("Maximum Username length is 50!");
            }
            if (password.Length > 16)
            {
                throw new Exception("Maximum Password length is 16!");
            }
            if (password.Length < 3)
            {
                throw new Exception("Minimum Password length is 3!");
            }
            if (username.Length < 3)
            {
                throw new Exception("Minimum Username length is 3!");
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Invalid Username!");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Invalid Password!");
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
        public User GetUser(string username, string password)
        {
            return userContext.ReadAll().FirstOrDefault(x => x.Username == username && x.Password == password);
        } 
    }
}
