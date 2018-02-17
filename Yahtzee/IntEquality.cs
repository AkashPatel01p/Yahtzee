using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public sealed class IntEqualityByLiteral : IEqualityComparer<int>
    {

        public static IEqualityComparer<int> Build()
        {
            return new IntEqualityByLiteral(); 
        }

        private IntEqualityByLiteral()
        {

        }

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
