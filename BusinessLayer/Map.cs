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
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [Required]
        public User Owner { get; set; }

        [Range(1, 100)]
        public int Width { get; set; }

        [Range(1, 100)]
        public int Height { get; set; }
        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public List<Structure> Structures { get; set; } = new List<Structure>();
        private Map()
        {
        }

        public Map(User owner, int width, int height)
        {
            Owner = owner;
            Width = width;
            Height = height; 
        }
    }
}
