using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace DataLayer
{
    public class StructureContext : IDb<Structure, int>
    {
        private readonly GameDbContext dbContext;

        public StructureContext(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Structure item)
        {
            dbContext.Structures.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Structure StructureFromDb = Read(key);
            dbContext.Structures.Remove(StructureFromDb);
            dbContext.SaveChanges();
        }

        public Structure Read(int key)
        {
            Structure Structure = dbContext.Structures.Find(key);
            if (Structure == null)
            {
                throw new InvalidOperationException($"Structure with id {key} does not exist!");
            }
            return Structure;
        }

        public List<Structure> ReadAll()
        {
            return dbContext.Structures.ToList();
        }

        public void Update(Structure item)
        {
            dbContext.Structures.Update(item);
            dbContext.SaveChanges();
        }
    }
}
