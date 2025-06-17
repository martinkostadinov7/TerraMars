using BusinessLayer;
using DataLayer;
using DataLayer.Migrations;
using System.Drawing;
namespace ServiceLayer
{
    public class MapService
    {
        private static Color[] marsSurfaceColors =
            {
                Color.FromArgb(255, 253, 66, 0),
Color.FromArgb(255, 237, 79, 21),
Color.FromArgb(255, 240, 79, 19),
Color.FromArgb(255, 248, 78, 14),
Color.FromArgb(255, 239, 82, 23),
Color.FromArgb(255, 222, 93, 42),
Color.FromArgb(255, 228, 93, 39),
Color.FromArgb(255, 243, 90, 28),
Color.FromArgb(255, 225, 98, 47),
Color.FromArgb(255, 234, 100, 45),
Color.FromArgb(255, 229, 103, 53),
Color.FromArgb(255, 234, 107, 47),
Color.FromArgb(255, 233, 106, 52),
Color.FromArgb(255, 233, 115, 56),
Color.FromArgb(255, 227, 122, 73),
Color.FromArgb(255, 240, 120, 70),
Color.FromArgb(255, 245, 125, 60),
Color.FromArgb(255, 235, 129, 67),
Color.FromArgb(255, 228, 130, 89),
Color.FromArgb(255, 242, 132, 75),
Color.FromArgb(255, 236, 142, 73),
Color.FromArgb(255, 230, 141, 89),
Color.FromArgb(255, 243, 137, 89),
Color.FromArgb(255, 245, 148, 83),
Color.FromArgb(255, 224, 153, 101),
Color.FromArgb(255, 231, 157, 95),
Color.FromArgb(255, 226, 151, 108),
Color.FromArgb(255, 243, 160, 91),
Color.FromArgb(255, 243, 165, 96),
Color.FromArgb(255, 253, 160, 123),
            };
        private static Color[] stoneColors =
            {
                Color.FromArgb(255, 41, 54, 60),
Color.FromArgb(255, 44, 57, 63),
Color.FromArgb(255, 48, 60, 66),
Color.FromArgb(255, 51, 63, 69),
Color.FromArgb(255, 55, 67, 72),
Color.FromArgb(255, 58, 70, 76),
Color.FromArgb(255, 62, 73, 79),
Color.FromArgb(255, 65, 77, 82),
Color.FromArgb(255, 69, 80, 85),
Color.FromArgb(255, 72, 83, 88),
Color.FromArgb(255, 76, 87, 92),
Color.FromArgb(255, 79, 90, 95),
Color.FromArgb(255, 83, 93, 98),
Color.FromArgb(255, 86, 97, 101),
Color.FromArgb(255, 90, 100, 104),
Color.FromArgb(255, 93, 103, 108),
Color.FromArgb(255, 97, 106, 111),
Color.FromArgb(255, 100, 110, 114),
Color.FromArgb(255, 104, 113, 117),
Color.FromArgb(255, 107, 116, 120),
Color.FromArgb(255, 111, 120, 124),
Color.FromArgb(255, 114, 123, 127),
Color.FromArgb(255, 118, 126, 130),
Color.FromArgb(255, 121, 130, 133),
Color.FromArgb(255, 125, 133, 136),
Color.FromArgb(255, 128, 136, 140),
Color.FromArgb(255, 132, 140, 143),
Color.FromArgb(255, 135, 143, 146),
Color.FromArgb(255, 139, 146, 149),
Color.FromArgb(255, 143, 150, 153),

            };
        private static Color[] soilColors =
            {
                Color.Brown,
            };
        Random rnd = new Random();
        MapContext context;
        private Map Map;
        public MapService()
        {
            context = new MapContext(DbContextHelper.GetDbContext());
        }
        public MapService(MapContext mapContext)
        {
            context = mapContext;
        }
        public Map GenerateMap(User user, int rows, int cols, string name)
        {
            if (rows < 30 || rows > 40 || rows < 30 || cols > 70)
            {
                throw new Exception("Invalid map size");
            }
            if (name.Length >= 50)
            {
                throw new Exception("Maximum length name is 50!");
            }
            if (user.Maps.Count >= 10)
            {
                throw new Exception("Maximum maps per user is 10!");
            }
            if (string.IsNullOrEmpty(name))
            {
                List<Map> unnamedMaps = user.Maps.Where(m => m.Name.StartsWith("Unnamed_")).OrderBy(m => m.Name).ToList();
                name = null;
                int count = 0;
                if (unnamedMaps.Count == 0)
                {
                    name = "Unnamed_0";
                }
                else
                {
                    foreach (Map map in unnamedMaps)
                    {
                        if (!map.Name.EndsWith(count.ToString()))
                        {
                            name = "Unnamed_" + count;
                            break;
                        }
                        count++;
                    }
                    if (name == null)
                    {
                        name = "Unnamed_" + (int.Parse(unnamedMaps.Last().Name.Substring(8, 1)) + 1);
                    }
                }
            }

            foreach (var map in user.Maps)
            {
                if (map.Name == name)
                {
                    throw new Exception("Map with this name already exist!");
                }
            }

            Map = new Map(name, user, cols, rows, 0);
            Tile[,] matrix = new Tile[rows, cols];

            //generating mars surface
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Tile tile = GenerateTile(j, i, TileType.MarsSurface);
                    matrix[i, j] = tile;
                }
            }

            //generating stones
            int stoneCount = (int)Math.Ceiling(rows * cols * 0.02);
            for (int i = 0; i < stoneCount; i++)
            {
                int randomX = rnd.Next(0, cols);
                int randomY = rnd.Next(0, rows);
                GenerateStone(randomX, randomY);
            }

            void GenerateStone(int x, int y)
            {
                int left = GetNumber();
                if (left > x) left = x;
                int down = GetNumber();
                if (down > rows - y - 1) down = rows - y - 1;
                int right = GetNumber();
                if (right > cols - x - 1) right = cols - x - 1;
                int up = GetNumber();
                if (up > y) up = y;

                int rightCount = right;
                for (int i = y; i >= y - up; i--) // up right
                {
                    for (int j = x; j <= x + rightCount; j++)
                    {
                        matrix[i, j] = GenerateTile(j, i, TileType.Stone);
                    }
                    rightCount -= (rnd.Next(0, 2) == 1) ? 1 : 0;
                }

                int leftCount = left;
                for (int i = y; i >= y - up; i--) // up left
                {
                    for (int j = x; j >= x - leftCount; j--)
                    {
                        matrix[i, j] = GenerateTile(j, i, TileType.Stone);
                    }
                    leftCount -= (rnd.Next(0, 2) == 1) ? 1 : 0;
                }


                rightCount = right;
                for (int i = y; i <= y + down; i++) // down right
                {
                    for (int j = x; j <= x + rightCount; j++)
                    {
                        matrix[i, j] = GenerateTile(j, i, TileType.Stone);
                    }
                    rightCount -= (rnd.Next(0, 2) == 1) ? 1 : 0;
                }

                leftCount = left;
                for (int i = y; i <= y + down; i++) // down left
                {
                    for (int j = x; j >= x - leftCount; j--)
                    {
                        matrix[i, j] = GenerateTile(j, i, TileType.Stone);
                    }
                    leftCount -= (rnd.Next(0, 2) == 1) ? 1 : 0;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Map.Tiles.Add(matrix[i, j]);
                }
            }
            context.Create(Map);
            return Map;
        }

        
        private Tile GenerateTile(int x, int y, TileType type)
        {
            switch (type)
            {
                case TileType.MarsSurface:
                    return new Tile(x, y, marsSurfaceColors[rnd.Next(0, marsSurfaceColors.Length)], TileType.MarsSurface, Level.Ground, true, Map, true);
                    break;
                case TileType.Soil:
                    return new Tile(x, y, soilColors[rnd.Next(0, soilColors.Length)], TileType.Soil, Level.Ground, true, Map, true);
                    break;
                case TileType.Stone:
                    return new Tile(x, y, stoneColors[rnd.Next(0, stoneColors.Length)], TileType.Stone, Level.Ground, true, Map, true);
                    break;
                case TileType.Water:
                    break;
                case TileType.UndergroundWater:
                    break;
                case TileType.Ice:
                    break;
                default:
                    break;
            }
            return null;
        }

        private int GetNumber()
        {
            int formationCount = rnd.Next(1, 101);
            if (formationCount <= 50)
            {
                return 1;
            }
            else if (formationCount <= 80)
            {
                return 0;
            }
            else if (formationCount <= 90)
            {
                return 2;
            }
            else if (formationCount <= 98)
            {
                return 3;
            }
            else if (formationCount <= 100)
            {
                return 4;
            }
            return -1;
        }

        public Map GetMap(int mapId)
        {
            Map map = context.Read(mapId);
            return map;
        }

        public Tile[,] GetGroundMatrix(Map map)
        {
            Tile[,] matrix = new Tile[map.Height, map.Width];

            foreach (var tile in map.Tiles.Where(t => t.Level == Level.Ground))
            {
                matrix[tile.Y, tile.X] = tile;
            }
            
            return matrix;
        }

        public Map GetNextMap(User user, int currentMapId)
        {
            Map map = context.ReadAll()
                .Where(m => m.Id > currentMapId && m.OwnerId == user.Id)
                .OrderBy(m => m.Id)
                .FirstOrDefault();
            if (map == null)
            {
                map = context.ReadAll()
                .Where(m => m.Id < currentMapId && m.OwnerId == user.Id)
                .OrderBy(m => m.Id)
                .FirstOrDefault();
            }
            return map;
        }
        public Map GetPrevMap(User user, int currentMapId)
        {
            Map map = context.ReadAll()
                .Where(m => m.Id < currentMapId && m.OwnerId == user.Id)
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
            if (map == null)
            {
                map = context.ReadAll()
                .Where(m => m.Id > currentMapId && m.OwnerId == user.Id)
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
            }
            return map;
        }

        public (List<Coordinate>, Map) UseLaser(Map map, Tile[,] matrix, int x, int y, int laserStrength)
        {
            Map = map;
            List<Coordinate> coordinates = new List<Coordinate>();
            if (laserStrength < 1 || laserStrength > 4)
            {
                throw new Exception("Invalid laser strength");
            }
            if (x - laserStrength + 1 < 0 || x + laserStrength - 1 > matrix.GetLength(1) || y - laserStrength + 1 < 0 || y + laserStrength - 1> matrix.GetLength(0))
            {
                throw new Exception("Invalid coordinates");
            }

            switch (laserStrength)
            {
                case 1:
                    if (matrix[y, x].Type == TileType.Stone) matrix[y,x] = GenerateTile(x, y, TileType.MarsSurface);
                    else if (matrix[y, x].Type == TileType.MarsSurface) matrix[y,x] = GenerateTile(x, y, TileType.Soil);
                    Map.Tiles.Where(t => t.X == x && t.Y == y).First().Type = matrix[y,x].Type;
                    Map.Tiles.Where(t => t.X == x && t.Y == y).First().Color = matrix[y,x].Color;
                    coordinates.Add(new Coordinate(x, y));
                    break;
                case 2: break;
                case 3: break;

                default:
                    break;
            }
            context.Update(Map);
            return (coordinates, Map);
        }

        public Structure PlaceDrill(Tile[,] matrix, Map map, int x, int y)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            List<char> symbols = new List<char>();
            List<Color> colors = new List<Color>();
            if (x > map.Width - 2 || x < 1 || y > map.Height - 2 || y < 1) throw new Exception("Invalid placement");

            GenerateDrillTile(x - 1, y - 1, '/');
            GenerateDrillTile(x, y - 1, '-');
            GenerateDrillTile(x + 1, y - 1, '\\');

            GenerateDrillTile(x - 1, y, '|');
            GenerateDrillTile(x, y, 'D');
            GenerateDrillTile(x + 1, y, '|');

            GenerateDrillTile(x - 1, y + 1, '\\');
            GenerateDrillTile(x, y + 1, '_');
            GenerateDrillTile(x + 1, y + 1, '/');

            void GenerateDrillTile(int x, int y, char symbol)
            {
                if (!map.Tiles.Where(t => t.X == x && t.Y == y).First().IsPlacable)
                {
                    throw new Exception("Invalid placement");
                }
                coordinates.Add(new Coordinate(x, y));
                symbols.Add(symbol);
                colors.Add(matrix[y, x].Type == TileType.Stone ? Color.Gold : Color.DarkGoldenrod);
                map.Tiles.Where(t => t.X == x && t.Y == y).First().IsPlacable = false;
            }

            Structure Drill = new Structure(map, symbols, StructureType.Drill, coordinates, colors);
            map.Structures.Add(Drill);
            map.LastModified = DateTime.Now;
            context.Update(map);
            return Drill;
        }

        public void DeleteMap(int mapId)
        {
            context.Delete(mapId);
        }

        public Map UpdateMap(Map map, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid name!");
            }
            foreach (var map1 in map.Owner.Maps)
            {
                if (map1.Name == name)
                {
                    throw new Exception("Map with this name already exist!");
                }
            }
            map.Name = name;
            context.Update(map);
            return map;
        }

        public (Structure, int) RemoveDrill(Map map, int x, int y)
        {
            Structure drill = map.Structures.Where(t => t.Coordinates.Contains(new Coordinate(x, y))).FirstOrDefault();
            if (drill == null)
            {
                throw new Exception("Select structure first!");
            }
            foreach (var coordinate in drill.Coordinates)
            {

                map.Tiles.Where(t => t.X == coordinate.X && t.Y == coordinate.Y).First().IsPlacable = true;
            }
            int drillIndex = map.Structures.IndexOf(drill);
            map.Structures.Remove(drill);
            map.LastModified = DateTime.Now;
            context.Update(map);
            return (drill, drillIndex);
        }

        public void AddStone(Map map, int stonesToAdd)
        {
            map.StoneGathered += stonesToAdd;
            context.Update(map);
        }
    }
}
