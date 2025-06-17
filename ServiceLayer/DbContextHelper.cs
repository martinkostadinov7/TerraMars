using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace ServiceLayer
{
    public static class DbContextHelper
    {
        static GameDbContext GameDbContext;
        public static GameDbContext GetDbContext()
        {
            if (GameDbContext == null)
            {
                GameDbContext = new GameDbContext();
                return GameDbContext;
            }
            return GameDbContext;
        }
    }
}
