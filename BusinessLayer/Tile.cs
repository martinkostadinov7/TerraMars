using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public TileType Type { get; set; }

        public Map Map { get; set; }
        public int MapId { get; set; }

        private Tile()
        {
            
        }

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
