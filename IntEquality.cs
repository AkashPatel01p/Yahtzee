using System;

namespace Yahtzee
{
    //does NOT use modulus or odd math  
    public class IntValueEquality : IEqualityComparer<int>
    {
        public IntValueEquality()
        {

        }

        public bool IEqualityCompare<int>.Equal(int a, int b)
        {
            return a == b;
        }
    }
}


