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
        private static Color[] marsSurfaceColors =
            {
                Color.OrangeRed,
                Color.SandyBrown,
                Color.LightSalmon,
                Color.DarkSalmon,
            };
        private static Color[] stoneColors =
            {
                Color.DarkGray,
                Color.DimGray,
                Color.DarkSlateGray,
                Color.SlateGray,
                Color.LightGray,
            };
        Random rnd = new Random();

        MapContext context;
        public MapService() 
        {
            context = new MapContext(new GameDbContext());
        }
        public Tile[,] GenerateMap(User user, int x, int y)
        {
            Map map = new Map(user, x, y);
            Tile[,] matrix = new Tile[x, y];

            //generating mars surface
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Tile tile = new Tile(i, j, marsSurfaceColors[rnd.Next(0, marsSurfaceColors.Length)], TileType.MarsSurface, map);
                    map.Tiles.Add(tile);
                    matrix[i, j] = tile;
                }
            }

            //generating stones
            int stoneCount = rnd.Next(3, (x + y)/ 2);
            
            GenerateStoneFormation();

            context.Create(map);
            return matrix;
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
