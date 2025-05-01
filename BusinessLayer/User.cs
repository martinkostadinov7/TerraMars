using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(3,50)]
        public string Username { get; set; }

        [Required]
        [Range(8, 16)]
        public string Password { get; set; }

        public List<Map> Maps { get; set; } = new List<Map>();

        private User()
        {
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
