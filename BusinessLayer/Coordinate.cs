using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Coordinate
    {
        public int Id { get; set; } 
        public int X { get; set; }
        public int Y { get; set; }

        private Coordinate()
        {
            
        }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Coordinate other)
                return this.X == other.X && this.Y == other.Y;
            return false;
        }
    }
}
