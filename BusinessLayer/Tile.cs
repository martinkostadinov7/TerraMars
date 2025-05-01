using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public enum TileType
    {
        MarsSurface,
        Soil,
        Stone,
        Water,
        UndergroundWater,
        Ice
    }
    public class Tile
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 99)]
        public int X { get; set; }

        [Range(0, 99)]
        public int Y { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public TileType Type { get; set; }

        [Required]
        public int MapId { get; set; }

        [ForeignKey(nameof(MapId))]
        public Map Map { get; set; }

        private Tile() { }

        public Tile(int x, int y, Color color, TileType type, Map map)
        {
            X = x;
            Y = y;
            Color = color;
            Type = type;
            Map = map;
            MapId = map.Id;
        }
    }
}
