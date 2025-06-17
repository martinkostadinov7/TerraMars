using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [Required]
        public User Owner { get; set; }

        [Required]
        public int StoneGathered { get; set; }

        [Range(30, 70)]
        public int Width { get; set; }

        [Range(30, 40)]
        public int Height { get; set; }

        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public List<Structure> Structures { get; set; } = new List<Structure>();
        private Map()
        {
        }

        public Map(string name, User owner, int width, int height, int stoneCount)
        {
            Name = name;
            Owner = owner;
            Width = width;
            Height = height;
            CreatedAt = DateTime.Now;
            LastModified = DateTime.Now;
            StoneGathered = stoneCount;
        }
    }
}
