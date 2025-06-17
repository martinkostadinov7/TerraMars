using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
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
            IQueryable<Map> query = dbContext.Maps;
            query = query
            .Include(b => b.Tiles)
            .Include(b => b.Structures);
            
            Map Map = query.FirstOrDefault(m => m.Id == key);

            if (Map == null)
            {
                throw new InvalidOperationException($"Map with id {key} does not exist!");
            }
            return Map;
        }

        public List<Map> ReadAll()
        {
            IQueryable<Map> query = dbContext.Maps;
            query = query
            .Include(b => b.Tiles)
            .Include(b => b.Structures);
            return query.ToList();
        }

        public void Update(Map item)
        {
            dbContext.Maps.Update(item);
            dbContext.SaveChanges();
        }
    }
}
