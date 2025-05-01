using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        private readonly GameDbContext dbContext;

        public UserContext(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(User item)
        {
            dbContext.Users.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            User userFromDb = Read(key);
            dbContext.Users.Remove(userFromDb);
            dbContext.SaveChanges();
        }

        public User Read(int key)
        {
            User user = dbContext.Users.Find(key);
            if (user == null)
            {
                throw new InvalidOperationException($"User with id {key} does not exist!");
            }
            return user;
        }

        public List<User> ReadAll()
        {
            return dbContext.Users.ToList();
        }

        public void Update(User item)
        {
            dbContext.Users.Update(item);
            dbContext.SaveChanges();
        }
    }
}
