using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace DataLayer
{
    public class MapContext : IDb<Map, int>
    {
        private readonly GameDbContext dbContext;

        public MapContext(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Map item)
        {
            dbContext.Maps.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Map MapFromDb = Read(key);
            dbContext.Maps.Remove(MapFromDb);
            dbContext.SaveChanges();
        }

        public Map Read(int key)
        {
            Map Map = dbContext.Maps.Find(key);
            if (Map == null)
            {
                throw new InvalidOperationException($"Map with id {key} does not exist!");
            }
            return Map;
        }

        public List<Map> ReadAll()
        {
            return dbContext.Maps.ToList();
        }

        public void Update(Map item)
        {
            dbContext.Maps.Update(item);
            dbContext.SaveChanges();
        }
    }
}
