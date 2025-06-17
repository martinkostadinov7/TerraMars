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
    public enum Level
    {
        Ground,
        Underground,
    }
    public class Tile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsPlacable { get; set; }

        [Range(0, 70)]
        public int X { get; set; }

        [Range(0, 40)]
        public int Y { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public TileType Type { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public bool IsVisible { get; set; }
        [Required]
        public int MapId { get; set; }

        [ForeignKey(nameof(MapId))]
        public Map Map { get; set; }

        private Tile() { }

        public Tile(int x, int y, Color color, TileType type,Level level, bool isVisible, Map map, bool isPlacable)
        {
            X = x;
            Y = y;
            Color = color;
            Type = type;
            Level = level;
            IsVisible = isVisible;
            Map = map;
            MapId = map.Id;
            IsPlacable = isPlacable;
        }
    }
}
