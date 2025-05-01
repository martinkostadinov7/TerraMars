using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace DataLayer
{
    public class TileContext : IDb<Tile, int>
    {
        private readonly GameDbContext dbContext;

        public TileContext(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Tile item)
        {
            dbContext.Tiles.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Tile TileFromDb = Read(key);
            dbContext.Tiles.Remove(TileFromDb);
            dbContext.SaveChanges();
        }

        public Tile Read(int key)
        {
            Tile Tile = dbContext.Tiles.Find(key);
            if (Tile == null)
            {
                throw new InvalidOperationException($"Tile with id {key} does not exist!");
            }
            return Tile;
        }

        public List<Tile> ReadAll()
        {
            return dbContext.Tiles.ToList();
        }

        public void Update(Tile item)
        {
            dbContext.Tiles.Update(item);
            dbContext.SaveChanges();
        }
    }
}
