using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Map> Maps { get; set; }
        private User()
        {
            Maps = new List<Map>();
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Maps = new List<Map>();
        }
    }
}
