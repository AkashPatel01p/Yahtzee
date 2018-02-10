using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    //allows depedency injection / testability of dice class 
    public interface IRandom
    {
        //post: return >= min && return < max 
        int next(int minInclusive, int maxExclusive); 
    }

    public class ReallyRandom : IRandom
    {
        
        public ReallyRandom(Random random)
        {
            this.random = random; 
        }
        int IRandom.next(int minInclusive, int maxExclusive)
        {

            return random.Next(minInclusive, maxExclusive);
        }

        private readonly Random random;
    }

    public class TestFakeRandom : IRandom
    {
        

        public TestFakeRandom(int[] values)
        {
            this.values = values; 
        }

        int IRandom.next(int minInclusive, int maxExclusive)
        {
            currentIndex++; 
            if(currentIndex > values.Length)
            {
                currentIndex = 0; 
            }
            return values[currentIndex]; 
        }

        private int currentIndex;
        private readonly int[] values;
    }
}
