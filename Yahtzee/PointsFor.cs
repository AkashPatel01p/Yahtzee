using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    
    public interface PointFormula
    {
        //pre: dices != null
        //post: return >= 0
        //throws ArgumentExecption only if dices == null
        // must not throw any other kind of execption 
        int PointsFor(AmountOfItems<int> dices); 
    }

    
    public sealed class Aces : PointFormula
    {

        //post: return != null 
        public static PointFormula Build()
        {
            return new Aces(); 
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build(); 
            int amountOfOnes = dices.AmountOf(1, equality);
            return 1 * amountOfOnes; 
        }

        private Aces()
        {

        }
        
    }

    public sealed class Twos : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Twos(); 
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build();
            int amountOfTwos = dices.AmountOf(2, equality);
            return 2 * amountOfTwos; 
        }

        private Twos()
        {
            
        }
        
    }

    public sealed class Threes : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Threes();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build();
            int amountOfThrees = dices.AmountOf(3, equality);
            return 3 * amountOfThrees;
        }

        private Threes()
        {

        }
    }

    public sealed class Fours: PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Fours(); 
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build();
            int amountOfFours = dices.AmountOf(4, equality);
            return 4 * amountOfFours;
        }

        private Fours()
        {

        }
    }

    public sealed class Fives: PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Fives();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build();
            int amountOfFives = dices.AmountOf(5, equality);
            return 5 * amountOfFives;
        }

        private Fives()
        {

        }
    }

    public sealed class Sixes: PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Sixes(); 
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            var equality = IntEqualityByLiteral.Build();
            int amountOfSixes = dices.AmountOf(6, equality);
            return 6 * amountOfSixes;
        }

        private Sixes()
        {

        }
    }
    

    /// <summary>
    ///  Upper Total side is above
    ///  
    /// </summary>
    /// <typeparam name="number"></typeparam>


    public sealed class ThreeOfKind : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new ThreeOfKind();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            int sumSoFar = 0;
            var equality = IntEqualityByLiteral.Build();

            for(int face = 1; face < 7; face++)
            {
                sumSoFar += dices.AmountOf(face, equality) * face; 
            }
 
            return sumSoFar; 
        }

        private ThreeOfKind()
        {

        }
    }

    public sealed class FourOfKind : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new FourOfKind(); 
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            int sumSoFar = 0;
            var equality = IntEqualityByLiteral.Build();

            for (int face = 1; face < 7; face++)
            {
                sumSoFar += dices.AmountOf(face, equality) * face;
            }

            return sumSoFar;
        }

        private FourOfKind()
        {

        }
    }

    public sealed class FullHouse : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new FullHouse();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            return 25; 
        }

        private FullHouse()
        {

        }
    }

    public sealed class SmallStraight: PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new SmallStraight();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            return 30; 
        }

        private SmallStraight()
        {

        }
    }

    public sealed class LargeStraight : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new LargeStraight();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            return 40; 
        }

        private LargeStraight()
        {

        }
    }

    public sealed class Yahtzee : PointFormula 
    {
        //return != null 
        public static PointFormula Build()
        {
            return new Yahtzee();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            return 50; 
        }

        private Yahtzee()
        {

        }
    }

    public sealed class Chance : PointFormula
    {
        //post: return != null 
        public static PointFormula Build()
        {
            return new Chance();
        }

        public int PointsFor(AmountOfItems<int> dices)
        {
            int sumSoFar = 0;
            var equality = IntEqualityByLiteral.Build();

            for (int face = 1; face < 7; face++)
            {
                sumSoFar += dices.AmountOf(face, equality) * face;
            }

            return sumSoFar;
        }

        private Chance()
        {

        }
    }


  
}
