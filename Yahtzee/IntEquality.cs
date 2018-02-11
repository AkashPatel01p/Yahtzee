using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class IntEquality : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x == y; 
        }

        public int GetHashCode(int obj)
        {
            return obj; 
        }
    }
}
