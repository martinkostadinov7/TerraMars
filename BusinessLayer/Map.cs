using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Map
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile[,] Tiles { get; set; }
        public List<Structure> Structures { get; set; }
        private Map()
        {
            Tiles = new Tile[10,10];
            Structures = new List<Structure>();
        }

        public Map(User owner, int width, int height)
        {
            Owner = owner;
            Width = width;
            Height = height; 
            Tiles = new Tile[width, height];
            Structures = new List<Structure>();
        }
    }
}
