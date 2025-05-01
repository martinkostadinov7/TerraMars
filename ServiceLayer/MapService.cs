using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
namespace ServiceLayer
{
    public class MapService
    {
        Random rnd = new Random();
        Map Map { get; set; }

        MapContext context;
        public MapService() 
        {
            context = new MapContext(new GameDbContext());
        }
        public Map GenerateMap(int x, int y)
        {
            Color[] marsColors = new Color[]
            {
                Color.OrangeRed,
                Color.SandyBrown,
                Color.LightSalmon,
                Color.DarkSalmon,
            };
            Map = new Map(new User("test", "123"), x, y);
            for (int i = 0; i < Map.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Map.Tiles.GetLength(1); j++)
                {
                    Map.Tiles[i, j] = new Tile(i, j, marsColors[rnd.Next(0, marsColors.Length)], TileType.MarsSurface, Map);
                }
            }
            int stoneCount = rnd.Next(3, (x + y)/ 2);
            Color[] stoneColors = new Color[]
            {
                Color.DarkGray,
                Color.DimGray,
                Color.DarkSlateGray,
                Color.SlateGray,
                Color.LightGray,
            };
            GenerateStoneFormation();    
            
            return Map;
        }

        private void GenerateStoneFormation()
        {
            int left = rnd.Next(1, GetNumber());
            int down = rnd.Next(1, GetNumber());
            int right = rnd.Next(1, GetNumber());
            int up = rnd.Next(1, GetNumber());
            Tile[,] stoneMap = new Tile[left + right, down + up];

        }
        private int GetNumber()
        {
            int formationCount = rnd.Next(1, 101);
            if (formationCount <= 40)
            {
                return 2;
            }
            else if (formationCount <= 70)
            {
                return 3;
            }
            else if (formationCount <= 90)
            {
                return 4;
            }
            else if (formationCount <= 98)
            {
                return 5;
            }
            else if (formationCount <= 100)
            {
                return 6;
            }
            return -1;
        }
    }
}
