using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class IntEquality :  IEqualityComparer<int>
    {
        bool IEqualityComparer<int>.Equals(int x, int y)
        {
            return x == y; 
        }

        int IEqualityComparer<int>.GetHashCode(int obj)
        {
            return obj; 
        }
    }
}
